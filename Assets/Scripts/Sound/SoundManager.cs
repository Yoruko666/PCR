using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cute.Cri;

[Serializable]
private sealed class SoundManager.<> c 
{
    public static readonly SoundManager.<> c<>9;     
    public static Func<CriAtomEx.CueInfo, string> <> 9__129_0;     
    public static Func<CriAtomEx.CueInfo, string> <> 9__130_0;     
    public static Func<CriAtomEx.CueInfo, string> <> 9__133_2; 

    internal string < GetExistsCueName > b__129_0(CriAtomEx.CueInfo info) { }

    internal string < PlayVoiceTitleCallCustomize > b__130_0(CriAtomEx.CueInfo info) { }

    internal string < GetRandomCharaCallAction > b__133_2(CriAtomEx.CueInfo info) { }
}

namespace Elements
{
    public class SoundManager : ManagerSingleton<SoundManager>
    {
        public const float CUTE_RATE = 10;
        public const int DEFAULT_RATE = 7;
        private const int MAX_VOICE_NUM = 2;
        public const float BGM_COMMON_FADE_TIME = 0.7f;
        public const float BGM_JINGLE_WAIT_TIME = 0.5f;
        public const int VIEW_BGM_DEFAULT_CHANNEL = 0;

        public const string VOICE_BTL_CUESHEET_FORMAT = "vo_btl_{0}";
        public const string SE_CUT_IN_CUESHEET_FORMAT = "se_cutin_{0}";
        public const string SE_BTL_CUESHEET_FORMAT = "se_btl_{0}";
        public const string SE_MINIGAME_CUESHEET_FORMAT = "se_minigame_{0}";
        public const int SE_BTL_CUESHEET_VARIATION_MAX = 3;
        public const string VOICE_BTG_CUESHEET_FORMAT = "vo_btg_{0}";
        public const string STORY_VOICE_CUE_SHEET_NAME_PREFIX = "v/t/vo_adv_";
        public const string EVENT_TOP_NAVI_VOICE_NAME_PREFIX = "v/vo_enavi_";

        public static readonly Dictionary<eBGM, SoundParam> BGM_PARAM_DICT;
        private static readonly Dictionary<eSE, SoundParam> SE_SOUND_PARAM_DICT;
        private Dictionary<eSE, eSEPartial> PARAM_SEPARTIAL_TYPE_DICT;
        public static readonly string PREINSTALL_CUESHEET;
        public static readonly string SE_COMMON_CUESHEET;
        public static readonly string SE_BATTLE_CUESHEET;
        public static readonly string SE_ROOM_CUESHEET;
        public static readonly string SE_ADV_STEP;
        private static readonly string[] RESIDENT_CUESHEET;
        private static readonly string VOICE_CATEGORY;
        private static readonly string SE_EFFECT_CATEGORY;
        private static readonly string SOUND_PLAY_SPEED_CATEGORY;
        public const int EVENT_TOP_NAVI_VOICE_NAME_NUMBER_LENGTH = 6;
        private static readonly string VOICE_CUESHEET_PREFIX;
        private static readonly string VOICE_CMN_CUESHEET_FORMAT;
        private static readonly string VOICE_NABI_CUESHEET_FORMAT;
        private static readonly string VOICE_TITLE_CALL_CUESHEET_PREFIX;
        private static readonly string VOICE_SPLASH_CALL_CUESHEET_PREFIX;
        private const float DEFAULT_STOP_ENV_FADE_DURATION = 0.3f;
        public static readonly string VOICE_ROOM_CUESHEET_FORMAT; public const string VO_CNM_PREFIX = "v/vo_cmn_";
        public const int VO_CNM_CHAR_ID_LENGTH = 4;
        private static readonly Dictionary<eVoiceType, VoiceCueParam> VOICE_CUEDATA; private static readonly Dictionary<SoundGroup, string[]> ASR_BUS_DATA; public Dictionary<int, List<string>> EventUsedBgmAssetDictionary; private AudioManager cuteAudioManager; private Action callbackPlayStoryEnd; private IEnumerator playStoryCoroutine; private AudioPlayback lastPlayedBgm; private AudioPlayback lastPlayedJingle; private AudioPlayback lastPlayedVoice; private int singleChannelEnvChannel; private string singleChannelEnvCueName; private string singleChannelEnvSavedCueName; private static readonly Dictionary<eJINGLE, SoundParam> JINGLE_PARAM_DICT; private static readonly Dictionary<eSEPartial, SoundParam> SE_PARAM_DICT; private static readonly Dictionary<string, eSEPartial> SE_CUENAME_DICT;
        public int VolumeBgm { get; set; }
        public float VolumeLevelBgm { get; }
        public int VolumeSe { get; set; }
        public float VolumeLevelSe { get; }
        public int VolumeVoice { get; set; }
        public float VolumeLevelVoice { get; }
        public bool IsMuteBgm { get; set; }
        public bool IsMuteSe { get; set; }
        public bool IsMuteVoice { get; set; }
        public List<string> CommonBgmAssetList { get; set; }
        public HashSet<string> CommonBgmAssetHashSet { get; set; }
        public AudioPlayback LastPlayedBgm { get; }

