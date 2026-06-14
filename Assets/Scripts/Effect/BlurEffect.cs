using System;

public class BlurEffect : SkillEffectCtrl
{
	[SerializeField]
	private BlurEffect.BlurEffectData blueEffectData;
	private static IBattleCameraEffectForBlurEffect staticBattleCameraEffect; 
	private static bool isStaticInit; 
	protected IBattleCameraEffectForBlurEffect battleCameraEffect { get; }

	public static void StaticRelease() { }

	private void Awake() { }

	protected override void onDestroy() { }

	public override void ResetParameter(GameObject _prefab, int _skinId, bool _isShadow) { }

	public BlurEffect() { }

    
    [Serializable]
    public class BlurEffectData 
    {
        public float StartTime; 
        public float Value;
        public float StartDuration;
        public float Duration; 
        public float EndDuration; 
        public BlurEffectData() { }
    }
}