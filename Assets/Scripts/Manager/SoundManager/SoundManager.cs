using System.Collections.Generic;
using System;
using System.Collections;

public partial class SoundManager : ManagerSingleton<SoundManager>
{
	// Fields
	public static readonly Dictionary<eBGM, SoundManager.SoundParam> BGM_PARAM_DICT; // 0x0
	private static readonly Dictionary<eSE, SoundManager.SoundParam> SE_SOUND_PARAM_DICT; // 0x8
	private Dictionary<eSE, eSEPartial> PARAM_SEPARTIAL_TYPE_DICT; // 0xA8
	public const float CUTE_RATE = 10;
	public const int DEFAULT_RATE = 7;
	private const int MAX_VOICE_NUM = 2;
	public const float BGM_COMMON_FADE_TIME = 0.7f;
	public const float BGM_JINGLE_WAIT_TIME = 0.5f;
	public const int VIEW_BGM_DEFAULT_CHANNEL = 0;
	public static readonly string PREINSTALL_CUESHEET; // 0x10
	public static readonly string SE_COMMON_CUESHEET; // 0x18
	public static readonly string SE_BATTLE_CUESHEET; // 0x20
	public static readonly string SE_ROOM_CUESHEET; // 0x28
	public static readonly string SE_ADV_STEP; // 0x30
	private static readonly string[] RESIDENT_CUESHEET; // 0x38
	private static readonly string VOICE_CATEGORY; // 0x40
	private static readonly string SE_EFFECT_CATEGORY; // 0x48
	private static readonly string SOUND_PLAY_SPEED_CATEGORY; // 0x50
	public const string VOICE_BTL_CUESHEET_FORMAT = "vo_btl_{0}";
	public const string SE_CUT_IN_CUESHEET_FORMAT = "se_cutin_{0}";
	public const string SE_BTL_CUESHEET_FORMAT = "se_btl_{0}";
	public const string SE_MINIGAME_CUESHEET_FORMAT = "se_minigame_{0}";
	public const int SE_BTL_CUESHEET_VARIATION_MAX = 3;
	public const string VOICE_BTG_CUESHEET_FORMAT = "vo_btg_{0}";
	public const string STORY_VOICE_CUE_SHEET_NAME_PREFIX = "v/t/vo_adv_";
	public const string EVENT_TOP_NAVI_VOICE_NAME_PREFIX = "v/vo_enavi_";
	public const int EVENT_TOP_NAVI_VOICE_NAME_NUMBER_LENGTH = 6;
	private static readonly string VOICE_CUESHEET_PREFIX; // 0x58
	private static readonly string VOICE_CMN_CUESHEET_FORMAT; // 0x60
	private static readonly string VOICE_NABI_CUESHEET_FORMAT; // 0x68
	private static readonly string VOICE_TITLE_CALL_CUESHEET_PREFIX; // 0x70
	private static readonly string VOICE_SPLASH_CALL_CUESHEET_PREFIX; // 0x78
	private const float DEFAULT_STOP_ENV_FADE_DURATION = 0.3f;
	public static readonly string VOICE_ROOM_CUESHEET_FORMAT; // 0x80
	public const string VO_CNM_PREFIX = "v/vo_cmn_";
	public const int VO_CNM_CHAR_ID_LENGTH = 4;
	private static readonly Dictionary<SoundManager.eVoiceType, SoundManager.VoiceCueParam> VOICE_CUEDATA; // 0x88
	private static readonly Dictionary<SoundGroup, string[]> ASR_BUS_DATA; // 0x90
	private HashSet<string> <CommonBgmAssetHashSet>k__BackingField; // 0xC8
	public Dictionary<int, List<string>> EventUsedBgmAssetDictionary; // 0xD0
	private AudioManager cuteAudioManager; // 0xD8
	private Action callbackPlayStoryEnd; // 0xE0
	private IEnumerator playStoryCoroutine; // 0xE8
	private AudioPlayback lastPlayedBgm; // 0xF0
	private AudioPlayback lastPlayedJingle; // 0x120
	private AudioPlayback lastPlayedVoice; // 0x150
	private int singleChannelEnvChannel; // 0x180
	private string singleChannelEnvCueName; // 0x188
	private string singleChannelEnvSavedCueName; // 0x190
	private static readonly Dictionary<eJINGLE, SoundManager.SoundParam> JINGLE_PARAM_DICT; // 0x98
	private static readonly Dictionary<eSEPartial, SoundManager.SoundParam> SE_PARAM_DICT; // 0xA0
	private static readonly Dictionary<string, eSEPartial> SE_CUENAME_DICT; // 0xA8

