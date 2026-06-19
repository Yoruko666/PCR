
namespace Elements.Battle.Core
{
    public interface IUnitComponentContainer 
    {
        // public abstract UnitComponentAbnormal ComponentAbnormal { get; }
        // public abstract UnitComponentActionPattern ComponentActionPattern { get; }
        // public abstract UnitComponentAnimation ComponentAnimation { get; }
        // public abstract UnitComponentAnnihilation ComponentAnnihilation { get; }
        // public abstract UnitComponentBattleResult ComponentBattleResult { get; }
        // public abstract UnitComponentColor ComponentColor { get; }
        // public abstract UnitComponentCompare ComponentCompare { get; }
        // public abstract UnitComponentDamageControl ComponentDamageControl { get; }
        // public abstract UnitComponentMultiPartsBoss ComponentMultiPartsBoss { get; }
        public abstract UnitComponentParameter ComponentParameter { get; }
        // public abstract UnitComponentParameterClamped ComponentParameterClamped { get; }
        // public abstract UnitComponentPassiveSkill ComponentPassiveSkill { get; }
        // public abstract UnitComponentChangeScale ComponentScaleChange { get; }
        // public abstract UnitComponentSearchArea ComponentSearchArea { get; }
        // public abstract UnitComponentSortOrder ComponentSortOrder { get; }
        // public abstract UnitComponentSound ComponentSound { get; }
        public abstract UnitComponentState ComponentState { get; }
        // public abstract UnitComponentUnionBurst ComponentUnionBurst { get; }
    }
}