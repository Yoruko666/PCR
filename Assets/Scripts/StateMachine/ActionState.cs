using Spine;
using System.Collections.Generic;

public class ActionState : BaseState
{
    private Skill currentSkill;
    private int elapsedFrames;
    private bool effectsApplied;
    private bool animDone;

    private List<(int frame, int actionId)> execSchedule;
    private int execIndex;

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

        unit.PlayAnim(unit.GetStateAnimName(StateType.Action), false);
        unit.PlaySound(unit.GetStateSoundName(StateType.Action));

        string displayName = currentSkill.DisplayName;
        if (!unit.Skill.IsAttack(currentSkill) && !string.IsNullOrEmpty(displayName))
            unit.ShowBubble(displayName);

        elapsedFrames = 0;
        effectsApplied = false;
        animDone = false;

        // Prefab 调度表优先，无数据时走 CSV 回退
        execSchedule = currentSkill.GetExecSchedule();
        if (execSchedule.Count == 0)
            execSchedule = unit.Skill.GetCsvExecSchedule(currentSkill);
        execIndex = 0;

        unit.spine.AnimationState.Complete += OnAnimComplete;
    }

    public override void OnTick()
    {
        if (animDone) return;

        elapsedFrames++;

        if (!effectsApplied)
        {
            while (execIndex < execSchedule.Count && elapsedFrames >= execSchedule[execIndex].frame)
            {
                unit.Skill.ApplyAction(currentSkill, execSchedule[execIndex].actionId);
                execIndex++;
            }
            if (execIndex >= execSchedule.Count)
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
        if (currentSkill != null && trackEntry.Animation.Name == unit.GetStateAnimName(StateType.Action))
            animDone = true;
    }
}
