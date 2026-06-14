using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class BasePartsData
{
	private const int ALL_DETAIL_VALUE = -1;

	private int currentAbnormalResistId;
	private int currentDebuffResistId;
	public float PositionX;
	public float PositionY;
	public List<AttachmentNamePair> AttachmentNamePairList;
	public bool DisableStartBreakEffect;
	public float ChangeAttachmentStartTime;
	public float ChangeAttachmentEndTime;
	public float BodyWidthValue;
	public int Index;
	public int EnemyId;
	public float BreakEffectTime;
	public float BreakEffectOffsetY;
	public float BreakEffectSize;
	private float lastHealEffectTime;
	private Dictionary<int, Dictionary<eActionType, Dictionary<int, int>>> abnormalResistIdDictionary;
	private Dictionary<int, Dictionary<eBuffKind, int>> debuffResistIdDictionary;
	private Dictionary<int, int> talentWeaknessPercent;

	public int StartAbnormalResistId { get; set; }
	public int StartDebuffResistId { get; set; }
	public List<NormalSkillEffect> BreakEffectList { get; set; }
	public float InitialPositionX { get; set; }
	public UnitCtrl Owner { get; set; }
	public long TotalDamage { get; set; }
	protected BattleManager battleManager { get; set; }
	public int UbAttackHitCount { get; set; }
	public bool PassiveUbIsMagic { get; set; }
	public bool IsBlackoutTarget { get; set; }
	public int AbnormalResistIdSetCount { get; set; }
	public int DebuffResistIdSetCount { get; set; }
	public List<int> TalentWeaknessIds { get; }
	private Dictionary<eActionType, Dictionary<int, int>> abnormalResistStatusDictionary { get; }
	private Dictionary<eBuffKind, int> debuffResistStatusDictionary { get; }
	protected IComponentParameter componentParameter { get; set; }
	protected IComponentParameterClamped componentParameterClamped { get; set; }

	public BasePartsData() { }

	public void SetBattleManager(BattleManager _battleManager) { }

	public virtual Vector3 GetPosition() { }
	public virtual Vector3 GetLocalPosition() { }
	public virtual float GetBodyWidth() { }
	public virtual Vector3 GetBottomTransformPosition() { }
	public virtual Vector3 GetOwnerBottomTransformPosition() { }
	public Vector3 GetBottomTransformLocalPosition() { }
	public Vector3 GetBottomLossyScale() { }
	public virtual Bone GetStateBone() { }
	public virtual Bone GetCenterBone() { }
	public virtual Vector3 GetFixedCenterPos() { }
	public virtual Vector3 GetColliderCenter() { }
	public virtual Vector3 GetColliderSize() { }
	public virtual int GetLevel() { }

	public void IncrementUbAttackHitCount() { }

	public virtual long GetAtkZero() { }
	public virtual long GetMagicStrZero() { }
	public virtual long GetAccuracyZero() { }
	public virtual long GetPhysicalCriticalZero() { }
	public virtual long GetMagicCriticalZero() { }
	public virtual long GetLifeStealZero() { }
	public virtual long GetHpRecoverRateZero() { }
	public virtual float GetDodgeRate(long _accuracy) { }
	public virtual long GetDefZero() { }
	public virtual long GetMagicDefZero() { }
	public virtual long GetDefZeroForDamagedEnergy() { }
	public virtual long GetMagicDefZeroForDamagedEnergy() { }

	public virtual void SetMissAtk(UnitCtrl _source, eMissLogType _missLogType, eDamageEffectType _damageEffectType, float _scale) { }
	public void ShowHitEffect(SystemIdDefine.eWeaponSeType _weaponSeType, Skill _skill, bool _isLeft) { }

	public virtual long GetStartAtk() { }
	public virtual long GetStartDef() { }
	public virtual long GetStartMagicStr() { }
	public virtual long GetStartMagicDef() { }
	public virtual long GetStartDodge() { }
	public virtual long GetStartPhysicalCritical() { }
	public virtual long GetStartMagicCritical() { }
	public virtual long GetStartLifeSteal() { }

	public IEnumerator StartTotalDamage(bool _isLarge, float _delay, UnitCtrl _unit) { yield return null; }
	public bool JudgeShowTotalDamage() { }
	public void ResetTotalDamage() { }

	public virtual void SetBuffDebuff(bool _enable, long _value, eBuffKind _kind, UnitCtrl _source, IBattleLog _battleLog, bool _additional) { }
	public void RecoveryEffect(UnitCtrl _source, bool _isEnergy, IBattleEffectPool _battleEffectPool, bool _isRegenerate = false) { }
	public virtual bool GetTargetable() { }

	public void SetAbnormalResistId(int _resistId, bool _isInit) { }
	public void SetDebuffResistId(int _resistId, bool _isInit) { }
	private void createResistStatus(int _resistId) { }
	private void createDebuffStatus(int _resistId) { }

	public void SetTalentWeakness(Dictionary<int, int> _talentWeaknessPercent) { }

	public bool ResistStatus(eActionType _actionType, int _detail1, UnitCtrl _source, bool _last, bool _targetOneParts, BasePartsData _target) { }
	public int GetDebuffResistPercent(eBuffKind _buffParamKind) { }
	public double GetTalentWeaknessPercent(List<int> _talentIds) { }

	// --- 内嵌类 ---
	[System.Serializable]
	public class AttachmentNamePair
	{
		public string TargetSlotName;
		public string TargetAttachmentName;
		public string AppliedSlotName;
		public string AppliedAttachmentName;

		public int TargetIndex { get; set; }
		public Attachment TargetAttachment { get; set; }
		public Attachment AppliedAttachment { get; set; }

		public AttachmentNamePair() { }
	}
}
