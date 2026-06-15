using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ActionParameterOnPrefab
{
    public bool Visible;
    public eActionType ActionType;
    public List<ActionParameterOnPrefabDetail> Details;
    public AnimationCurve KnockAnimationCurve;
    public AnimationCurve KnockDownAnimationCurve;
    public eEffectType EffectType;
}