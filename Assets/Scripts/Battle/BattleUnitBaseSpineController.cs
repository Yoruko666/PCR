using UnityEngine;
using System;

namespace Elements
{
    public class BattleUnitBaseSpineController : SpineController 
    {
	    protected int skinId; 
        protected eSpineType spineType; 
        public int UnitId { get; set; }
        public int MotionType { get; set; }
        protected bool isPause { get; set; }
        public bool IsPause { get; }
        public override void Create(SpineResourceSet _resourceSpineSet) { }
        public void Destroy() { }
        public string ConvertAnimeIdToAnimeName(eSpineCharacterAnimeId _animeId, int _index1 = -1, int _index2 = -1, int _index3 = -1) { }
        public bool IsAnimation(eSpineCharacterAnimeId _animeId, int _index1 = -1, int _index2 = -1, int _index3 = -1) { }
        public void Pause() { }
        public void Resume() { }
        public void SetTimeScale(float _timeScale) { }
        public void LoadAnimationIDImmediately(eSpineBinaryAnimationId _binaryAnimationId) { }
        public void LoadAnimationIDImmediately(eSpineBinaryAnimationId _binaryAnimationId, int _index) { }
        public void RemoveAnimationIDImmediately(eSpineBinaryAnimationId _binaryAnimationId) { }
        public void RemoveAnimationIDImmediately(eSpineBinaryAnimationId _binaryAnimationId, int _index) { }
        public void UnloadAnimationResourceByIDImmediately(eSpineBinaryAnimationId _binaryAnimationId) { }
        private int getResourceIndexFromUnitIdWeaponId(eSpineBinaryAnimationId _binaryAnimationId) { }
        public void UnloadSkeletonResource(bool _isUnloadTypeNoneOnly = false) { }
        public void ChangeShader(eShader _shader) { }
        public void ChangeSkin(eSpineSkinId _spineSkinId) { }
        public static Vector3 BoneWorldToGlobalPosConsiderRotate(Bone _bone, Transform _position, Vector3 _lossyScale, bool _callFromBossDialog = false) { }
        public static Vector3 BoneWorldToGlobalPos(Bone _bone, Vector3 _position, Vector3 _lossyScale) { }
        public static Vector3 BoneWorldToLocalPos(Bone _bone, Transform _parent) { }
        protected override void EntryCallBack() { }
        public void BattleUnitBaseSpineControllerr() { }
    }
}