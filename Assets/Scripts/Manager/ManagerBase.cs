using UnityEngine;

public abstract class ManagerBase : MonoBehaviour 
{
	public abstract void CreateInstance();
	public abstract void CacheManagerInstance();
	public abstract void Init();
	protected void ManagerBase() { }
}