	// Properties
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

	// Methods

	// RVA: 0x33536C4 Offset: 0x33536C4 VA: 0x33536C4
	public static SoundManager.VoiceCueParam GetVoiceCueParam(SoundManager.eVoiceType _voiceType) { }


	// RVA: 0x335380C Offset: 0x335380C VA: 0x335380C
	public AudioPlayback get_LastPlayedBgm() { }

	[IteratorStateMachine(typeof(SoundManager.<Start>d__92))]
	// RVA: 0x3353820 Offset: 0x3353820 VA: 0x3353820
	private IEnumerator Start() { }

	// RVA: 0x33538CC Offset: 0x33538CC VA: 0x33538CC Slot: 7
	protected override void onInit() { }

	// RVA: 0x3353B0C Offset: 0x3353B0C VA: 0x3353B0C Slot: 8
	protected override void onDestroy() { }

	// RVA: 0x3353BC0 Offset: 0x3353BC0 VA: 0x3353BC0
	public void SetupBgmUsedPosition(bool _isBgmUsedPositionResourceDownloaded) { }

	// RVA: 0x3353DF8 Offset: 0x3353DF8 VA: 0x3353DF8
	public AudioPlayback PlayViewBGM(eBGM _type) { }

	// RVA: 0x335406C Offset: 0x335406C VA: 0x335406C
	public AudioPlayback PlayBGM(string _cueName, float _fadeTime = 0, int _channel = 0, bool _loop = true, float _offsetTime = 0, bool _isSameBgmPlay = false, float _startTime = 0) { }

	// RVA: 0x33541D0 Offset: 0x33541D0 VA: 0x33541D0
	public AudioPlayback PlayBGM(string _cueSheet, string _cueName, float _fadeTime = 0, int _channel = 0, bool _loop = true, float _offsetTime = 0, bool _isSameBgmPlay = false, float _startTime = 0) { }

	// RVA: 0x335420C Offset: 0x335420C VA: 0x335420C
	public AudioPlayback PlayBGMCrossFade(string _cueName, float _fadeOutTime, float _fadeInTime = 0, float _offsetTime = 0) { }

	// RVA: 0x335433C Offset: 0x335433C VA: 0x335433C
	public AudioPlayback PlayBGMCrossFade(string _cueSheet, string _cueName, float _fadeOutTime, float _fadeInTime = 0, float _offsetTime = 0, float _startTime = 0, bool _loop = true) { }

	// RVA: 0x3354500 Offset: 0x3354500 VA: 0x3354500
	public AudioPlayback ResumeBGMCrossFade(float _fadeOutTime, float _fadeInTime = 0, float _offsetTime = 0) { }

	// RVA: 0x3354628 Offset: 0x3354628 VA: 0x3354628
	public AudioPlayback PlayActionCue(AudioPlayback _playBack, string _cueSheet, string _cueName) { }

	// RVA: 0x33546D8 Offset: 0x33546D8 VA: 0x33546D8
	public void StopBgm(float _fadeOutTime = 0) { }

	// RVA: 0x3354704 Offset: 0x3354704 VA: 0x3354704
	public void StopBgm(AudioPlayback _audioPlayback, Action _callback) { }

	// RVA: 0x3354748 Offset: 0x3354748 VA: 0x3354748
	public void PauseBgm(bool _isPause = true, int _channel = 0, float _fadeTime = 0) { }

	// RVA: 0x3354770 Offset: 0x3354770 VA: 0x3354770
	public void PauseBgmAll(bool _isPause = true, float _fadeTime = 0) { }

	// RVA: 0x3354798 Offset: 0x3354798 VA: 0x3354798
	public void StopFadeBgm(int _channel = 0, float _fadeTime = 0.5, Action _callback) { }

	// RVA: 0x33547C4 Offset: 0x33547C4 VA: 0x33547C4
	public void StopFadeAllBgm(float _fadeTime = 0.5) { }

