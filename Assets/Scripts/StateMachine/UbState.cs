using Spine;

/// <summary>
/// UB 施放状态：暂停所有单位 → 播动画 → 各效果按各自前摇依次触发 → 动画播完恢复所有单位
/// </summary>
public class UbState : BaseState
{
    private Skill ubSkill;
    private int elapsedFrames;
    private bool effectsApplied;
    private bool animDone;

    public UbState(StateMachine stateMachine, BaseUnit unit) : base(stateMachine, unit)
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
        unit.PlayAnim(ubSkill.Config.AnimName, false);
        unit.PlaySound(ubSkill.Config.SoundName);
        unit.ShowBubble(ubSkill.Config.Name);

        elapsedFrames = 0;
        effectsApplied = false;
        animDone = false;
        unit.spine.AnimationState.Complete += OnUbAnimComplete;
    }

    public override void OnTick()
    {
        if (animDone) return;

        elapsedFrames++;

        if (!effectsApplied)
        {
            unit.Skill.ApplyPendingEffects(ubSkill.Config.Id, elapsedFrames);
            if (unit.Skill.AllEffectsApplied(ubSkill.Config.Id))
            {
                BattleManager.Instance.ResumeAll();
                unit.SpendTP(1000);
                effectsApplied = true;
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
        if (ubSkill != null && trackEntry.Animation.Name == ubSkill.Config.AnimName)
            animDone = true;
    }
}
