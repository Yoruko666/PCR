using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class FirearmCtrl : SkillEffectCtrl
{
	[SerializeField]
	private float HitDelay;
	[SerializeField]
	protected float MoveRate;
	[SerializeField]
	private float duration;
	public eMoveTypes MoveType;
	[SerializeField]
	private float startRotate;
	[SerializeField]
	private float endRotate;
	public Bounds ColliderBox;
	private CustomEasing easingX;
	private CustomEasing easingUpY;
	private CustomEasing easingDownY;
	private CustomEasing easingUpRotate;
	private CustomEasing easingDownRotate;
	private bool activeSelf;
	private const float HIT_DELAY_DISTANCE = 0.2f;

	public bool IsAbsolute { get; set; }
	public bool InFlag { get; set; }
	public BasePartsData FireTarget { get; set; }
	public List<NormalSkillEffect> SkillHitEffects { get; set; }
	public List<ActionParameter> EndActions { get; set; }
	public Skill Skill { get; set; }
	public Action<FirearmCtrl> OnHitAction { get; set; }
	public Vector3 TargetPos { get; set; }
	public List<ShakeEffect> ShakeEffects { get; set; }
	private bool stopFlag { get; set; }
	protected Vector3 initialPosistion { get; set; }
	protected Vector3 speed { get; set; }
	protected UnitCtrl owner { get; set; }
	protected Action onCowHit { get; set; }

	public FirearmCtrl() { }

	protected override void onDestroy() { }
	protected virtual Vector3 getHeadBonePos(BasePartsData _target) { }

	public virtual void Initialize(BasePartsData _target, List<ActionParameter> _actions, Skill _skill,
		List<NormalSkillEffect> _skillEffect, UnitCtrl _owner, float _height, bool _hasBlackOutTime,
		bool _isAbsolute, Vector3 _targetPosition, List<ShakeEffect> _shakes, eBoneType _targetBone) { }

	protected virtual void setInitialPosition() { }
	protected virtual void Awake() { }
	private void initMoveType(float _height, UnitCtrl _owner) { }
	private Vector3 GetParaboricPosition(float _currentTime, float _deltaTime) { }
	private IEnumerator updatePosition(float _lifeDistance) { yield return null; }
	public override bool _Update() { }
	private bool collisionDetection(bool _hitFlag, float _currentTime) { }
	protected virtual bool getStopFlag() { }
	public override void ResetParameter(GameObject _prefab, int _skinId, bool _isShadow) { }
}

[ExecuteAlways]
public class FirearmCtrlEx : FirearmCtrl
{
	protected override Vector3 getHeadBonePos(BasePartsData _target) { }

	public FirearmCtrlEx() { }
}