        public staticVoiceCueParam GetVoiceCueParam(SoundManager.eVoiceType _voiceType) { }

        private IEnumerator Start() { }

        protected override void onInit() { }

        protected override void onDestroy() { }

        public void SetupBgmUsedPosition(bool _isBgmUsedPositionResourceDownloaded) { }

        public AudioPlayback PlayViewBGM(eBGM _type) { }

        public AudioPlayback PlayBGM(string _cueName, float _fadeTime = 0, int _channel = 0, bool _loop = true, float _offsetTime = 0, bool _isSameBgmPlay = false, float _startTime = 0) { }

        public AudioPlayback PlayBGM(string _cueSheet, string _cueName, float _fadeTime = 0, int _channel = 0, bool _loop = true, float _offsetTime = 0, bool _isSameBgmPlay = false, float _startTime = 0) { }

        public AudioPlayback PlayBGMCrossFade(string _cueName, float _fadeOutTime, float _fadeInTime = 0, float _offsetTime = 0) { }

        public AudioPlayback PlayBGMCrossFade(string _cueSheet, string _cueName, float _fadeOutTime, float _fadeInTime = 0, float _offsetTime = 0, float _startTime = 0, bool _loop = true) { }

        public AudioPlayback ResumeBGMCrossFade(float _fadeOutTime, float _fadeInTime = 0, float _offsetTime = 0) { }

        public AudioPlayback PlayActionCue(AudioPlayback _playBack, string _cueSheet, string _cueName) { }

        public void StopBgm(float _fadeOutTime = 0) { }

        public void StopBgm(AudioPlayback _audioPlayback, Action _callback) { }

        public void PauseBgm(bool _isPause = true, int _channel = 0, float _fadeTime = 0) { }

        public void PauseBgmAll(bool _isPause = true, float _fadeTime = 0) { }

        public void StopFadeBgm(int _channel = 0, float _fadeTime = 0.5, Action _callback) { }

        public void StopFadeAllBgm(float _fadeTime = 0.5) { }

        public void UpdateBgmChannelVolume(float _volume, int _channel = -1) { }

        public SoundParam GetBgmParam(eBGM _bgm) { }

        public CuePair GetBgmCuePair(eBGM _bgm) { }

        public bool IsSameBgmSoundParam(eBGM _bgm, string _sheet, string _name) { }

        public bool IsSameBgmSoundParam(string _sheet1, string _name1, string _sheet2, string _name2) { }

        public bool IsPlayBgm(int _channel) { }

        public staticSoundParam GetJingleParam(eJINGLE _type) { }

        public void PlayJingleCrossFade(eJINGLE _type, bool _loop = false, float _fadeTime = 0) { }

        public void PlayJingle(eJINGLE _type, bool _loop = false) { }

        public AudioPlayback PlayJingleFromName(string _cueSheet, string _cueName) { }

        public AudioPlayback PlayVoice(int _id, eVoiceType _type, int _index = 0) { }

        public AudioPlayback PlayVoice(int _id, eVoiceType _type, int _useCueIndex, int _index = 0) { }

