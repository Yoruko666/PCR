using System;
using System.Collections.Generic;
using UnityEngine;
using Elements.Battle;

namespace Elements 
{
    public class UnitUiCtrl : SingletonMonoBehaviour<UnitUiCtrl>, ISingletonField
    {
        private static readonly string BTN_ON_SPRITE_NAME; // 0x0
        private static readonly string BTN_OFF_SPRITE_NAME; // 0x8
        private static readonly string SMART_AUTO_BTN_ON_SPRITE_NAME; // 0x10
        private static readonly string SMART_AUTO_BTN_OFF_SPRITE_NAME; // 0x18
        private static readonly string BTN_ON_SPRITE_NAME_SPEED; // 0x20
        private static readonly string BTN_OFF_SPRITE_NAME_SPEED; // 0x28
        private static readonly string BTN_ON_SPRITE_NAME_SPEED_QUADRUPLE; // 0x30
        private const float NOT_VISIBLE_Y = 20000;
        private const float SKILL_POP_UP_OFFSET = 0.07f;
        [SerializeField]
        private CustomUIButton gameSpeedButton; // 0x18
        [SerializeField]
        private UISprite gameSpeedButtonBg; // 0x20
        [SerializeField]
        private GameObject gameSpeedButtonEffect; // 0x28
        [SerializeField]
        private CustomUIButton skillModeButton; // 0x30
        [SerializeField]
        private UISprite skillModeButtonBg; // 0x38
        [SerializeField]
        private GameObject skillModeButtonEffect; // 0x40
        [SerializeField]
        private CustomUIButton allSetModeButton; // 0x48
        [SerializeField]
        private UISprite allSetModeButtonBg; // 0x50
        [SerializeField]
        private GameObject allSetModeButtonEffect; // 0x58
        [SerializeField]
        private CustomUIButton skipBattleButton; // 0x60
        private SaveDataManager saveDataManager; // 0x68
        [SerializeField]
        private UITexture[] UnitIconPnls; // 0x70
        [SerializeField]
        private UISlider[] lifeGaugeSliderArray; // 0x78
        [SerializeField]
        private UISlider[] lifeGaugeBgSliderArray; // 0x80
        [SerializeField]
        private UISlider[] lifeGaugeBlackSliderArray; // 0x88
        [SerializeField]
        private UISlider[] skillGaugeSliderArray; // 0x90
        [SerializeField]
        private AbromalStateIconController[] AbnormalStateIconControllers; // 0x98
        [SerializeField]
        private GameObject[] skillEnableEffects; // 0xA0
        [SerializeField]
        private GameObject[] skillReserveEffects; // 0xA8
        [SerializeField]
        private UISprite[] FrameSprites; // 0xB0
        [SerializeField]
        private CustomUIButton[] buttonArray; // 0xC8
        [SerializeField]
        private CustomUIButton guestButton; // 0xD0
        [SerializeField]
        private PartsStarControl[] starIconCtrls; // 0xD8
        [SerializeField]
        private PartsEquipStatusIcon[] equipStatusIconCtrls; // 0xE0
        [SerializeField]
        private UISprite[] talentIcons; // 0xE8
        [SerializeField]
        private GameObject[] effectiveIcons; // 0xF0
        [SerializeField]
        private Animator[] shakeAnimations; // 0xF8
        [SerializeField]
        private Animator guestShakeAnimation; // 0x100
        [SerializeField]
        private Animator[] skillReserveAnimations; // 0x108
        [SerializeField]
        private Animator guestSkillReserveAnimation; // 0x110
        [SerializeField]
        private FullScreenFade fullScreenFade; // 0x118
        [SerializeField]
        private GameObject skillReserveExecuteEffectBaseObj; // 0x130
        private Coroutine syncSkillReserveAnimationTimeCoroutine; // 0x138
        private const int UNIT_MAX_NUM = 5;
        private const int STATE_ICON_NUM = 4;
	    private static readonly Color ENABLE_COLOR; // 0x38
        private static readonly Color DESABLE_COLOR; // 0x48
        private static readonly Color LIGHT_DESABLE_COLOR; // 0x58
        private static readonly Vector3 POSITION_STATE_ICON_CONTROLLER_TRANSFORM_LOCAL; // 0x68
        private static readonly Vector3 SCALE_ABNOMAL_STATE_ICON_CONTROLLER_TRANSFORM_LOCAL; // 0x74
        private IBattleManagerForUnitUiCtrl battleManager; // 0x190
        private int myViewerId; // 0x198
        private bool isDisableUpdate; // 0x19C
        private ViewManager viewManager; // 0x1A0
        private const int NO_SELECTED_SKILL = 0;
        private int selectedSkillId; // 0x1A8
        private List<UnitCtrl> enemyListForDefenseReplay;
	    private float battleDeltaTime;
	    private StaticSingletonTree<UnitUiCtrl> singletonTree; // 0x1D0
        private IBattleTimeScaleForUnitUiCtrl battleTimeScale; 
        private bool guestIsUnit; // 0x1E8
        private bool guestUnitDead; // 0x1E9
        private bool guestSkillReady; // 0x1EA
	    private float guestLifeAmount; // 0x1EC
        private float guestMaxLifeAmount; // 0x1F0
        [SerializeField]
        private UITexture guestUnitIconPnl; // 0x1F8
        [SerializeField]
        private UISlider guestLifeGaugeSlider; // 0x200
        [SerializeField]
        private UISlider guestLifeGaugeBgSlider; // 0x208
        [SerializeField]
        private UISlider guestLifeGaugeBlackSlider; // 0x210
        [SerializeField]
        private UISlider guestSkillGaugeSlider; // 0x218
        private AbromalStateIconController guestAbnormalStateIconController; // 0x220
        [SerializeField]
        private GameObject guestSkillEnableEffect; // 0x228
        [SerializeField]
        private GameObject guestSkillReserveEffect; // 0x230
        [SerializeField]
        private UISprite guestFrameSprite; // 0x238
        [SerializeField]
        private Transform unitBaseTransform; // 0x240
        [SerializeField]
        private UIGrid buttonLayoutGrid; // 0x248
        [SerializeField]
        private Transform talentBonusIconParentTransform; // 0x250
        private GameObject talentBonusObject; // 0x258
        private bool autoModeFlagBackup; // 0x260
        private bool allSetModeFlagBackup; // 0x261
        private bool speedModeFlagBackup; // 0x262
        private bool speedQuadrupleFlagBackup; // 0x263
        private const int GUEST_POSITION = 85;
        private SpineNormalEffect skillOnObj { get; set; }
        private GameObject skillOnPrefab { get; set; }
        private ParticleSystem skillReserveExecParticle { get; set; }
        private GameObject skillReserveExecParticlePrefab { get; set; }
        public UnitCtrl[] UnitCtrls { get; set; }
        public bool IsAutoMode { get; set; }
        public bool IsEnabledChangeAutoMode { get; set; }
        private bool isSpeedMode { get; set; }
        public bool IsAllSetMode { get; set; }
        private bool isBattleSpeedQuadruple { get; set; }
        public bool IsUnitCreated { get; set; }
        private bool[] isUnits { get; set; }
        private bool[] unitDeads { get; set; }
        private Dictionary<int, UnitParameter> m_pUnitParameters { get; set; }
        public bool EnableTap { get; set; }
        private UnitCtrl skillExeUnit { get; set; }
        private bool[] skillReadys { get; set; }
        public UnitSkillReserve SkillReserves { get; set; }
        private eBattleCategory battleCategory { get; set; }
        public bool IsDisableUpdate { get; set; }
        public bool AllEnemyHp0 { get; set; }
        private float[] lifeAmounts { get; set; }
        private float[] maxLifeAmounts { get; set; }
        public UnitCtrl GuestUnit { get; set; }
        public bool ReservedGuestSkill { get; set; }
        public Transform TalentBonusIconParentTransform { get; }


