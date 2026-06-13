public abstract class ManagerSingleton<T> : ManagerBase 
{
	// Properties
	protected ApiManager apiMgr { get; set; }
	protected BlockLayerManager blockLayerMgr { get; set; }
	protected DialogManager dialogMgr { get; set; }
	protected DownloadManager downloadMgr { get; set; }
	protected EffectManager effectMgr { get; set; }
	protected ImageEffectManager imageEffectMgr { get; set; }
	protected LoadingManager loadingMgr { get; set; }
	protected MasterDataManager masterDataMgr { get; set; }
	protected MovieManager movieMgr { get; set; }
	protected ResourceManager resourceMgr { get; set; }
	protected SaveDataManager saveDataMgr { get; set; }
	protected SoundManager soundMgr { get; set; }
	protected SpineManager spineMgr { get; set; }
	protected TouchManager touchMgr { get; set; }
	protected TutorialManager tutorialMgr { get; set; }
	protected ViewManager viewMgr { get; set; }
	protected WebViewManager webViewMgr { get; set; }
	protected ViewAnimationManager viewAnimationMgr { get; set; }
	public static T Instance { get; set; }

	// RVA: -1 Offset: -1 Slot: 4
	public sealed override void CreateInstance() { }

	public sealed override void CacheManagerInstance() { }

	public sealed override void Init() { }
	protected abstract void onInit();

	private void OnDestroy() { }

	// RVA: -1 Offset: -1 Slot: 8
	protected virtual void onDestroy() { }

	// RVA: -1 Offset: -1
	protected ManagerSingleton() { }
}