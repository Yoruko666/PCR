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

    public enum eEffectDifficulty
    {
        All = 0,
        Normal = 1,
        Hard = 2,
        VeryHard = 3,
        AllForChara = 4,
    }
}