        // RVA: 0x1F8284C Offset: 0x1F8284C VA: 0x1F8284C Slot: 5
        protected override void OnAwake() { }

        // RVA: 0x1F82A40 Offset: 0x1F82A40 VA: 0x1F82A40
        private void OnDestroy() { }

        // RVA: 0x1F82DA4 Offset: 0x1F82DA4 VA: 0x1F82DA4
        public void Initialize(ePartyType _usePartyType) { }

        // RVA: 0x1F86CF0 Offset: 0x1F86CF0 VA: 0x1F86CF0
        private bool IsDispatchUnit(int _unitId) { }

        // RVA: 0x1F87AE0 Offset: 0x1F87AE0 VA: 0x1F87AE0
        private void setStarAndEquipStatusIcons(int _index, UnitData _unitData) { }

        // RVA: 0x1F87D58 Offset: 0x1F87D58 VA: 0x1F87D58
        private void setTalentIcon(int _index, int _unitId) { }

        // RVA: 0x1F8765C Offset: 0x1F8765C VA: 0x1F8765C
        private bool isOtherUnit(Dictionary<int, int> _dicViewId, Dictionary<int, int> _dicUnitId, int _unitId) { }

        // RVA: 0x1F87474 Offset: 0x1F87474 VA: 0x1F87474
        private void setVisibleObject(int _index, bool _enable) { }