	// RVA: 0x33547EC Offset: 0x33547EC VA: 0x33547EC
	public void UpdateBgmChannelVolume(float _volume, int _channel = -1) { }

	// RVA: 0x3354838 Offset: 0x3354838 VA: 0x3354838
	public SoundManager.SoundParam GetBgmParam(eBGM _bgm) { }

	// RVA: 0x33548E4 Offset: 0x33548E4 VA: 0x33548E4
	public CuePair GetBgmCuePair(eBGM _bgm) { }

	// RVA: 0x3354918 Offset: 0x3354918 VA: 0x3354918
	public bool IsSameBgmSoundParam(eBGM _bgm, string _sheet, string _name) { }

	// RVA: 0x33549D8 Offset: 0x33549D8 VA: 0x33549D8
	public bool IsSameBgmSoundParam(string _sheet1, string _name1, string _sheet2, string _name2) { }

	// RVA: 0x3354A24 Offset: 0x3354A24 VA: 0x3354A24
	public bool IsPlayBgm(int _channel) { }

	// RVA: 0x3354A4C Offset: 0x3354A4C VA: 0x3354A4C
	public static SoundManager.SoundParam GetJingleParam(eJINGLE _type) { }

	// RVA: 0x3354BB8 Offset: 0x3354BB8 VA: 0x3354BB8
	public void PlayJingleCrossFade(eJINGLE _type, bool _loop = false, float _fadeTime = 0) { }

	// RVA: 0x3354D30 Offset: 0x3354D30 VA: 0x3354D30
	public void PlayJingle(eJINGLE _type, bool _loop = false) { }

	// RVA: 0x3354E0C Offset: 0x3354E0C VA: 0x3354E0C
	public AudioPlayback PlayJingleFromName(string _cueSheet, string _cueName) { }

	// RVA: 0x3354E98 Offset: 0x3354E98 VA: 0x3354E98
	public AudioPlayback PlayVoice(int _id, SoundManager.eVoiceType _type, int _index = 0) { }

	// RVA: 0x3354F68 Offset: 0x3354F68 VA: 0x3354F68
	public AudioPlayback PlayVoice(int _id, SoundManager.eVoiceType _type, int _useCueIndex, int _index = 0) { }

	// RVA: 0x3354FB8 Offset: 0x3354FB8 VA: 0x3354FB8
	public AudioPlayback PlayVoice(string _cueSheet, string _cueName, int _index = 0) { }

	// RVA: 0x3355114 Offset: 0x3355114 VA: 0x3355114
	public void PlayVoiceByOuterSource(CriAtomSource _seSource, string _cueSheetName, string _cueName) { }

	// RVA: 0x3355280 Offset: 0x3355280 VA: 0x3355280
	public bool GetExistsVoice(int _unitId, SoundManager.eVoiceType _type, int _index = 0) { }

	// RVA: 0x3355720 Offset: 0x3355720 VA: 0x3355720
	public void PlayVoiceByOuterSource(CriAtomSource _voiceSource, int _unitId, SoundManager.eVoiceType _type, int _index = 0) { }

	// RVA: 0x33557C8 Offset: 0x33557C8 VA: 0x33557C8
	public void PlaySpecialVoiceByOuterSource(CriAtomSource _voiceSource, int _groupId, int _groupUnitId, SoundManager.eVoiceType _type, int _index) { }

	// RVA: 0x33559E8 Offset: 0x33559E8 VA: 0x33559E8
	public void PlaySpecialVoice(int _groupId, int _groupUnitId, SoundManager.eVoiceType _type, int _index) { }

	// RVA: 0x3355A44 Offset: 0x3355A44 VA: 0x3355A44
	public bool GetGroupVoiceExits(int _groupId, int _groupUnitId, SoundManager.eVoiceType _type, int _index) { }

	// RVA: 0x3355A98 Offset: 0x3355A98 VA: 0x3355A98
	public void PlayVoiceTitleCall() { }

	// RVA: 0x3355424 Offset: 0x3355424 VA: 0x3355424
	public bool GetExistsCueName(string _cueSheetName, string _cueName, SoundGroup _soundGroup) { }

