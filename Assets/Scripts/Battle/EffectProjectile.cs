using UnityEngine;

public class EffectProjectile
{
    public BaseUnit Caster;
    public BaseUnit Target;
    public SkillAction Action;
    public Skill Skill;
    public SkillManager SkillManager;
    public int PopupIndex;
    public GameObject Visual;

    public float Speed;
    public float HitDelay;
    public float CurrentLogicX;
    public int XDir;
    public bool Reached;
    public float PostHitTimer;
    public bool Done;

    public void Tick()
    {
        if (Target == null)
        {
            Done = true;
            return;
        }

        if (!Reached)
        {
            CurrentLogicX += Speed * BattleManager.TickTime * XDir;

            if (Visual != null)
                Visual.transform.position = LogicToWorld(CurrentLogicX, Visual.transform.position.y);

            if ((XDir > 0 && CurrentLogicX >= Target.LogicX) ||
                (XDir < 0 && CurrentLogicX <= Target.LogicX))
            {
                Reached = true;
                if (HitDelay <= 0)
                {
                    SkillManager?.ApplyActionEffect(Action, PopupIndex);
                    Done = true;
                }
            }
        }
        else if (!Done)
        {
            PostHitTimer += BattleManager.TickTime;
            if (PostHitTimer >= HitDelay)
            {
                SkillManager?.ApplyActionEffect(Action, PopupIndex);
                Done = true;
            }
        }
    }

    private Vector3 LogicToWorld(float logicX, float currentY)
    {
        return new Vector3((logicX + 200) * 15 / 1160, currentY, 0);
    }
}
