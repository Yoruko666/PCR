using System;
using UnityEngine;

[Serializable]
public class PrefabWithTime
{
    public GameObject Prefab;
    public GameObject PrefabLeft;
    public float Time;
    public int SummonSkillIndex;
    public string TargetBoneName;
    public eEffectDifficulty EffectDifficlty;
    public bool IsTrackRotation;

    public PrefabWithTime() { }
}