        public AudioPlayback PlayVoice(string _cueSheet, string _cueName, int _index = 0) { }

        public void PlayVoiceByOuterSource(CriAtomSource _seSource, string _cueSheetName, string _cueName) { }

        public bool GetExistsVoice(int _unitId, eVoiceType _type, int _index = 0) { }

        public void PlayVoiceByOuterSource(CriAtomSource _voiceSource, int _unitId, eVoiceType _type, int _index = 0) { }

        public void PlaySpecialVoiceByOuterSource(CriAtomSource _voiceSource, int _groupId, int _groupUnitId, eVoiceType _type, int _index) { }

        public void PlaySpecialVoice(int _groupId, int _groupUnitId, eVoiceType _type, int _index) { }

        public bool GetGroupVoiceExits(int _groupId, int _groupUnitId, eVoiceType _type, int _index) { }

        public void PlayVoiceTitleCall() { }

        public bool GetExistsCueName(string _cueSheetName, string _cueName, SoundGroup _soundGroup) { }

        public void PlayVoiceTitleCallCustomize(int _customizeId) { }

        public bool IsExistCustomizeVoiceData(int _customizeId) { }

        public Action GetVoiceSplashCallAction() { }

        public Action GetRandomCharaCallAction(string acbPrefix)
        {
            //public Regex filterRegex;
            //public HashSet<int> ownedCharas;
            // internal bool < GetRandomCharaCallAction > b__1(string name) { }


            //public SoundManager<> 4__this;
            //public string cueSheet;
            //public string cueName;
            //internal void < GetRandomCharaCallAction > b__0() { }
        }

        public AudioPlayback PlayVoiceTwoParam(SoundManager.eVoiceType _type, int _unitId, int _index) { }

        public AudioPlayback PlayVoiceLove(int _charaId, int _level, int _index) { }

        public void StopVoice(AudioPlayback _playback, float _fadeOutSec = 0, Action _onStopped) { }

        public void StopVoice(float _fadeTime = 0, int _index = 0) { }

        public void PauseVoice(AudioPlayback _playback) { }

        public void ResumeVoice(AudioPlayback _playback) { }

        public bool IsPlayVoice(int _index = 0) { }

        public bool IsPlayVocieByOuterSource(CriAtomSource _source) { }

        public AudioPlayback PlaySe(eSE _type, bool _loop = false) { }

        public AudioPlayback PlaySe(string _cueName, bool _loop = false) { }

        public AudioPlayback PlaySeFromName(string _cueSheet, string _cueName, bool _loop = false) { }

        public AudioPlayback PlaySe3D(eSE _type, Vector3 _soundEmitPos, bool _loop = false) { }

        public AudioPlayback PlayToggleSe(bool _on) { }

        public void StopSe(List<string> _cueNameList, float _fadeTime = 0) { }

        public void StopSe(AudioPlayback _audioPlayback, float _fadeTime = 0) { }

        public void StopAllSe(float _fadeTime = 0) { }

        public void PlaySeByOuterSource(CriAtomSource _seSource, bool _loop = false, string _cueSheetName, string _cueName) { }

        public void PlaySeByOuterSource(CriAtomSource _seSource, eSE _seType, bool _loop = false) { }

        public bool IsPlaySE(int _channel) { }

        public void PlayStoryVoice(string _cueSheet, string _cueName, int _timeScale, Action _callbackPlayEnd, float _timeStretchRatio = 1) { }

        public void StopStory() { }

        public bool IsPlayingStory() { }

        public void LoadStoryVoice(string _keyName, string _acbName, string _awbName = "") { }

        public bool IsLoadStoryCueSheet(string _cueName) { }

        public void ResetPlayStoryCroutine() { }

        public void SetStoryVoiceEffect(string _effectCategory, float _value) { }

        public void SetStorySeEffect(string _effectCategory, float _value) { }

        public AudioPlayback PlayEnv(string _cueName, bool _loop = false) { }

        public AudioPlayback PlayEnv(string _cueSheet, string _cueName, bool _loop = false) { }

        public void StopEnv(int _trgIndex, float _fadetime = 0) { }

        public bool IsPlayEnv(string _cueSheet, string _cueName) { }

