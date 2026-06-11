using Spine;

/// <summary>
/// UB 施放状态：暂停所有单位 → 播动画 → 执行效果 → 恢复所有单位
/// </summary>
public class UbState : BaseState
{
    private Skill ubSkill;
    private bool animDone;

    public UbState(StateMachine stateMachine, BaseUnit unit) : base(stateMachine, unit)
    {
    }

    public override void OnEnter()
    {
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
        animDone = false;
        unit.spine.AnimationState.Complete += OnUbAnimComplete;
    }

    public override void OnTick()
    {
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
            BattleManager.Instance.ResumeAll();
            unit.SpendTP(1000);
            unit.Skill.ExecuteSkill(ubSkill);

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