	// RVA: 0x3356398 Offset: 0x3356398 VA: 0x3356398
	public void PlayVoiceTitleCallCustomize(int _customizeId) { }

	// RVA: 0x3356814 Offset: 0x3356814 VA: 0x3356814
	public bool IsExistCustomizeVoiceData(int _customizeId) { }

	// RVA: 0x33569A0 Offset: 0x33569A0 VA: 0x33569A0
	public Action GetVoiceSplashCallAction() { }

	// RVA: 0x3355B98 Offset: 0x3355B98 VA: 0x3355B98
	public Action GetRandomCharaCallAction(string acbPrefix) { }

	// RVA: 0x3356A1C Offset: 0x3356A1C VA: 0x3356A1C
	public AudioPlayback PlayVoiceTwoParam(SoundManager.eVoiceType _type, int _unitId, int _index) { }

	// RVA: 0x3356B80 Offset: 0x3356B80 VA: 0x3356B80
	public AudioPlayback PlayVoiceLove(int _charaId, int _level, int _index) { }

	// RVA: 0x3356CFC Offset: 0x3356CFC VA: 0x3356CFC
	public void StopVoice(AudioPlayback _playback, float _fadeOutSec = 0, Action _onStopped) { }

	// RVA: 0x3356D3C Offset: 0x3356D3C VA: 0x3356D3C
	public void StopVoice(float _fadeTime = 0, int _index = 0) { }

	// RVA: 0x3356D68 Offset: 0x3356D68 VA: 0x3356D68
	public void PauseVoice(AudioPlayback _playback) { }

	// RVA: 0x3356DB0 Offset: 0x3356DB0 VA: 0x3356DB0
	public void ResumeVoice(AudioPlayback _playback) { }

	// RVA: 0x3356DF8 Offset: 0x3356DF8 VA: 0x3356DF8
	public bool IsPlayVoice(int _index = 0) { }

	// RVA: 0x3356E20 Offset: 0x3356E20 VA: 0x3356E20
	public bool IsPlayVocieByOuterSource(CriAtomSource _source) { }

	// RVA: 0x3356EB8 Offset: 0x3356EB8 VA: 0x3356EB8
	public AudioPlayback PlaySe(eSE _type, bool _loop = false) { }

	// RVA: 0x33570EC Offset: 0x33570EC VA: 0x33570EC
	public AudioPlayback PlaySe(string _cueName, bool _loop = false) { }

	// RVA: 0x3357314 Offset: 0x3357314 VA: 0x3357314
	public AudioPlayback PlaySeFromName(string _cueSheet, string _cueName, bool _loop = false) { }

	// RVA: 0x3357350 Offset: 0x3357350 VA: 0x3357350
	public AudioPlayback PlaySe3D(eSE _type, Vector3 _soundEmitPos, bool _loop = false) { }

	// RVA: 0x3357524 Offset: 0x3357524 VA: 0x3357524
	public AudioPlayback PlayToggleSe(bool _on) { }

	// RVA: 0x3357578 Offset: 0x3357578 VA: 0x3357578
	public void StopSe(List<string> _cueNameList, float _fadeTime = 0) { }

	// RVA: 0x33575A0 Offset: 0x33575A0 VA: 0x33575A0
	public void StopSe(AudioPlayback _audioPlayback, float _fadeTime = 0) { }

	// RVA: 0x33575E4 Offset: 0x33575E4 VA: 0x33575E4
	public void StopAllSe(float _fadeTime = 0) { }

	// RVA: 0x335760C Offset: 0x335760C VA: 0x335760C
	public void PlaySeByOuterSource(CriAtomSource _seSource, bool _loop = false, string _cueSheetName, string _cueName) { }

	// RVA: 0x3357690 Offset: 0x3357690 VA: 0x3357690
	public void PlaySeByOuterSource(CriAtomSource _seSource, eSE _seType, bool _loop = false) { }

	// RVA: 0x3357734 Offset: 0x3357734 VA: 0x3357734
	public bool IsPlaySE(int _channel) { }

	// RVA: 0x335775C Offset: 0x335775C VA: 0x335775C
	public void PlayStoryVoice(string _cueSheet, string _cueName, int _timeScale, Action _callbackPlayEnd, float _timeStretchRatio = 1) { }

