using Spine;
using System.Collections.Generic;

public class UbState : BaseState
{
    private Skill ubSkill;
    private int elapsedFrames;
    private bool effectsApplied;
    private bool animDone;

    private List<(int frame, int actionId)> execSchedule;
    private int execIndex;

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
        unit.PlayAnim(unit.GetStateAnimName(StateType.Ub), false);
        unit.PlaySound(unit.GetStateSoundName(StateType.Ub));

        string displayName = ubSkill.DisplayName;
        if (!string.IsNullOrEmpty(displayName))
            unit.ShowBubble(displayName);

        elapsedFrames = 0;
        effectsApplied = false;
        animDone = false;

        execSchedule = ubSkill.GetExecSchedule();
        if (execSchedule.Count == 0)
            execSchedule = unit.Skill.GetCsvExecSchedule(ubSkill);
        execIndex = 0;

        unit.spine.AnimationState.Complete += OnUbAnimComplete;
    }

    public override void OnTick()
    {
        if (animDone) return;

        elapsedFrames++;

        if (!effectsApplied)
        {
            while (execIndex < execSchedule.Count && elapsedFrames >= execSchedule[execIndex].frame)
            {
                unit.Skill.ApplyAction(ubSkill, execSchedule[execIndex].actionId);
                execIndex++;
            }
            if (execIndex >= execSchedule.Count)
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
        if (ubSkill != null && trackEntry.Animation.Name == unit.GetStateAnimName(StateType.Ub))
            animDone = true;
    }
}
