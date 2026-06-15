using Spine;
using System.Collections.Generic;
using System.Linq;

public class UbState : BaseState
{
    private Skill ubSkill;
    private int elapsedFrames;
    private bool effectsApplied;
    private bool animDone;

    // Prefab 驱动的执行帧列表
    private List<int> execFrames;
    private int execFrameIndex;

    public UbState(StateMachine stateMachine, UnitCtrl unit) : base(stateMachine, unit)
    {
    }

    public override void OnEnter()
    {
        unit.Skill.ResetAppliedEffects();

        ubSkill = unit.Skill.PendingSkill;
        if (ubSkill == null)
        {
            BattleManager.Instance.ResumeAll();
            animDone = true;
            return;
        }

        BattleManager.Instance.PauseAllExcept(unit);
        unit.PlayAnim(unit.Skill.GetSkillAnimName(ubSkill), false);
        unit.PlaySound(ubSkill.SoundName);

        string displayName = ubSkill.DisplayName;
        if (!string.IsNullOrEmpty(displayName))
            unit.ShowBubble(displayName);

        elapsedFrames = 0;
        effectsApplied = false;
        animDone = false;
        execFrames = ubSkill.GetExecFrames();
        execFrameIndex = 0;
        unit.spine.AnimationState.Complete += OnUbAnimComplete;
    }

    public override void OnTick()
    {
        if (animDone) return;

        elapsedFrames++;

        if (!effectsApplied)
        {
            // 优先使用 Prefab 帧驱动
            if (execFrames.Count > 0)
            {
                while (execFrameIndex < execFrames.Count && elapsedFrames >= execFrames[execFrameIndex])
                {
                    unit.Skill.ApplyPendingEffects(ubSkill, execFrames[execFrameIndex]);
                    execFrameIndex++;
                }
                if (execFrameIndex >= execFrames.Count)
                {
                    BattleManager.Instance.ResumeAll();
                    unit.SpendTP(1000);
                    effectsApplied = true;
                }
            }
            else
            {
                // 无 Prefab 数据时回退到 CSV 帧驱动
                unit.Skill.ApplyPendingEffects(ubSkill, elapsedFrames);
                if (unit.Skill.AllEffectsApplied(ubSkill))
                {
                    BattleManager.Instance.ResumeAll();
                    unit.SpendTP(1000);
                    effectsApplied = true;
                }
            }
        }
    }

    public override void OnExit()
    {
        unit.spine.AnimationState.Complete -= OnUbAnimComplete;
        unit.Skill.PendingSkill = null;
    }

    public override void CheckSwitchState()
    {
        if (animDone)
        {
            if (!unit.Detect())
                stateMachine.SwitchState(StateType.Run);
            else
                stateMachine.SwitchState(StateType.Idle);
        }
    }

    private void OnUbAnimComplete(TrackEntry trackEntry)
    {
        if (ubSkill != null && trackEntry.Animation.Name == ubSkill.AnimName)
            animDone = true;
    }
}