	// RVA: 0x33578EC Offset: 0x33578EC VA: 0x33578EC
	public void StopStory() { }

	// RVA: 0x3357950 Offset: 0x3357950 VA: 0x3357950
	public bool IsPlayingStory() { }

	// RVA: 0x3357978 Offset: 0x3357978 VA: 0x3357978
	public void LoadStoryVoice(string _keyName, string _acbName, string _awbName = "") { }

	// RVA: 0x33579E0 Offset: 0x33579E0 VA: 0x33579E0
	public bool IsLoadStoryCueSheet(string _cueName) { }

	// RVA: 0x335781C Offset: 0x335781C VA: 0x335781C
	public void ResetPlayStoryCroutine() { }

	// RVA: 0x3357A00 Offset: 0x3357A00 VA: 0x3357A00
	public void SetStoryVoiceEffect(string _effectCategory, float _value) { }

	// RVA: 0x3357A90 Offset: 0x3357A90 VA: 0x3357A90
	public void SetStorySeEffect(string _effectCategory, float _value) { }

	// RVA: 0x3357B10 Offset: 0x3357B10 VA: 0x3357B10
	public AudioPlayback PlayEnv(string _cueName, bool _loop = false) { }

	// RVA: 0x3357BB8 Offset: 0x3357BB8 VA: 0x3357BB8
	public AudioPlayback PlayEnv(string _cueSheet, string _cueName, bool _loop = false) { }

	// RVA: 0x3357C60 Offset: 0x3357C60 VA: 0x3357C60
	public void StopEnv(int _trgIndex, float _fadetime = 0) { }

	// RVA: 0x3357C8C Offset: 0x3357C8C VA: 0x3357C8C
	public bool IsPlayEnv(string _cueSheet, string _cueName) { }

	// RVA: 0x3357CF0 Offset: 0x3357CF0 VA: 0x3357CF0
	public void PauseEnv(bool _isPause = true, int _channel = 0, float _fadeTime = 0) { }

	// RVA: 0x3357D18 Offset: 0x3357D18 VA: 0x3357D18
	public void UpdateEnvChannelVolume(float _volume, int _channel, float _fadeTime = 0) { }

	// RVA: 0x3357D40 Offset: 0x3357D40 VA: 0x3357D40
	public void PlaySingleChannelEnv(string _cueName) { }

	// RVA: 0x3357DFC Offset: 0x3357DFC VA: 0x3357DFC
	public void StopSingleChannelEnv() { }

	// RVA: 0x3357E84 Offset: 0x3357E84 VA: 0x3357E84
	public void SaveAndPauseSingleChannelEnv() { }

	// RVA: 0x3357F18 Offset: 0x3357F18 VA: 0x3357F18
	public void RestoreAndPlaySingleChannelEnv() { }

	// RVA: 0x3357FE4 Offset: 0x3357FE4 VA: 0x3357FE4
	public void UpdateVolume_Bgm(float _level, bool _mute) { }

	// RVA: 0x3358058 Offset: 0x3358058 VA: 0x3358058
	public void UpdateVolume_Se(float _level, bool _mute) { }

	// RVA: 0x33580CC Offset: 0x33580CC VA: 0x33580CC
	public void UpdateVolume_Voice(float _level, bool _mute) { }

	// RVA: 0x3358140 Offset: 0x3358140 VA: 0x3358140
	public void SaveSoundParam() { }

	// RVA: 0x3358204 Offset: 0x3358204 VA: 0x3358204
	public bool CheckIsResidentCueSheet(string _cueSheet) { }

	// RVA: 0x3358310 Offset: 0x3358310 VA: 0x3358310
	public void RemoveCueSheet(string _cueSheet) { }

	// RVA: 0x3358314 Offset: 0x3358314 VA: 0x3358314
	public void RemoveAllCueSheet(string[] _ignoreRemoveCueSheetList) { }

	// RVA: 0x335850C Offset: 0x335850C VA: 0x335850C
	public void RemoveAllVoiceCueSheet() { }

	// RVA: 0x33586F8 Offset: 0x33586F8 VA: 0x33586F8
	public void RemoveAllCueSheetIgnoreLastPlayed(string[] _ignoreRemoveCueSheetList) { }

