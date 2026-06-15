using Spine;
using System.Collections.Generic;
using System.Linq;

public class ActionState : BaseState
{
    private Skill currentSkill;
    private string animName;
    private int elapsedFrames;
    private bool effectsApplied;
    private bool animDone;

    // Prefab 驱动的执行帧列表
    private List<int> execFrames;
    private int execFrameIndex;

    public ActionState(StateMachine stateMachine, UnitCtrl unit) : base(stateMachine, unit)
    {
    }

    public override void OnEnter()
    {
        unit.Skill.ResetAppliedEffects();

        currentSkill = unit.Skill.PendingSkill;
        if (currentSkill == null)
        {
            animDone = true;
            return;
        }

        animName = unit.Skill.GetSkillAnimName(currentSkill);
        unit.PlayAnim(animName, false);
        unit.PlaySound(currentSkill.SoundName);

        string displayName = currentSkill.DisplayName;
        if (!unit.Skill.IsAttack(currentSkill) && !string.IsNullOrEmpty(displayName))
            unit.ShowBubble(displayName);

        elapsedFrames = 0;
        effectsApplied = false;
        animDone = false;
        execFrames = currentSkill.GetExecFrames();
        execFrameIndex = 0;
        unit.spine.AnimationState.Complete += OnAnimComplete;
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
                    unit.Skill.ApplyPendingEffects(currentSkill, execFrames[execFrameIndex]);
                    execFrameIndex++;
                }
                if (execFrameIndex >= execFrames.Count)
                    effectsApplied = true;
            }
            else
            {
                // 无 Prefab 数据时回退到 CSV 帧驱动
                unit.Skill.ApplyPendingEffects(currentSkill, elapsedFrames);
                if (unit.Skill.AllEffectsApplied(currentSkill))
                    effectsApplied = true;
            }
        }
    }

    public override void OnExit()
    {
        unit.spine.AnimationState.Complete -= OnAnimComplete;
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

    private void OnAnimComplete(TrackEntry trackEntry)
    {
        if (currentSkill != null && trackEntry.Animation.Name == animName)
            animDone = true;
    }
}
