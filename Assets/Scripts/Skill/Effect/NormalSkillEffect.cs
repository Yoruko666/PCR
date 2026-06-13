using System;
using UnityEngine;
using System.Collections.Generic;

[Serializable]
public class NormalSkillEffect
{
	// Fields
	public GameObject Prefab; 
	public GameObject PrefabLeft; 
	public float[] ExecTime; // 0x20
	public bool IsReaction; // 0x28
	public List<NormalSkillEffect> FireArmEndEffects; 
	public bool TargetActionIsReflexive; // 0x38
	public int TargetActionIndex; // 0x3C
	public int TargetActionId; // 0x40
	public ActionParameter TargetAction; // 0x48
	public ActionParameter FireAction; // 0x50
	public int FireActionId; // 0x58
	public int TargetMotionIndex; // 0x5C
	public eEffectBehavior EffectBehavior; // 0x60
	public eTargetType EffectTarget; // 0x64
	public eBoneType TargetBone; // 0x68
	public eTargetType FireArmEndTarget; // 0x6C
	public eBoneType FireArmEndTargetBone; // 0x70
	public eTrackType TrackType; // 0x74
	public eTrackDimension TrackDimension; // 0x78
	public string TargetBoneName; // 0x80
	public bool TrackRotation; // 0x88
	public bool DestroyOnEnemyDead; // 0x89
	public float CenterY; // 0x8C
	public float DeltaY; // 0x90
	public bool TrackTarget; // 0x94
	public float Height; // 0x98
	public bool IsAbsoluteFireArm; // 0x9C
	public float AbsoluteFireDistance; // 0xA0
	public List<ShakeEffect> ShakeEffects; // 0xA8
	public int TargetBranchId; // 0xB0
	public bool PlayWithCutIn; // 0xB4

	// Properties
	public Dictionary<UnitCtrl, bool> AlreadyFireArmExecedData { get; set; }
	public List<UnitCtrl> AlreadyFireArmExecedKeys { get; set; }

	public bool AppendAndJudgeAlreadyExeced(UnitCtrl _target) { }

	public bool IsVisualEffect() { }

	public void NormalSkillEffect() { }
}