	// RVA: 0x3358918 Offset: 0x3358918 VA: 0x3358918
	public void SetSoundSpeed(float _speed) { }

	// RVA: 0x33589AC Offset: 0x33589AC VA: 0x33589AC
	public void EnableSoundListener(Vector3 _listenerPos) { }

	// RVA: 0x3358A14 Offset: 0x3358A14 VA: 0x3358A14
	public void DisableSoundListener() { }

	// RVA: 0x3358A98 Offset: 0x3358A98 VA: 0x3358A98
	public void Set3dListenerPos(Vector3 _listenerPos) { }

	// RVA: 0x3358AB8 Offset: 0x3358AB8 VA: 0x3358AB8
	public void SetAisacControl(SoundGroup _group, int _idx, string _controlName, float _controlValue) { }

	// RVA: 0x3358AF8 Offset: 0x3358AF8 VA: 0x3358AF8
	public void SetSelectorLabel(SoundGroup _group, int _index, string _selector, string _label) { }

	// RVA: 0x3358B18 Offset: 0x3358B18 VA: 0x3358B18
	public void SetNextSequenceBlockIndex(AudioPlayback _playback, int _sequenceBlockIndex) { }

	// RVA: 0x3353F58 Offset: 0x3353F58 VA: 0x3353F58
	private AudioPlayback playBgm(string _cueSheet, string _cueName, int _bgmId) { }

	// RVA: 0x33540B8 Offset: 0x33540B8 VA: 0x33540B8
	private AudioPlayback playBgm(string _cueSheet, string _cueName, int _bgmId, float _fadeTime, bool _loop, float _offsetTime, bool _isSameBgmPlay, float _startTime) { }

	// RVA: 0x3354248 Offset: 0x3354248 VA: 0x3354248
	private AudioPlayback playBgmCrossFade(string _cueName, float _fadeOutTime, float _fadeInTime, float _offsetTime) { }

	// RVA: 0x3354378 Offset: 0x3354378 VA: 0x3354378
	private AudioPlayback playBgmCrossFade(string _cueSheet, string _cueName, float _fadeOutTime, float _fadeInTime, float _offsetTime, float _startTime, bool _loop) { }

	// RVA: 0x335453C Offset: 0x335453C VA: 0x335453C
	private AudioPlayback resumePlayBgmCrossFade(float _fadeOutTime, float _fadeInTime, float _offsetTime) { }

	[Conditional("CYG_DEBUG")]
	// RVA: 0x3358B58 Offset: 0x3358B58 VA: 0x3358B58
	private void dbg_checkBgmCueSheet(string _cueSheetName) { }

	// RVA: 0x3354678 Offset: 0x3354678 VA: 0x3354678
	private AudioPlayback playActionCue(AudioPlayback _playBack, string _cueSheet, string _cueName) { }

	// RVA: 0x3354EE8 Offset: 0x3354EE8 VA: 0x3354EE8
	private AudioPlayback playVoice(SoundManager.eVoiceType _type, int _useCueIndex, int _unitId, int _index, bool _loop = false) { }

	// RVA: 0x3355008 Offset: 0x3355008 VA: 0x3355008
	private AudioPlayback playVoice(int _useVoiceIndex, string _cueSheet, string _cueName, float _timeStretchRatio = 1) { }

	// RVA: 0x33552D0 Offset: 0x33552D0 VA: 0x33552D0
	private void refUnitVoiceCueSheetParam(SoundManager.eVoiceType _type, int _unitId, int _index, ref string _cueSheet, ref string _cueName) { }

	// RVA: 0x3355878 Offset: 0x3355878 VA: 0x3355878
	private void refUnitSpecialVoiceCueSheetParam(SoundManager.eVoiceType _type, int _groupId, int _groupUnitId, int _index, ref string _cueSheet, ref string _cueName) { }

	// RVA: 0x335703C Offset: 0x335703C VA: 0x335703C
	private AudioPlayback playSe(string _cueSheet, string _cueName, bool _loop) { }

	// RVA: 0x33573F4 Offset: 0x33573F4 VA: 0x33573F4
	private AudioPlayback playSe3D(string _cueSheetname, string _cueName, bool _loop, Vector3 _soundEmitPos) { }

