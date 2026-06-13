public interface IBattleEffectPool 
{
	public abstract SkillEffectCtrl GetEffect(GameObject _prefab, UnitCtrl _owner);

	public abstract DamageEffectCtrlBase LoadNumberEffect(GameObject _prefab, UnitCtrl _owner);

	public abstract void DisappearUnitNumberEffect(UnitCtrl _owner);
}