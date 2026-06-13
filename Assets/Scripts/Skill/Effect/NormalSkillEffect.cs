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
	public GAPCEIKMBGH EffectBehavior; // 0x60
	public FJMDPHIKDND EffectTarget; // 0x64
	public LIHJDOLGNIN TargetBone; // 0x68
	public FJMDPHIKDND FireArmEndTarget; // 0x6C
	public LIHJDOLGNIN FireArmEndTargetBone; // 0x70
	public EFOOGOFPDMC TrackType; // 0x74
	public PBDBBFJFOPL TrackDimension; // 0x78
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
	[CompilerGenerated]
	private Dictionary<UnitCtrl, bool> <AlreadyFireArmExecedData>k__BackingField; // 0xB8
	[CompilerGenerated]
	private List<UnitCtrl> <AlreadyFireArmExecedKeys>k__BackingField; // 0xC0

	// Properties
	public Dictionary<UnitCtrl, bool> AlreadyFireArmExecedData { get; set; }
	public List<UnitCtrl> AlreadyFireArmExecedKeys { get; set; }

	// RVA: 0x207BE00 Offset: 0x207BE00 VA: 0x207BE00
	public bool AppendAndJudgeAlreadyExeced(UnitCtrl _target) { }

	// RVA: 0x207BF78 Offset: 0x207BF78 VA: 0x207BF78
	public bool IsVisualEffect() { }

	// RVA: 0x207BF90 Offset: 0x207BF90 VA: 0x207BF90
	public void .ctor() { }
}