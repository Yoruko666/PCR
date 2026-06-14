using System;
using UnityEngine;
using System.Collections.Generic;

[Serializable]
public class NormalSkillEffect
{
	public GameObject Prefab;
	public GameObject PrefabLeft;
	public float[] ExecTime;
	public bool IsReaction;
	public List<NormalSkillEffect> FireArmEndEffects;
	public bool TargetActionIsReflexive;
	public int TargetActionIndex;
	public int TargetActionId;
	public ActionParameter TargetAction;
	public ActionParameter FireAction;
	public int FireActionId;
	public int TargetMotionIndex;
	public eEffectBehavior EffectBehavior;
	public eEffectTargetType EffectTarget;
	public eBoneType TargetBone;
	public eEffectTargetType FireArmEndTarget;
	public eBoneType FireArmEndTargetBone;
	public eTrackType TrackType;
	public eTrackDimension TrackDimension;
	public string TargetBoneName;
	public bool TrackRotation;
	public bool DestroyOnEnemyDead;
	public float CenterY;
	public float DeltaY;
	public bool TrackTarget;
	public float Height;
	public bool IsAbsoluteFireArm;
	public float AbsoluteFireDistance;
	public List<ShakeEffect> ShakeEffects;
	public int TargetBranchId;
	public bool PlayWithCutIn;

	public Dictionary<UnitCtrl, bool> AlreadyFireArmExecedData { get; set; }
	public List<UnitCtrl> AlreadyFireArmExecedKeys { get; set; }

	public bool AppendAndJudgeAlreadyExeced(UnitCtrl _target)
	{
		if (_target == null)
			return false;

		if (AlreadyFireArmExecedData == null)
			AlreadyFireArmExecedData = new Dictionary<UnitCtrl, bool>();

		if (AlreadyFireArmExecedData.ContainsKey(_target))
			return true;

		AlreadyFireArmExecedData[_target] = true;

		if (AlreadyFireArmExecedKeys == null)
			AlreadyFireArmExecedKeys = new List<UnitCtrl>();
		AlreadyFireArmExecedKeys.Add(_target);

		return false;
	}

	public bool IsVisualEffect()
	{
		return EffectBehavior == 0;
	}

	public NormalSkillEffect()
	{
	}
}