using UnityEngine;

public class FixedTransformMonoBehavior : MonoBehaviour 
{
	private FixedTransformMonoBehavior.FixedTransform transformRaw; 
	public FixedTransformMonoBehavior.FixedTransform transform { get; set; }
	public void OnAwake() { }

	public void OnDestroy() { }

	protected virtual void DestructByOnDestroy() { }

	public void SetLocalPosX(float _x) { }

	public void SetLocalPosY(float _y) { }

	public FixedTransformMonoBehavior()
    {
    }

    public class FixedTransform 
    {
        private const float DIGID = 100;
        private int positionX; 
        private int positionY; 
        public Transform TargetTransform; 

        public Vector3 localPosition { get; set; }
        public Vector3 position { get; set; }
        public Transform parent { get; set; }
        public Vector3 lossyScale { get; set; }
        public Vector3 localScale { get; set; }

        public FixedTransform(Transform _targetTransform) { }

        public void SetLocalPosX(float _x) { }

        public void SetLocalPosY(float _y) { }
    }
}
