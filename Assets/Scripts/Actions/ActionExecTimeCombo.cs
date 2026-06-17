using System;
using UnityEngine;

namespace Elements 
{
    [Serializable]
    public class ActionExecTimeCombo
    {
        public float StartTime;
        public float OffsetTime;
        public float Weight;
        public int Count;
        public Elements.Battle.Core.eComboInterpolationType InterporationType;
        public AnimationCurve Curve;

        public ActionExecTimeCombo() { } 
    }
}