        public void PauseEnv(bool _isPause = true, int _channel = 0, float _fadeTime = 0) { }

        public void UpdateEnvChannelVolume(float _volume, int _channel, float _fadeTime = 0) { }

        public void PlaySingleChannelEnv(string _cueName) { }

        public void StopSingleChannelEnv() { }

        public void SaveAndPauseSingleChannelEnv() { }

        public void RestoreAndPlaySingleChannelEnv() { }

        public void UpdateVolume_Bgm(float _level, bool _mute) { }

        public void UpdateVolume_Se(float _level, bool _mute) { }

        public void UpdateVolume_Voice(float _level, bool _mute) { }

        public void SaveSoundParam() { }

        public bool CheckIsResidentCueSheet(string _cueSheet) { }

        public void RemoveCueSheet(string _cueSheet) { }

        public void RemoveAllCueSheet(string[] _ignoreRemoveCueSheetList) { }

        public void RemoveAllVoiceCueSheet() { }

        public void RemoveAllCueSheetIgnoreLastPlayed(string[] _ignoreRemoveCueSheetList) { }

        public void SetSoundSpeed(float _speed) { }

        public void EnableSoundListener(Vector3 _listenerPos) { }

        public void DisableSoundListener() { }

        public void Set3dListenerPos(Vector3 _listenerPos) { }

        public void SetAisacControl(SoundGroup _group, int _idx, string _controlName, float _controlValue) { }

        public void SetSelectorLabel(SoundGroup _group, int _index, string _selector, string _label) { }

        public void SetNextSequenceBlockIndex(AudioPlayback _playback, int _sequenceBlockIndex) { }

        private AudioPlayback playBgm(string _cueSheet, string _cueName, int _bgmId) { }

        private AudioPlayback playBgm(string _cueSheet, string _cueName, int _bgmId, float _fadeTime, bool _loop, float _offsetTime, bool _isSameBgmPlay, float _startTime) { }

        private AudioPlayback playBgmCrossFade(string _cueName, float _fadeOutTime, float _fadeInTime, float _offsetTime) { }

        private AudioPlayback playBgmCrossFade(string _cueSheet, string _cueName, float _fadeOutTime, float _fadeInTime, float _offsetTime, float _startTime, bool _loop) { }

        private AudioPlayback resumePlayBgmCrossFade(float _fadeOutTime, float _fadeInTime, float _offsetTime) { }

        private AudioPlayback playActionCue(AudioPlayback _playBack, string _cueSheet, string _cueName) { }

        private AudioPlayback playVoice(SoundManager.eVoiceType _type, int _useCueIndex, int _unitId, int _index, bool _loop = false) { }

        private AudioPlayback playVoice(int _useVoiceIndex, string _cueSheet, string _cueName, float _timeStretchRatio = 1) { }

        private void refUnitVoiceCueSheetParam(SoundManager.eVoiceType _type, int _unitId, int _index, ref string _cueSheet, ref string _cueName) { }

        private void refUnitSpecialVoiceCueSheetParam(SoundManager.eVoiceType _type, int _groupId, int _groupUnitId, int _index, ref string _cueSheet, ref string _cueName) { }

        private AudioPlayback playSe(string _cueSheet, string _cueName, bool _loop) { }

        private AudioPlayback playSe3D(string _cueSheetname, string _cueName, bool _loop, Vector3 _soundEmitPos) { }

        private AudioPlayback playJingle(string _cueSheet, string _cueName, bool _loop, float _fadeTime) { }

        private void playSoundByOuterSource(CriAtomSource _soundSource, string _cueSheet, string _cueName, string _subFolder, bool _loop) { }

        private AudioPlayback playEnv(string _cueSheet, bool _loop) { }

        private AudioPlayback playEnv(string _cueSheet, string _cueName, bool _loop) { }

        private IEnumerator checkPlayEndStoryVoice(int _timeScale) { }

        private void addCueSheet(string _cueSheet, string _subFolder) { }

        private void removeCueSheet(string _cueSheet) { }

        private void forceRemoveAllCueSheet() { }

        private bool checkCueSheetArray(string _cueSheet, string[] _cueSheetArray) { }

