using System;
using System.Collections.Generic;
using UnityEngine;

namespace Elements
{
    [Serializable]
    public class ActionParameterOnPrefab
    {
        public bool Visible;
        public Elements.Battle.Core.eActionType ActionType;
        public List<ActionParameterOnPrefabDetail> Details;
        public AnimationCurve KnockAnimationCurve;
        public AnimationCurve KnockDownAnimationCurve;
        public Elements.Battle.Core.eEffectType EffectType;
    }
}