	// RVA: 0x3354C78 Offset: 0x3354C78 VA: 0x3354C78
	private AudioPlayback playJingle(string _cueSheet, string _cueName, bool _loop, float _fadeTime) { }

	// RVA: 0x335518C Offset: 0x335518C VA: 0x335518C
	private void playSoundByOuterSource(CriAtomSource _soundSource, string _cueSheet, string _cueName, string _subFolder, bool _loop) { }

	// RVA: 0x3357B4C Offset: 0x3357B4C VA: 0x3357B4C
	private AudioPlayback playEnv(string _cueSheet, bool _loop) { }

	// RVA: 0x3357BF4 Offset: 0x3357BF4 VA: 0x3357BF4
	private AudioPlayback playEnv(string _cueSheet, string _cueName, bool _loop) { }

	[IteratorStateMachine(typeof(SoundManager.<checkPlayEndStoryVoice>d__204))]
	// RVA: 0x3357864 Offset: 0x3357864 VA: 0x3357864
	private IEnumerator checkPlayEndStoryVoice(int _timeScale) { }

	// RVA: 0x33579C0 Offset: 0x33579C0 VA: 0x33579C0
	private void addCueSheet(string _cueSheet, string _subFolder) { }

	// RVA: 0x3356304 Offset: 0x3356304 VA: 0x3356304
	private void removeCueSheet(string _cueSheet) { }

	// RVA: 0x3353B10 Offset: 0x3353B10 VA: 0x3353B10
	private void forceRemoveAllCueSheet() { }

	// RVA: 0x3358270 Offset: 0x3358270 VA: 0x3358270
	private bool checkCueSheetArray(string _cueSheet, string[] _cueSheetArray) { }

	// RVA: 0x3358B5C Offset: 0x3358B5C VA: 0x3358B5C
	private void initializeSoundSourceByOuterSource(CriAtomSource _source, string _cueSheetName, string _cueName, string _subFolder) { }

	// RVA: 0x3357A80 Offset: 0x3357A80 VA: 0x3357A80
	private void setSoundEffect(string _categoryName, string _aisacName, float _value) { }

	// RVA: 0x3358AD8 Offset: 0x3358AD8 VA: 0x3358AD8
	private void setAisacControl(SoundGroup _group, int _idx, string _controlName, float _controlValue) { }

	// RVA: 0x3353EAC Offset: 0x3353EAC VA: 0x3353EAC
	private static SoundManager.SoundParam searchSoundParam(eBGM _bgm) { }

	// RVA: 0x3356F34 Offset: 0x3356F34 VA: 0x3356F34
	private SoundManager.SoundParam getSoundParam(eSE _type) { }

	[Conditional("CYG_DEBUG")]
	// RVA: 0x3358C38 Offset: 0x3358C38 VA: 0x3358C38
	public void Dbg_AddSoundLog(string _cueName, string _cueSheet, string _subFolder) { }

	// RVA: 0x3354B2C Offset: 0x3354B2C VA: 0x3354B2C
	private static SoundManager.SoundParam searchSoundParam(eJINGLE _jingle) { }

	// RVA: 0x3357274 Offset: 0x3357274 VA: 0x3357274
	private static SoundManager.SoundParam searchSoundParam(eSEPartial _se) { }

	// RVA: 0x3358C3C Offset: 0x3358C3C VA: 0x3358C3C
	private static SoundManager.SoundParam searchSoundParamBySeCueName(string _cueName) { }

	// RVA: 0x33571CC Offset: 0x33571CC VA: 0x33571CC
	private static eSEPartial searchSeEnumBySeCueName(string _cueName) { }

	// RVA: 0x3358D00 Offset: 0x3358D00 VA: 0x3358D00
	private static string searchCueSheetName(eJINGLE _jingle) { }

	// RVA: 0x3358D88 Offset: 0x3358D88 VA: 0x3358D88
	private static string searchCueSheetName(eSEPartial _se) { }

	// RVA: 0x3358E10 Offset: 0x3358E10 VA: 0x3358E10
	public void SoundManager() { }

	// RVA: 0x335999C Offset: 0x335999C VA: 0x335999C
	private static void SoundManager() { }
}
public static class SoundDefine 
{
    public const string STORY_COMMAND_BGM_CUE_SHEET_HEADER = "bgm_";
}