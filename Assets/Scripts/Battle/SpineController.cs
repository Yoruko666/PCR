using Spine;
using Spine.Unity;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SpineController : SkeletonAnimation 
{
    private Skin DefaultSkin;
//  private Dictionary<Skin.AttachmentKeyTuple, Attachment> defaultAttachmentDic; 
//  protected SpineManager spineManager; 
    protected Spine.AnimationState.TrackEntryDelegate startEndDelegate;
    protected Spine.AnimationState.TrackEntryDelegate startStartDelegate; 
    protected Spine.AnimationState.TrackEntryEventDelegate eventDelegate; 
//	private ColorShader colorShader; 
    private Material[] materialArray; 
    protected bool isSyncUpdate;

    // Properties
    public string DefaultSkinName { get; }
    public bool IsPlayAnime { get; set; }
    public string AnimeName { get; set; }
    public int Depth { get; set; }
    public Color CurColor { get; set; }
    public Color CurColorOffset { get; set; }
    public bool IsFadeProccess { get; }
    protected Shader defaultShader { get; set; }

//  public override void OnDestroy() { }

//  public override void Update() { }

//  public static SpineController LoadCreateImmidiate(eSpineType _spineType, int _trgIdx0, int _trgIdx1, Transform _transform, Action<SpineController> _callback) { }
    public virtual void SyncUpdate(float _time) { }
    public void SetUseSyncUpdate(bool _isSyncUpdate) { }
//  public virtual void Create(SkeletonDataAsset _createSkeletonDataAsset) { }
//  public virtual void Create(SpineResourceSet _resourceSpineSet) { }
//  public Dictionary<string, Spine.Animation> GetAnimations() { }
    private void ChangeSkeletonDataAsset(SkeletonDataAsset _createSkeletonDataAsset) { }
    public void SetColor(string _propertyName, Color _color) { }
    public void ChangeDefaultShader() { }
    public void ChangeShader(Shader _shader) { }
    public void ChangeSkin(string _skinName) { }
//  public bool ChangeSkinWithCheck(eSpineSkinId _skinId) { }
    public void ChangeDefaultAttachment() { }
//  public bool FindSkinData(string _skinName) { }
//  public Skin GetCurrentSkin() { }
    public virtual void PlayAnime(string _playAnimeName, bool _playLoop = true) { }
    public virtual void PlayAnime(int _trackIndex, string _playAnimeName, bool _playLoop = true) { }
    public void PlayAnimeNoOverlap(string _playAnimeName, bool _playLoop = true) { }
    public void EntryAnime(string _animeName, bool _loop, float _delay = 0) { }
    public void StopAnime(int _trackIndex) { }
    public void StopAnimeAll() { }
//  public bool IsAnimation(string _animeName) { }
    private void SetAnimeEventDelegate(Spine.AnimationState.TrackEntryEventDelegate _eDelegate) { }
//  public void SetAnimeEventDelegate(Action<Event> _callBack) { }
    protected virtual void EntryCallBack() { }
    private void DestroyCallBack() { }
    public void FadeIn(float _timeMax, Action _onFinish) { }
    public void FadeOut(float _timeMax, Action _onFinish) { }
    public void AddMixAnimation(string _fromAnime, string _toAnime, float _duration) { }
}