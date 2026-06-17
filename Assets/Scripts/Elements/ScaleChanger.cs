using System;

namespace Elements
{
    [Serializable]
    public class ScaleChanger 
    {
        public float Time; 
        public float Scale;
        public float Duration;
        public CustomEasing.eType Easing; 
    }
}