        // RVA: 0x1F8825C Offset: 0x1F8825C VA: 0x1F8825C
        private void setVisibleGuest(bool _enable) { }

        // RVA: 0x1F88B70 Offset: 0x1F88B70 VA: 0x1F88B70
        public void _Update(bool _canUpdateTime) { }

        // RVA: 0x1F8943C Offset: 0x1F8943C VA: 0x1F8943C
        public void ReallocateUnitCtrl(int _index, int _unitId, int _skinRarity, UnitCtrl _unitCtrl, bool _isDefenceMode = false) { }

        // RVA: 0x1F89A44 Offset: 0x1F89A44 VA: 0x1F89A44
        private void setOnInitCallback(int _index, UnitCtrl _unitController, int _cutinId) { }

        // RVA: 0x1F89618 Offset: 0x1F89618 VA: 0x1F89618
        private void setUpUiCallbacks(int _index, UnitCtrl _unit, int _cutinId) { }

        // RVA: 0x1F89B38 Offset: 0x1F89B38 VA: 0x1F89B38
        private void setupGuestUiCallback(UnitCtrl _unitController, int _cutinId) { }

        // RVA: 0x1F89C20 Offset: 0x1F89C20 VA: 0x1F89C20
        public void SortUnitCtrlsByAliveness() { }

        // RVA: 0x1F886C0 Offset: 0x1F886C0 VA: 0x1F886C0
        private void saveAutoSetting() { }

        // RVA: 0x1F89F30 Offset: 0x1F89F30 VA: 0x1F89F30
        public void SaveAutoSetting() { }

        // RVA: 0x1F88438 Offset: 0x1F88438 VA: 0x1F88438
        public void SetAutoMode(bool _isAutoMode) { }

        // RVA: 0x1F89F80 Offset: 0x1F89F80 VA: 0x1F89F80
        private void setAutoModeFlag(bool _isAutoMode) { }

        // RVA: 0x1F88330 Offset: 0x1F88330 VA: 0x1F88330
        private void hideAllSetButton() { }

        // RVA: 0x1F8857C Offset: 0x1F8857C VA: 0x1F8857C
        public void SetAllSetMode(bool _isAutoMode) { }

        // RVA: 0x1F89F88 Offset: 0x1F89F88 VA: 0x1F89F88
        private void setAllSetModeFlag(bool _isAllSetMode) { }

        // RVA: 0x1F89F90 Offset: 0x1F89F90 VA: 0x1F89F90
        private void setAutoModeFlagBackup() { }

        // RVA: 0x1F89FA4 Offset: 0x1F89FA4 VA: 0x1F89FA4
        public void RestoreAutoModeFlag() { }

        // RVA: 0x1F89FB8 Offset: 0x1F89FB8 VA: 0x1F89FB8
        private void setSpeedModeSettingsBackup() { }

        // RVA: 0x1F89FCC Offset: 0x1F89FCC VA: 0x1F89FCC
        public void RestoreSpeedModeSettings() { }

        // RVA: 0x1F8A08C Offset: 0x1F8A08C VA: 0x1F8A08C
        public void HideSettingButtons() { }

        // RVA: 0x1F8A1C4 Offset: 0x1F8A1C4 VA: 0x1F8A1C4
        public void HidePopUp() { }

        // RVA: 0x1F8A258 Offset: 0x1F8A258 VA: 0x1F8A258
        public void UpdateAllEnemyHp0() { }

        // RVA: 0x1F8A430 Offset: 0x1F8A430 VA: 0x1F8A430
        private void shakeIcon(int _iconIndex) { }