        private void initializeSoundSourceByOuterSource(CriAtomSource _source, string _cueSheetName, string _cueName, string _subFolder) { }

        private void setSoundEffect(string _categoryName, string _aisacName, float _value) { }

        private void setAisacControl(SoundGroup _group, int _idx, string _controlName, float _controlValue) { }

        private staticSoundParam searchSoundParam(eBGM _bgm) { }

        private SoundParam getSoundParam(eSE _type) { }

        private static SoundParam searchSoundParam(eJINGLE _jingle) { }

        private static SoundParam searchSoundParam(eSEPartial _se) { }

        private static SoundParam searchSoundParamBySeCueName(string _cueName) { }

        private static eSEPartial searchSeEnumBySeCueName(string _cueName) { }

        private static string searchCueSheetName(eJINGLE _jingle) { }

        private static string searchCueSheetName(eSEPartial _se) { }

        public SoundManager() { }

        static SoundManager() { }

        public class SoundParam
        {
            public string CueSheetName { get; set; }
            public string CueName { get; set; }

            public SoundParam(string _cueSheetName, string _cueName)
            {
                CueSheetName = _cueSheetName;
                CueName = _cueName;
            }
        }
        public class VoiceCueParam
        {
            public string CueSheetNameFormat { get; set; }
            public string CueNameFormat { get; set; }
            public VoiceCueParam(string _cueSheetNameFormat, string _cueNameFormat)
            {
                CueSheetNameFormat = _cueSheetNameFormat;
                CueNameFormat = _cueNameFormat;
            }
        }
        public enum eVoiceType
        {
            TITLE_PREIN = 0,
            TITLE_CUSTOMIZE = 1,
            MYPAGE = 2,
            GACHA = 3,
            LOVE = 4,
            DETAIL = 5,
            RARITY = 6,
            ATTACK = 7,
            ATTACK_MODE_CHANGE = 8,
            DAMAGE = 9,
            DAMAGE_MODE_CHANGE = 10,
            RETIRE = 11,
            UNION_BURST = 12,
            SKILL = 13,
            SP_SKILL = 14,
            SUB_UNION_BURST = 15,
            WAVE_START = 16,
            WAVE_START_FOR_MULTI = 17,
            NEXT_WAVE = 18,
            NEXT_WAVE_FOR_MULTI = 19,
            LAST_WAVE = 20,
            LAST_WAVE_FOR_MULTI = 21,
            WIN = 22,
            LOSE = 23,
            APPLAUD = 24,
            APPLAUD_MODE_CHANGE = 25,
            APPLAUD_FOR_MULTI = 26,
            THANKS = 27,
            THANKS_MODE_CHANGE = 28,
            THANKS_FOR_MULTI = 29,
            BATTLE_START = 30,
            BATTLE_RESULT_WIN = 31,
            SPECIAL_BATTLE_START = 32,
            SPECIAL_CUT_IN = 33,
            SPECIAL_WAVE_START = 34,
            SPECIAL_NEXT_WAVE = 35,
            SPECIAL_LAST_WAVE = 36,
            SPECIAL_CLEAR_WIN = 37,
            SPECIAL_WIN = 38,
            SPECIAL_CLOSE_GAME = 39,
            SPECIAL_LOSE = 40,
            SPECIAL_APPLAUD = 41,
            SPECIAL_THANKS = 42,
            NAVI = 43,
            LOGIN_BONUS = 44,
            STORY = 45,
            CUT_IN = 46,
            CUT_IN_MODE_CHANGE = 47,
            OTHER = 48,
            EVENT_NAVI = 49,
            ROOM_AUTO = 50,
            ROOM_TAP = 51,
            ROOM_TIME = 52,
            ROOM_ITEM = 53,
            ROOM_APPEAR = 54,
            SPECIAL_LOGIN = 55,
            BIRTH_DAY = 56,
            VOTE_RESULT = 57,
            MINIGAME = 58,
            CLAN_STAMP = 59,
            EVENT_NAVI_SUB = 60,
            CARAVAN_COIN_SHOP = 61,
            CARAVAN_JOY = 62,
            CARAVAN_SNEEZE = 63,
        }
    }
}