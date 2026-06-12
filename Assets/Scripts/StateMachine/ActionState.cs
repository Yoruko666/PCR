using Spine;

public class ActionState : BaseState
{
    private Skill currentSkill;
    private string animName;
    private float elapsedTime;
    private bool effectsApplied;
    private bool animDone;

    public ActionState(StateMachine stateMachine, BaseUnit unit) : base(stateMachine, unit)
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

        animName = GetAnimName(currentSkill);
        unit.PlayAnim(animName, false);

        if (!unit.Skill.IsAttack(currentSkill) && currentSkill.Data != null && !string.IsNullOrEmpty(currentSkill.Data.name))
            unit.ShowBubble(currentSkill.Data.name);

        elapsedTime = 0;
        effectsApplied = false;
        animDone = false;
        unit.spine.AnimationState.Complete += OnAnimComplete;
    }

    public override void OnTick()
    {
        if (animDone) return;

        elapsedTime += BattleManager.TickTime;

        if (!effectsApplied)
        {
            unit.Skill.ApplyPendingEffects(currentSkill, elapsedTime);
            if (unit.Skill.AllEffectsApplied(currentSkill))
                effectsApplied = true;
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

    private string GetAnimName(Skill skill)
    {
        if (skill == null) return "";
        if (unit.Skill.IsAttack(skill)) return unit.GetAnimName("attack");
        if (skill == unit.Skill.Attack) return unit.GetAnimName("attack");
        if (skill == unit.Skill.MainSkill1) return $"{unit.UnitId}_skill1";
        if (skill == unit.Skill.MainSkill2) return $"{unit.UnitId}_skill2";
        return "skill1";
    }
}