        // RVA: 0x1F8A4B8 Offset: 0x1F8A4B8 VA: 0x1F8A4B8
        private void shakeGuestIcon() { }

        // RVA: 0x1F871E0 Offset: 0x1F871E0 VA: 0x1F871E0
        private void setUnitIcon(int _iconIndex, bool _isEnable) { }

        // RVA: 0x1F8A518 Offset: 0x1F8A518 VA: 0x1F8A518
        private void setGuestIcon(bool _isEnable) { }

        // RVA: 0x1F88DB0 Offset: 0x1F88DB0 VA: 0x1F88DB0
        private void updatePlayerSkill() { }

        // RVA: 0x1F8A6B0 Offset: 0x1F8A6B0 VA: 0x1F8A6B0
        private void updateGuest() { }

        // RVA: 0x1F891A4 Offset: 0x1F891A4 VA: 0x1F891A4
        private void updateEnemySkill() { }

        // RVA: 0x1F8A90C Offset: 0x1F8A90C VA: 0x1F8A90C
        private void onTapPanel(int _unitNo, bool _isPlayer, bool _isAuto) { }

        // RVA: 0x1F8ADD8 Offset: 0x1F8ADD8 VA: 0x1F8ADD8
        private void performTapPanelAction(int _unitNo, bool _isPlayer, bool _isAuto) { }

        // RVA: 0x1F8B0D8 Offset: 0x1F8B0D8 VA: 0x1F8B0D8
        private void onTapGuestPanel() { }

        // RVA: 0x1F8B380 Offset: 0x1F8B380 VA: 0x1F8B380
        private void performTapGuestPanelAction() { }

        // RVA: 0x1F8B4C8 Offset: 0x1F8B4C8 VA: 0x1F8B4C8
        private void playSkillOn(int _unitNo, bool _isPlayer) { }

        // RVA: 0x1F8B5D8 Offset: 0x1F8B5D8 VA: 0x1F8B5D8
        private void activateSkillOnEffect(Vector3 _pos) { }

        // RVA: 0x1F8B6B0 Offset: 0x1F8B6B0 VA: 0x1F8B6B0
        private void onDie(int _index) { }

        // RVA: 0x1F8B9A8 Offset: 0x1F8B9A8 VA: 0x1F8B9A8
        private void onGuestDie() { }

        // RVA: 0x1F8B9F8 Offset: 0x1F8B9F8 VA: 0x1F8B9F8
        private void onEnergyChange(float _energyAmount, int _index) { }

        // RVA: 0x1F8BB44 Offset: 0x1F8BB44 VA: 0x1F8BB44
        private void onGuestEnergyChange(float _energyAmount) { }

        // RVA: 0x1F8BB7C Offset: 0x1F8BB7C VA: 0x1F8BB7C
        private void onChangeState(int _index, eStateIconType _iconType, bool _enable) { }

        // RVA: 0x1F8BD14 Offset: 0x1F8BD14 VA: 0x1F8BD14
        private void onChangeStatePassiveEnable(int _index, eStateIconType _iconType, bool _enable) { }

        // RVA: 0x1F8BE74 Offset: 0x1F8BE74 VA: 0x1F8BE74
        private void onGuestChangeState(eStateIconType _iconType, bool _enable) { }

        // RVA: 0x1F8BEC4 Offset: 0x1F8BEC4 VA: 0x1F8BEC4
        private void onChangeStateNum(int _index, eStateIconType _iconType, int _num) { }

        // RVA: 0x1F8BF5C Offset: 0x1F8BF5C VA: 0x1F8BF5C
        private void onGuestChangeStateNum(eStateIconType _iconType, int _num) { }

        // RVA: 0x1F8BF94 Offset: 0x1F8BF94 VA: 0x1F8BF94
        private void onGuestChangeStatePassiveEnable(eStateIconType _iconType, bool _enable) { }

        // RVA: 0x1F8BFCC Offset: 0x1F8BFCC VA: 0x1F8BFCC
        private void onClickSkillModeBtn() { }

        // RVA: 0x1F8C0A4 Offset: 0x1F8C0A4 VA: 0x1F8C0A4
        private void onClickAllSetModeBtn() { }

        // RVA: 0x1F8C3F8 Offset: 0x1F8C3F8 VA: 0x1F8C3F8
        private void onClickDisableSkillModeButton() { }

