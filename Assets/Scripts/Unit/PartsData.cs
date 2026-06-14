using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine;

public class PartsData : BasePartsData, ISingletonField
{
	private const string CENER_BONE = "Center_{0:D2}";
	private const string STATE_BONE = "State_{0:D2}";

	// --- 字段 ---
	private IBattleEffectPool battleEffectPool;
	private long DefForDamagedEnergy;
	private long MagicDefForDamagedEnergy;

	// --- 自动属性 ---
	public Action OnBreak { get; set; }
	public Action OnBreakEnd { get; set; }
	public bool IsBreak { get; set; }
	public UnitCtrl BreakSource { get; set; }
	public MultiTargetCursor MultiTargetCursor { get; set; }
	private Bone centerBone { get; set; }
	private Bone stateBone { get; set; }
	private Vector3 fixedCenterPos { get; set; }
	public int Level { get; set; }
	public long Atk { get; set; }
	public long MagicStr { get; set; }
	public long Def { get; set; }
	public long MagicDef { get; set; }
	public long Dodge { get; set; }
	public long Accuracy { get; set; }
	public long PhysicalCritical { get; set; }
	public long MagicCritical { get; set; }
	public long LifeSteal { get; set; }
	public long HpRecoveryRate { get; set; }
	public long StartAtk { get; set; }
	public long StartMagicStr { get; set; }
	public long StartDef { get; set; }
	public long StartMagicDef { get; set; }
	public long StartDodge { get; set; }
	public long StartPhysicalCritical { get; set; }
	public long StartMagicCritical { get; set; }
	public long StartLifeSteal { get; set; }
	public long BreakPoint { get; set; }
	public float BreakTime { get; set; }
	public long MaxBreakPoint { get; set; }
	private Dictionary<COMDCIFOEGF, long> additionalBuffDictionary { get; set; }

	// --- 构造 ---
	public PartsData() { }

	// --- 公共方法 ---
	public void Initialize(ENIOFFNEOPC.BEGBHDMLBLA _enemyMParts, BattleManager _battleManager) { }

	private long getAdditionalBuff(COMDCIFOEGF _kind) { }

	public override Bone GetStateBone() { }
	public override Bone GetCenterBone() { }
	public override Vector3 GetBottomTransformPosition() { }
	public override Vector3 GetFixedCenterPos() { }
	public override Vector3 GetPosition() { }
	public override Vector3 GetLocalPosition() { }
	public override float GetBodyWidth() { }
	public override Vector3 GetColliderCenter() { }
	public override Vector3 GetColliderSize() { }

	public override long GetDefZero() { }
	public override long GetMagicDefZero() { }
	private long getDodgeZero() { }
	public override long GetAtkZero() { }
	public override long GetMagicStrZero() { }
	public override long GetAccuracyZero() { }
	public override long GetPhysicalCriticalZero() { }
	public override long GetMagicCriticalZero() { }
	public override long GetLifeStealZero() { }
	public override long GetHpRecoverRateZero() { }
	public override int GetLevel() { }
	public override float GetDodgeRate(long _accuracy) { }
	public override long GetDefZeroForDamagedEnergy() { }
	public override long GetMagicDefZeroForDamagedEnergy() { }

	public override long GetStartAtk() { }
	public override long GetStartDef() { }
	public override long GetStartMagicStr() { }
	public override long GetStartMagicDef() { }
	public override long GetStartDodge() { }
	public override long GetStartPhysicalCritical() { }
	public override long GetStartMagicCritical() { }
	public override long GetStartLifeSteal() { }

	public override void SetMissAtk(UnitCtrl _source, eMissLogType _missLogType, eDamageEffectType _damageEffectType, float _scale) { }
	public override void SetBuffDebuff(bool _enable, long _value, COMDCIFOEGF _kind, UnitCtrl _source, IBattleLog _battleLog, bool _additional) { }
	public override bool GetTargetable() { }

	public IEnumerator TrackBottomCoroutine(bool _topBack) { yield return null; }
	public void TrackBottom(bool _isTopBack) { }

	public void SetDamage(long _damage, UnitCtrl _source) { }
	public void SetBreak(bool _enable, Transform _unitUiCtrl, bool _displayEffect) { }
	private void createBreakEffect(int _targetMotion) { }
	private IEnumerator waitAndPlayBreak(float _timer, Transform _unitUiCtrl) { yield return null; }
	private IEnumerator updateChangeAttachment(float _timer, bool _enable) { yield return null; }
	public void ChangeAttachment(UnitCtrl _owner) { }
	public void FixAttachment(UnitCtrl _owner) { }
	public void DisableCursor() { }
	private IEnumerator waitAndBreakPointReset() { yield return null; }
}
