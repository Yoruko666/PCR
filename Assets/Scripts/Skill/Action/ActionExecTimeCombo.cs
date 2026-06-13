using System;
using UnityEngine;

[Serializable]
public class ActionExecTimeCombo 
{
	public float StartTime; 
	public float OffsetTime;
	public float Weight;
	public int Count; 
	public eInterporationType InterporationType; 
	public AnimationCurve Curve; 
}

public enum eInterporationType
{

}