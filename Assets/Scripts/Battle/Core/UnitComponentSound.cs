using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Elements.Battle.Core 
{
    public class UnitComponentSound : UnitComponentBase 
    {
        private const float AVOID_OVERRAP_TIME = 0.45f;
        private const float VOICE_FADE_DURATION = 0.3f;
        private const int VOICE_SUF_MAX = 3;

        private Dictionary<SoundManager.eVoiceType, int> voiceSuffixDic;
        private Dictionary<SoundManager.eVoiceType, Dictionary<int, int>> voiceSuffixDicTenth;
        private SoundManager soundManager;
        private BattleManager battleManager;

        public AudioSource VoiceSource { get; set; }
        public AudioSource SeSource { get; set; }
        public int SoundUnitId { get; set; }
        public int EnemyVoiceId { get; set; }
        public int LastVoiceFrame { get; set; }
        public Dictionary<SoundManager.eVoiceType, Dictionary<int, int>> VoiceMaxForMultiUnit { get; set; }
        public eUbResponceVoiceType UnionBurstResponceVoiceType { get; set; }
        private Elements.Battle.Core.UnitComponentAbnormal componentAbnormal { get; set; }


        public UnitComponentSound(UnitCtrl _unitController, BattleManager _battleManager, int _soundUnitId, GameObject _gameObject): base(_unitController)
        {
            battleManager = _battleManager;
            SoundUnitId = _soundUnitId;
        }

        public void PlayVoice(SoundManager.eVoiceType _voiceType, int _index, bool _lastSuffixIsRandom)
        {
            soundManager.PlayVoice(SoundUnitId, _voiceType, _index);
        }

        public void StopVoice()
        {
            soundManager.StopVoice();
        }

        public void StopVoiceExceptUbVoice() { }

        public void PlayRetireVoice() { }

        public bool CanPlayGroupVoice(SoundManager.eVoiceType _voiceType) { }


        private IEnumerator fadeoutVoice(Action _callback, float _fadeSec = 0.3f)
        {
            CustomEasing easing; 
        }

        private bool isVoicePlaying() { }

        public void SetUnionBurstResponceVoiceType(eUbResponceVoiceType _type) { }

        public void PauseSound(bool _isPause) { }

        public void PlayGroupUnitVoice(int _groupId, int _groupUnitId, SoundManager.eVoiceType _voiceType, int _index)
        {

        }

        public void InitializeVoiceMax() { }

        private void playVoiceImpl(SoundManager.eVoiceType _voiceType, int _index, bool _lastSuffixIsRandom) { }

        private IEnumerator fadeoutSeSource(float _fadeSec)
        {
            CustomEasing easing;
        }

        public bool TryGetVoiceDictionary(SoundManager.eVoiceType _voiceType, out Dictionary<int, int> _dictionary) { }

        public void PlayDamageVoice() { }

        private int getNextVoiceSuffix(SoundManager.eVoiceType _voiceType, bool _tenthPlace = false, int _index = 0) { }

        public void RegisterComponentSet(Elements.Battle.Core.IUnitComponentContainer _container) { }

        public void RemoveSource() { }

        public void FadeoutVoice(MonoBehaviour _targetBehaviour, float _fadeSec) { }

        public void FadeoutSe(MonoBehaviour _targetBehaviour, float _fadeSec) { }

        private void playVoiceForModeChange(CriAtomSource _voiceSource, int _unitId, SoundManager.eVoiceType _type, int _index = 0) { }

        public void PlayUbChainVoice(eUbResponceVoiceType _voiceType, int _unitId, CutinVoiceStatus _cutinVoiceStatus, List<UnitCtrl> _aliveUnitList)
        {

        }

        public bool IsVoicePlaying(string _cueName) { }

        public void PauseVoice(bool _isPause) { }

        public void PauseSe(bool _isPause) { }

        private void playGroupUnitVoice(int _groupId, int _groupUnitId, SoundManager.eVoiceType _voiceType, int _index) { }

        public void PlaySeWithMotion(BattleSpineController _controller, bool _canPlaySe, eSpineCharacterAnimeId _animeId, int _index1, int _index2, int _index3, bool _isLoop, float _startTime = 0) { }
    }
}