        // RVA: 0x1F8886C Offset: 0x1F8886C VA: 0x1F8886C
        private void onClickSpeedBtn() { }

        // RVA: 0x1F8C750 Offset: 0x1F8C750 VA: 0x1F8C750
        private void saveSpeedSetting() { }

        // RVA: 0x1F8C854 Offset: 0x1F8C854 VA: 0x1F8C854
        public void SaveSpeedSetting() { }

        // RVA: 0x1F86B34 Offset: 0x1F86B34 VA: 0x1F86B34
        private void setSpeedMode(bool _isSpeedMode, bool _isBattleSpeedQuadruple) { }

        // RVA: 0x1F8C89C Offset: 0x1F8C89C VA: 0x1F8C89C
        private void setSpeedModeSettings(bool _isSpeedMode, bool _isBattleSpeedQuadruple) { }

        // RVA: 0x1F8C9D0 Offset: 0x1F8C9D0 VA: 0x1F8C9D0
        private void onClickSkipBattleButton() { }

        // RVA: 0x1F88A68 Offset: 0x1F88A68 VA: 0x1F88A68
        public void prepareForNotFullAutoSkip() { }

        // RVA: 0x1F8CAE4 Offset: 0x1F8CAE4 VA: 0x1F8CAE4
        private void executeSkip() { }

        [IteratorStateMachine(typeof(UnitUiCtrl.< startSkipping > d__246))]
        // RVA: 0x1F8CE20 Offset: 0x1F8CE20 VA: 0x1F8CE20
        private IEnumerator startSkipping() { }

        // RVA: 0x1F8CEA0 Offset: 0x1F8CEA0 VA: 0x1F8CEA0
        public float StartFadeOutAnimation(Action _finishCallBack, bool _resetsInitialAlpha = true) { }

        // RVA: 0x1F8D124 Offset: 0x1F8D124 VA: 0x1F8D124
        public void HideSkipFadeScreen(Action _finishCallBack) { }

        // RVA: 0x1F86ECC Offset: 0x1F86ECC VA: 0x1F86ECC
        private void setVisibleSkillFrame(int _index, bool _isVisible) { }

        // RVA: 0x1F8807C Offset: 0x1F8807C VA: 0x1F8807C
        private void setGuestVisibleSkillFrame(bool _isVisible) { }

        // RVA: 0x1F8705C Offset: 0x1F8705C VA: 0x1F8705C
        private void setVisibleSkillReserveFrame(int _index, bool _isVisible) { }

        // RVA: 0x1F88110 Offset: 0x1F88110 VA: 0x1F88110
        private void setGuestVisibleSkillReserveFrame(bool _isVisible) { }

        // RVA: 0x1F8D210 Offset: 0x1F8D210 VA: 0x1F8D210
        private void onClickPauseButtonDisable() { }

        // RVA: 0x1F8D2B8 Offset: 0x1F8D2B8 VA: 0x1F8D2B8
        private void onLongPressNow(int _unitNo, bool _isMain, bool _isDefenseReplay) { }

        // RVA: 0x1F8D7CC Offset: 0x1F8D7CC VA: 0x1F8D7CC
        private void onLongPressNowGuest() { }

        // RVA: 0x1F8D884 Offset: 0x1F8D884 VA: 0x1F8D884
        private void onLongPressGuest() { }

        // RVA: 0x1F8D394 Offset: 0x1F8D394 VA: 0x1F8D394
        private void onLongPress(int _unitNo, bool _isMain, bool _isDefenseReplay) { }

        // RVA: 0x1F8DB24 Offset: 0x1F8DB24 VA: 0x1F8DB24
        public void SetUnitListForDefenseMode(List<UnitCtrl> _unitList) { }

        // RVA: 0x1F8DC20 Offset: 0x1F8DC20 VA: 0x1F8DC20
        private void setUnitForDefenseMode(int _index, UnitCtrl _unit) { }

        // RVA: 0x1F8E2B4 Offset: 0x1F8E2B4 VA: 0x1F8E2B4
        private void setDefenseModeUniqueEquipIcon(int _index, UnitParameter _unitParam) { }

        // RVA: 0x1F8A624 Offset: 0x1F8A624 VA: 0x1F8A624
        private void turnSkillReady(int _index, bool _isActive) { }

