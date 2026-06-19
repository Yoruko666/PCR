using System;
using UnityEngine;

namespace Elements
{
    [Serializable]
    public class ShakeEffect
    {
        public eShakeType ShakeType;
        public float StartTime;
        public float Duration;
        public int TargetMotion;
        public float StartAmplitude;
        public float EndAmplitude;
        public float StartFrequency;
        public float EndFrequency;
        public float Rotation;
        public CustomEasing EasingFrequency;
        public CustomEasing EasingAmplitude;

        private float timer { get; set; }
        private int numberOfShake { get; set; }
        public float CurrentAmplutude { get; set; }
        public Vector3 CurrentShakePos { get; set; }
        public bool ShakeLoopEnd { get; set; }

        public void ResetStart(Skill skill, UnitCtrl owner)
        {

        }

        //  public bool GetOwnerPause() { }

        //  public bool Simulate(float deltaTime) { }
    }
}