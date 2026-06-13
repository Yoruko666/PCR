public interface IUnitComponentContainer 
{
	public abstract IComponentAbnormal ComponentAbnormal { get; }
	public abstract IComponentActionPattern ComponentActionPattern { get; }
	public abstract IComponentAnimation ComponentAnimation { get; }
	public abstract IComponentAnnihilation ComponentAnnihilation { get; }
	public abstract IComponentBattleResult ComponentBattleResult { get; }
	public abstract IComponentColor ComponentColor { get; }
	public abstract IComponentCompare ComponentCompare { get; }
	public abstract IComponentDamageControl ComponentDamageControl { get; }
	public abstract IComponentLog ComponentLog { get; }
	public abstract IComponentMultiPartsBoss ComponentMultiPartsBoss { get; }
	public abstract IComponentParameter ComponentParameter { get; }
	public abstract IComponentParameterClamped ComponentParameterClamped { get; }
	public abstract IComponentPassiveSkill ComponentPassiveSkill { get; }
	public abstract IComponentScaleChange ComponentScaleChange { get; }
	public abstract IComponentSearchArea ComponentSearchArea { get; }
	public abstract IComponentSortOrder ComponentSortOrder { get; }
	public abstract IComponentSound ComponentSound { get; }
	public abstract IComponentState ComponentState { get; }
	public abstract IComponentUnionBurst ComponentUnionBurst { get; }
}