        // RVA: 0x1F8A8D8 Offset: 0x1F8A8D8 VA: 0x1F8A8D8
        private void turnSkillReadyGuest(bool _isActive) { }

        // RVA: 0x1F705C0 Offset: 0x1F705C0 VA: 0x1F705C0
        public void SetDispSkillReserve(UnitCtrl _unit, bool _isActive) { }

        // RVA: 0x1F8B2F8 Offset: 0x1F8B2F8 VA: 0x1F8B2F8
        public void SetDispGuestSkillReserve(bool _isActive) { }

        // RVA: 0x1F877D8 Offset: 0x1F877D8 VA: 0x1F877D8
        private void setEquipStatusIcon(int _unitId, int _index, PartsEquipStatusIcon.eUniqueEquipType _uniqueEquipType, List<bool> _extraEquip) { }

        [Conditional("CYG_DEBUG")]
        // RVA: 0x1F8E5E8 Offset: 0x1F8E5E8 VA: 0x1F8E5E8
        public void Dbg_ChargeEnergyFullAllUnit() { }

        // RVA: 0x1F8E5EC Offset: 0x1F8E5EC VA: 0x1F8E5EC
        public void UpdateUi() { }

        // RVA: 0x1F8B790 Offset: 0x1F8B790 VA: 0x1F8B790
        public void ResetSkillReserve(UnitCtrl _unit, bool _isDead = false) { }

        // RVA: 0x1F8E610 Offset: 0x1F8E610 VA: 0x1F8E610
        public void PlaySkillOn(UnitCtrl _unit) { }

        // RVA: 0x1F8710C Offset: 0x1F8710C VA: 0x1F8710C
        private void controllingSkillReserveAnimation(int _iconIndex, bool _isPlay) { }

        // RVA: 0x1F881A4 Offset: 0x1F881A4 VA: 0x1F881A4
        private void controllingGuestSkillReserveAnimation(bool _isPlay) { }

        // RVA: 0x1F8E80C Offset: 0x1F8E80C VA: 0x1F8E80C
        private float getSkillReserveAminationNormalizedTime() { }

        // RVA: 0x1F8EA10 Offset: 0x1F8EA10 VA: 0x1F8EA10
        public void PlaySkillReserveExecuteEffect(UnitCtrl _unit) { }

        [IteratorStateMachine(typeof(UnitUiCtrl.< syncSkillReserveAminationTime > d__274))]
        // RVA: 0x1F8E568 Offset: 0x1F8E568 VA: 0x1F8E568
        private IEnumerator syncSkillReserveAminationTime() { }

        // RVA: 0x1F8AB30 Offset: 0x1F8AB30 VA: 0x1F8AB30
        private bool canChangeReserveSkillStatus(int _index, bool _isGuest, bool _isAllSet = false) { }

        // RVA: 0x1F8EBC4 Offset: 0x1F8EBC4 VA: 0x1F8EBC4
        public void ExecReserveSKill(UnitCtrl _unit) { }

        // RVA: 0x1F71924 Offset: 0x1F71924 VA: 0x1F71924
        public void ForceFinishReplayBattle() { }

        // RVA: 0x1F8EC88 Offset: 0x1F8EC88 VA: 0x1F8EC88
        public void SkillReserveOverRideFromPrevBattle() { }

        // RVA: 0x1F8C198 Offset: 0x1F8C198 VA: 0x1F8C198
        public void AllSetSkillReserve() { }

        // RVA: 0x1F706C8 Offset: 0x1F706C8 VA: 0x1F706C8
        public void AllResetSkillReserve() { }

        // RVA: 0x1F707A8 Offset: 0x1F707A8 VA: 0x1F707A8
        public void UpdateAllSetButton() { }

        // RVA: 0x1F8EE4C Offset: 0x1F8EE4C VA: 0x1F8EE4C
        private void onBattleControllerButtonLongPressed(CustomUIButton _button, int _buttonType) { }

        // RVA: 0x1F8F054 Offset: 0x1F8F054 VA: 0x1F8F054
        public void SetTalentFormationBonus(Dictionary<int, long> _talent) { }

        // RVA: 0x1F8F310 Offset: 0x1F8F310 VA: 0x1F8F310
        public void SetTalentFormationBonusActive(bool _isActive) { }

        public UnitUiCtrl() { }

        static UnitUiCtrl() { }
    }
}