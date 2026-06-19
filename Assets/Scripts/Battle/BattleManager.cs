using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

[CompilerGenerated]
private sealed class BattleManager.<< StartResult > g__execStartResult | 745_0 > d : IEnumerator<object>, IEnumerator, IDisposable 
{
}


[CompilerGenerated]
[Serializable]
private sealed class BattleManager.<> c 
{
    public static Predicate<UnitCtrl> <> 9__181_1; 
    public static Func<KeyValuePair<int, long>, bool> <> 9__461_0; 
    public static Action<BattleSpineController> <> 9__481_0; 
    public static Action<BattleSpineController> <> 9__481_1; 
    public static Action<BattleSpineController> <> 9__481_2; 
    public static Action<BattleSpineController> <> 9__481_3; 
    public static Predicate<UnitCtrl> <> 9__482_4; 
    public static Action<BattleSpineController> <> 9__482_2; 
    public static Action<BattleSpineController> <> 9__482_3; 
    public static Predicate<UnitCtrl> <> 9__524_0; 
    public static Predicate<UnitCtrl> <> 9__524_1; 
    public static Predicate<UnitParameter> <> 9__538_0; 
    public static Predicate<UnitCtrl> <> 9__544_0; 
    public static Predicate<UnitCtrl> <> 9__544_1; 
    public static Predicate<UnitCtrl> <> 9__544_2; 
    public static Action<SkillEffectCtrl> <> 9__548_2; 
    public static Predicate<UnitCtrl> <> 9__554_0; 
    public static Predicate<UnitCtrl> <> 9__555_0; 
    public static Predicate<UnitCtrl> <> 9__564_0; 
    public static Func<UnitCtrl, bool> <> 9__564_1; 
    public static Func<KeyValuePair<eStateIconType, Elements.Battle.Core.AllUnitSealDamageCutData>, int> <> 9__568_0; 
    public static Comparison<UnitCtrl> <> 9__667_0; 
    public static Predicate<UnitCtrl> <> 9__724_0; 
    public static Predicate<UnitCtrl> <> 9__725_0; 
    public static Predicate<UnitCtrl> <> 9__725_1; 
    public static Predicate<UnitCtrl> <> 9__731_1; 
    public static Predicate<UnitCtrl> <> 9__731_2; 
    public static Action<> 9__734_0; 
    public static Func<KeyValuePair<int, Elements.Data.MasterCombinedResultMotion.CombinedResultMotion>, int> <> 9__739_0; 
    public static Action<> 9__750_0; 
    public static Func<UnitCtrl, bool> <> 9__890_2; 
    public static Converter<UnitParameter, UnitParameter> <> 9__903_0; 
    public static Predicate<UnitParameter> <> 9__903_7; 
    public static Predicate<UnitCtrl> <> 9__933_0; 
    public static Func<KeyValuePair<int, long>, bool> <> 9__934_0; 
    public static Func<KeyValuePair<int, long>, int> <> 9__934_1; 
    public static Predicate<UnitCtrl> <> 9__966_0; 
    public static Comparison<StoryBattleTimeLineData> <> 9__975_0; 
    public static Comparison<StoryBattleVoiceTimeLineData> <> 9__976_0; 
    public static Action<> 9__994_1; 


    internal bool < FindUnit > b__181_1(UnitCtrl _unit) { }

    internal bool < get_IsActiveUnitTalentFormationBonus > b__461_0(KeyValuePair<int, long> _data) { }

    internal void < Update > b__481_0(BattleSpineController _it) { }

    internal void < Update > b__481_1(BattleSpineController _it) { }

    internal void < Update > b__481_2(BattleSpineController _it) { }

    internal void < Update > b__481_3(BattleSpineController _it) { }

    internal bool < updateFrame > b__482_4(UnitCtrl e) { }

    internal void < updateFrame > b__482_2(BattleSpineController _it) { }

    internal void < updateFrame > b__482_3(BattleSpineController _it) { }

    internal bool < setupEnemyProcess > b__524_0(UnitCtrl e) { }

    internal bool < setupEnemyProcess > b__524_1(UnitCtrl unit) { }

    internal bool < checkBossBattle > b__538_0(UnitParameter _it) { }

    internal bool < DisplayEnemyFrontOfDialog > b__544_0(UnitCtrl e) { }

    internal bool < DisplayEnemyFrontOfDialog > b__544_1(UnitCtrl enemy) { }

    internal bool < DisplayEnemyFrontOfDialog > b__544_2(UnitCtrl enemy) { }

    internal void < RecreateDeadUnits > b__548_2(SkillEffectCtrl _effect) { }

    internal bool < GetLatestClearStarNum > b__554_0(UnitCtrl v) { }

    internal bool < GetAliveUnitList > b__555_0(UnitCtrl _unitCtrl) { }

    internal bool < JudgeVoicePlay > b__564_0(UnitCtrl e) { }

    internal bool < JudgeVoicePlay > b__564_1(UnitCtrl e) { }

    internal int < TryApplyAllUnitDamageSeal > b__568_0(KeyValuePair < eStateIconType, Elements.Battle.Core.AllUnitSealDamageCutData > c) { }

    internal int < showTotalDamage > b__667_0(UnitCtrl a, UnitCtrl b) { }

    internal bool < CallbackRequestFinishBattle > b__724_0(UnitCtrl e) { }

    internal bool < createHpList > b__725_0(UnitCtrl data) { }

    internal bool < createHpList > b__725_1(UnitCtrl data) { }

    internal bool < startUnitMove > b__731_1(UnitCtrl data) { }

    internal bool < startUnitMove > b__731_2(UnitCtrl data) { }

    internal void < PlayFlatoutAfterMove > b__734_0() { }

    internal int < createCombineMotionDictionary > b__739_0(KeyValuePair<int, Elements.Data.MasterCombinedResultMotion.CombinedResultMotion> _data) { }

    internal void < bossLoseCoroutine > b__750_0() { }

    internal bool < coroutineStartProcess > b__890_2(UnitCtrl unit) { }

    internal UnitParameter<loadEnemyPrime> b__903_0(UnitParameter _unit) { }

    internal bool < loadEnemyPrime > b__903_7(UnitParameter e) { }

    internal bool < playGuestBattle > b__933_0(UnitCtrl e) { }

    internal bool < playTalentBonusEffect > b__934_0(KeyValuePair<int, long> bonus) { }

    internal int < playTalentBonusEffect > b__934_1(KeyValuePair<int, long> bonus) { }

    internal bool < DeterminePositionOrder > b__966_0(UnitCtrl e) { }

    internal int < StoryBattleAnimationUpdate > b__975_0(StoryBattleTimeLineData a, StoryBattleTimeLineData b) { }

    internal int < storyBattleVoiceTimeLineUpdate > b__976_0(StoryBattleVoiceTimeLineData a, StoryBattleVoiceTimeLineData b) { }

    internal void < TutorialSkillExec > b__994_1() { }
}


[CompilerGenerated]
private sealed class BattleManager.<> c__DisplayClass480_0 
{
    
    public bool isCallbakCalled; 
    internal void < incrementWaveCoroutine > b__0() { }
}


[CompilerGenerated]
private sealed class BattleManager.<> c__DisplayClass491_0 
{
    public eViewId returnViewId; 

    internal void < RetireBattle > b__0() { }

    internal void < RetireBattle > b__1() { }
}


[CompilerGenerated]
private sealed class BattleManager.<> c__DisplayClass493_0 
{
    
    public DungeonQueryUnit fromUnit; 
    internal bool < copyDataFromUserUnitToDungeonTemp > b__0(ClanDispatchUnit data) { }
}


[CompilerGenerated]
private sealed class BattleManager.<> c__DisplayClass493_1 
{
    
    public DungeonUnit toUnit; 

    internal void < copyDataFromUserUnitToDungeonTemp > b__1(SkillLimitCounter _fromSkillOne) { }
}


[CompilerGenerated]
private sealed class BattleManager.<> c__DisplayClass493_2 
{
    
    public SkillLimitCounter _fromSkillOne; 

    internal bool < copyDataFromUserUnitToDungeonTemp > b__2(SkillLimitCounter _toSkillOne) { }
}


[CompilerGenerated]
private sealed class BattleManager.<> c__DisplayClass509_0 
{
    
    public bool _addUnitList; 
    public BattleManager<> 4__this; 
    public Action<UnitCtrl> _callback; 

    internal void < CreateUnit > b__0(GameObject _pUnit) { }
}


[CompilerGenerated]
private sealed class BattleManager.<> c__DisplayClass510_0 
{
    
    public BattleManager<> 4__this; 
    public UnitCtrl _unit; 
    public int unitId; 
    public eUnitRespawnPos _respawnPos; 
    public UnitParameter _pParam; 
    public Action<UnitCtrl> _callback; 

    internal void < CreateUnitSpine > b__0(BattleSpineController _obj) { }
}


[CompilerGenerated]
private sealed class BattleManager.<> c__DisplayClass510_1 
{
    
    public BattleSpineController _obj; 

    internal void < CreateUnitSpine > b__1() { }
}


[CompilerGenerated]
private sealed class BattleManager.<> c__DisplayClass529_0 
{
    
    public PartsBossGauge partsBossGauge; 
    public bool isDisplayBoosHpUi; 
    public UnitCtrl boss; 
    public BattleManager<> 4__this; 
    internal void < initializeSingleBossGauge > b__0() { }
}


[CompilerGenerated]
private sealed class BattleManager.<> c__DisplayClass536_0 
{
    
    public bool _pause; 
    public BattleManager<> 4__this; 

    internal void < setPauseAllUnit > b__0(List < UnitCtrl > _list) { }
}


[CompilerGenerated]
private sealed class BattleManager.<> c__DisplayClass544_0 
{
    
     public int enemyId; 

    internal bool < DisplayEnemyFrontOfDialog > b__3(UnitCtrl unit) { }
}


[CompilerGenerated]
private sealed class BattleManager.<> c__DisplayClass544_1 
{
    
    public int enemyId; 

    internal bool < DisplayEnemyFrontOfDialog > b__4(UnitCtrl unit) { }
}


[CompilerGenerated]
private sealed class BattleManager.<> c__DisplayClass548_0 
{
    
    public BattleManager<> 4__this; 
    public List<int> recreatedUnitId; 
    public List<int> recreatedUnitIndex; 
    public bool isResourceLoaded; 
    public Action<> 9__4; 

    internal void < RecreateDeadUnits > b__0() { }

    internal void < RecreateDeadUnits > b__4() { }

    internal bool < RecreateDeadUnits > b__1() { }
}


[CompilerGenerated]
private sealed class BattleManager.<> c__DisplayClass548_1 
{
    
    public int index; 
    public bool isGuest; 
    public UnitCtrl unit; 
    public BattleManager.<> c__DisplayClass548_0 CS$<>8__locals1; 

    internal void < RecreateDeadUnits > b__3(UnitCtrl _unitCtrl) { }
}


[CompilerGenerated]
private sealed class BattleManager.<> c__DisplayClass548_2 
{
    
    public bool isGuest; 
    public int index; 
    public UnitCtrl unit; 
    public BattleManager.<> c__DisplayClass548_0 CS$<>8__locals2; 

    internal void < RecreateDeadUnits > b__5(UnitCtrl _unitCtrl) { }
}



[CompilerGenerated]
private sealed class BattleManager.<> c__DisplayClass580_0 
{
    
    public bool _isOther; 

    internal bool < ExistsField > b__0(Elements.Battle.Core.FieldDataBase e) { }
}


[CompilerGenerated]
private sealed class BattleManager.<> c__DisplayClass656_0 
{
    
    public UnitCtrl unitCtrl; 
    public BattleManager<> 4__this; 

    internal void < OnBlackOutEnd > b__2() { }
}


[CompilerGenerated]
private sealed class BattleManager.<> c__DisplayClass686_0 
{
    
    public BattleManager.BonusEnemyData bonus; 

    internal bool < execBattleBonus > b__0(UnitCtrl e) { }
}


[CompilerGenerated]
private sealed class BattleManager.<> c__DisplayClass691_0 
{
    
    public BattleManager<> 4__this; 
    public List<BattleManager.BonusEnemyData> _bonusEnemyDatas; 
    internal void < startBonusEffectImpl > b__0() { }
}


[CompilerGenerated]
private sealed class BattleManager.<> c__DisplayClass695_0 
{
    
    public BattleManager<> 4__this; 
    public float tmpTimeScale; 
    internal void < OpenBonusDetailDialog > b__0() { }
}


[CompilerGenerated]
private sealed class BattleManager.<> c__DisplayClass719_0 
{
    
    public List<UnitHpInfo> hpList; 
    internal void < CreateUnitHpInfoList > b__0(List < UnitCtrl > _list, int _viewerId) { }
}


[CompilerGenerated]
private sealed class BattleManager.<> c__DisplayClass720_0 
{
    
    public List<UnitHpInfoForFriendBattle> hpList; 


internal void < CreateUnitHpInfoListForFriendBattle > b__0(List < UnitCtrl > _list, int _viewerId, Dictionary<int, int> _hpRateDic) { }
}


[CompilerGenerated]
private sealed class BattleManager.<> c__DisplayClass721_0 
{
    
    public Action _execCallback; 
    public BattleManager<> 4__this; 
    public Action<int> _errorCallback; 
    public Action<> 9__1; 


    internal void < ResultApiSendExec > b__0() { }


    internal void < ResultApiSendExec > b__1() { }
}


[CompilerGenerated]
private sealed class BattleManager.<> c__DisplayClass732_0 
{
    public string animeName; 
    public BattleManager<> 4__this; 

    internal void < playMiddleGroundLose > b__0(TrackEntry trackentry) { }
}


[CompilerGenerated]
private sealed class BattleManager.<> c__DisplayClass732_1 
{
    public string animeName; 
    public BattleManager<> 4__this; 

    internal void < playMiddleGroundLose > b__1(TrackEntry trackEntry) { }
}


[CompilerGenerated]
private sealed class BattleManager.<> c__DisplayClass735_0 
{
    
    public string animeName; 
    public BattleManager<> 4__this; 
    public void .ctor() { }

    internal void < InitializeAndUpdateWalkPlayer > b__0(TrackEntry trackentry) { }
}


[CompilerGenerated]
private sealed class BattleManager.<> c__DisplayClass735_1 
{
    
    public string animeName; 
    public BattleManager<> 4__this; 

    internal void < InitializeAndUpdateWalkPlayer > b__1(TrackEntry trackEntry) { }
}


[CompilerGenerated]
private sealed class BattleManager.<> c__DisplayClass739_0 
{
    public int tmpUnitId; 
    internal bool < createCombineMotionDictionary > b__1(UnitCtrl _x) { }
}


[CompilerGenerated]
private sealed class BattleManager.<> c__DisplayClass759_0 
{
    
    public string animeName; 
public BattleManager<> 4__this; 


internal void < SetupPlayerResultPosition > b__0(TrackEntry trackentry) { }
}


[CompilerGenerated]
private sealed class BattleManager.<> c__DisplayClass759_1 
{
    
    public string animeName; 
public BattleManager<> 4__this; 


internal void < SetupPlayerResultPosition > b__1(TrackEntry trackEntry) { }
}


[CompilerGenerated]
private sealed class BattleManager.<> c__DisplayClass793_0 
{
    
    public BattleManager<> 4__this; 
    public bool _win; 
    public Action<> 9__2; 
    internal bool < finishWave > b__0() { }
    internal void < finishWave > b__1() { }
    internal void < finishWave > b__2() { }
}


[CompilerGenerated]
private sealed class BattleManager.<> c__DisplayClass890_0 
{
    public bool isResourceLoaded; 
    public int mainPlayerViewerId; 
    public BattleManager<> 4__this; 
    internal void < coroutineStartProcess > b__0() { }
    internal bool < coroutineStartProcess > b__1() { }

    internal bool < coroutineStartProcess > b__3() { }
}


[CompilerGenerated]
private sealed class BattleManager.<> c__DisplayClass890_1 
{
    public int unitId; 

    internal bool < coroutineStartProcess > b__4(UnitDamageInfo e) { }  
}


[CompilerGenerated]
private sealed class BattleManager.<> c__DisplayClass890_2 
{
    public UnitCtrl[] unitCtrlList; 
    public int i; 
    public Predicate<UnitDamageInfo> <> 9__5; 


internal bool < coroutineStartProcess > b__5(UnitDamageInfo a) { }
}


[CompilerGenerated]
private sealed class BattleManager.<> c__DisplayClass899_0 
{
    public bool isCallbackCalled; 
    internal void < InitializeEnemyFirst > b__0() { }
}


[CompilerGenerated]
private sealed class BattleManager.<> c__DisplayClass903_0 
{
    public List<int> enemyPrefabIdList; 
    public List<UnitParameter> convertedEnemyDeck; 
    public BattleManager<> 4__this; 
    public List<UnitParameter> _enemyDeck; 
    public List<ContinuousUnit> _continuousUnitList; 
    public Dictionary<int, UnitCtrl> currentEnemyUnitCtrlDictionay; 
    public List<UnitCtrl> currentEnemyList; 
    public int extraEnemyIndex; 
    public List<UnitCtrl> extraEnemyList; 
    public int _waveIndex; 
    public int _waveMax; 
    public List<InventoryInfo> _questReward; 
    public Action _finishCallback; 

    internal void < loadEnemyPrime > b__1(int _deckIndex) { }

    internal void < loadEnemyPrime > b__2(int _enemyDeckIndex) { }

    internal void < loadEnemyPrime > b__3(UnitParameter _extraEnemy) { }

    internal void < loadEnemyPrime > b__4() { }
}


[CompilerGenerated]
private sealed class BattleManager.<> c__DisplayClass903_1 
{
    public int enemyDeckIndex; 
    public int _enemyDeckIndex; 

    internal void < loadEnemyPrime > b__5(GameObject _loadedObject) { }
}


[CompilerGenerated]
private sealed class BattleManager.<> c__DisplayClass903_2 
{
    public UnitParameter _extraEnemy; 

    internal void < loadEnemyPrime > b__6(GameObject _loadedObject) { }
}


[CompilerGenerated]
private sealed class BattleManager.<> c__DisplayClass903_3 
{
    public int remainLoadSpineCount; 
}


[CompilerGenerated]
private sealed class BattleManager.<> c__DisplayClass903_4 
{
    public UnitCtrl unit; 
    public UnitParameter unitParameter; 
    public int cutinId; 
    public ContinuousUnit continuousUnit; 

    internal void < loadEnemyPrime > b__8(BattleSpineController _obj) { }
}


[CompilerGenerated]
private sealed class BattleManager.<> c__DisplayClass903_5 
{
    public BattleSpineController _obj; 

    internal void < loadEnemyPrime > b__9() { }
}


[CompilerGenerated]
private sealed class BattleManager.<> c__DisplayClass910_0 
{
    public float scale; 
    internal void < addLoadLandscapeResources > b__4(BattleSpineController unit) { }
}


[CompilerGenerated]
private sealed class BattleManager.<> c__DisplayClass910_1 
{
    public float scale; 
    internal void < addLoadLandscapeResources > b__5(BattleSpineController unit) { }
}


[CompilerGenerated]
private sealed class BattleManager.<> c__DisplayClass932_0 
{
    
    public Action _callback; 
    public int _storyId; 
    public bool _end; 

    internal void < PlayStory > b__0() { }
    internal void < PlayStory > b__1() { }
}


[CompilerGenerated]
private sealed class BattleManager.<> c__DisplayClass933_0 
{
    
    public BattleManager<> 4__this; 
    public Action _callback; 
    internal void < playGuestBattle > b__1() { }
}


[CompilerGenerated]
private sealed class BattleManager.<> c__DisplayClass977_0 
{
    public BattleManager<> 4__this; 
    public StoryBattleTimeLineData _timeLineData; 

    internal void < execTimeLineData > b__0() { }
}


[CompilerGenerated]
private sealed class BattleManager.<> c__DisplayClass978_0 
{
    public int _unitId; 
    internal bool < searchUnit > b__0(UnitCtrl e) { }
    internal bool < searchUnit > b__1(UnitCtrl e) { }
}


[CompilerGenerated]
private sealed class BattleManager.<> c__DisplayClass980_0 
{
    
    public UnitCtrl unitCtrl; 
    public SummonData _summonData; 
    public BattleManager<> 4__this; 
    public Elements.Battle.Core.SummonAction.eMoveType moveType; 
    public FixedTransformMonoBehavior.FixedTransform ucTransform; 

    internal void < Summon > b__0(BattleSpineController _obj) { }
}


[CompilerGenerated]
private sealed class BattleManager.<> c__DisplayClass980_1 
{
    public BattleSpineController _obj; 
    internal void < Summon > b__1() { }
}


[CompilerGenerated]
private sealed class BattleManager.<> c__DisplayClass981_0 
{
    public eUnitRespawnPos respawnPos; 
    internal bool < SearchRespawnPos > b__0(UnitCtrl x) { }
    internal bool < SearchRespawnPos > b__1(UnitCtrl x) { }
}


[CompilerGenerated]
private sealed class BattleManager.<> c__DisplayClass981_1 
{
    
    public eUnitRespawnPos evenRPos; 
    internal bool < SearchRespawnPos > b__2(UnitCtrl x) { }
    internal bool < SearchRespawnPos > b__3(UnitCtrl x) { }
    internal bool < SearchRespawnPos > b__4(UnitCtrl x) { }
}


[CompilerGenerated]
private sealed class BattleManager.<> c__DisplayClass994_0 
{
    public GameObject _focus; 

    internal void < TutorialSkillExec > b__0() { }
}


namespace Elements.Battle
{ 
    public class BattleManager : MonoBehaviour, ISingletonField, IBattleManagerForBattleUnionBurstController, IBattleManagerForDungeonBattleProcessor, IBattleManagerForBaseBattleProcessor, IBattleManagerForTimeUpDeadEffect, IBattleManagerForDungeonSpecialBattleProcessor, IBattleManagerForArenaBattleProcessor, IBattleManagerForArenaReplayBattleProcessor, IBattleManagerForGrandArenaBattleProcessor, IBattleManagerForGrandArenaReplayBattleProcessor, IBattleManagerForQuestBattleProcessor, IBattleManagerForOnlyBaseBattleProcessor, IBattleManagerForTrainingBattleProcessor, IBattleManagerForQuestReplayBattleProcessor, IBattleManagerForStoryBattleProcessor, IBattleManagerForHatsuneBattleProcessor, IBattleManagerForHatsuneBossBattleProcessor, IBattleManagerForClanBattleProcessor, IBattleManagerForTutorialBattleProcessor, IBattleManagerForTowerBattleProcessor, IBattleManagerForTowerExBattleProcessor, IBattleManagerForBattleLog, IBattleManagerForCameraEffect, IBattleManagerForBattleTimeScale, IBattleManagerForDamageEffectCtrlBase, IBattleManagerForSkillEffectCtrl, IBattleManagerForBattleVoiceUtility, IBattleManagerForAbromalStateIconController, IBattleManagerForBattleHeaderController, IBattleManagerForPartsBossGauge, IBattleManagerForUnitUiCtrl, IBattleManagerForLifeGaugeController, IBattleManagerForActionParameter, IBattleManagerForFieldDataBase, IBattleManagerForUbAbnormalData, IBattleManagerForUnitActionController, IBattleManagerForSocketIOManager, IBattleManagerForViewManager, IBattleManagerForHatsuneTask, IBattleManagerForBattleSpineController, IBattleManagerForDialogBossResult, IBattleManagerForDialogHatsuneBossResult, IBattleManagerForDialogQuestFailed, IBattleManagerForDialogNormalArenaResult, IBattleManagerForDialogGrandArenaResult, IBattleManagerForDialogQuestResultWin, IBattleManagerForDialogTowerExResult, IBattleManagerForPartsQuestResultLater, IBattleManagerForPartsQuestResultFormer, IBattleManagerForDialogManager, IBattleManagerForTowerReplayBattleProcessor, IBattleManagerForGeneralReplayBattleProcessor, IBattleManagerForTowerReplayExBattleProcessor, IBattleManagerForTowerReplayExSingleBattleProcessor, IBattleManagerForHighRarityQuestBattleProcessor, IBattleManagerForTrainingQuestFinishSequence, IBattleManagerForKaiserSubBattleProcessor, IBattleManagerForUekBattleProcessor, IBattleManagerForSpaceBattleProcessor, IBattleManagerForReplayClanBattleProcessor, IBattleManagerForAutoLogic, IBattleManagerForTrialBattleProcessor, IBattleManagerForDialogTrialBattleResult, IBattleManagerForBaseDimensionFaultBattleProcessor, IBattleManagerForDimensionFaultBattleProcessor, IBattleManagerForDimensionFaultRehearsalBattleProcessor, IBattleManagerForDimensionFaultTreasureBattleProcessor, IBattleManagerForBywayQuestBattleProcessor, IBattleManagerForBywayQuestReplayBattleProcessor, IBattleManagerForColosseumBattleProcessor, IBattleManagerForTalentQuestBattleProcessor, IBattleManagerForAbyssBattleProcessor, IBattleManagerForAbyssBossBattleProcessor, IBattleManagerForDomeBattleProcessor, IBattleManagerForAcnEndlessBattleProcessor, IBattleManagerForAcnBossBattleProcessor, IBattleManagerForAcnSpecialBattleProcessor, IBattleManagerForAcnUnknownBattleProcesssor 
    {
    
        public const int POST_RESULT_TYPE_LOSE = 0;
        public const int POST_RESULT_TYPE_RESIGN = 1;
        public const int POST_RESULT_TYPE_WIN = 2;
        private const float ZOOM_SPAN = 0.3f;
        private const float ZOOM_SCALE = 1.45f;
        private const float RANDOM_DIGID = 1000;
        private const float POINT_WAIT_TIME = 3;
        private const int ALWAYS_VOICE_PLAY_MAX_COUNT_ADD_GUEST = 2;
        public const float SKILL_VOICE_MIN_DELAY = 0.5f;
	    private const float BOSS_TIME_UP_UNIT_FADEOUT_TIME = 0.5f;
        public const int MILI_DIGID = 1000;
        private const float RESULT_POS_DIFF_MIN = 0.1f;
	    private const double PERMILLE = 1000;
	    private const float ALL_ACTION_DONE_MAX_COUNT = 10;
	    private const int VISUAL_CHANGE = 1;
        private const float TOTAL_DELAY = 0.06f;
	    private const float GUEST_CUT_IN_PAUSE_TIMER = 2;

        [SerializeField]
        private Texture stageBgTex; 
        [SerializeField]
        private Texture stageForegroundTex; 
        [SerializeField]
        private Transform unitParentTransform; 
        [SerializeField]
        private Transform enemyParentTransform; 
        [SerializeField]
        private Camera playCamera; 
        [SerializeField]
        private Transform bgTransform; 
        [SerializeField]
        private double energyGainValueSkillFront; 
        [SerializeField]
        private double energyGainValueSkillMiddle; 
        [SerializeField]
        private double energyGainValueSkillBack; 
        [SerializeField]
        private double energyStackValueDefeat; 
        [SerializeField]
        private double energyStackRatioDamagedFront; 
        [SerializeField]
        private double energyStackRatioDamagedMiddle; 
        [SerializeField]
        private double energyStackRationDamageBack; 
        [SerializeField]
        private MotionBlur motionBlur; 
        [SerializeField]
        private BlurOptimized playCameraBlurOptimized; 
	    [SerializeField]
        private UIPanel skillExeScreen; 
        [SerializeField]
        private Texture skillExeScreenTexture; 
        [SerializeField]
        private UIPanel foregroundPanel; 
        [SerializeField]
        private UIPanel backgroundPanel; 

        private ViewBattle viewBattle; 
        private BattleEffectManager battleEffectManager; 
        private Elements.Battle.Core.BattleComponentTalent componentTalent; 
        private float deltaTimeAccumulated; 
        private float cutinSkipTimeAccumulated; 
        private bool isToPauseOnFrameEnd; 
        private bool isToResumeOnFrameEnd; 
        private bool idleonlyDone; 
        private bool isAllActionDone; 
        private bool playerAllDead; 
        private bool otherAllDead; 
        private List<SkillEffectCtrl> effectUpdateList; 
        private Vector3 playCameraPos0; 
        private UnitCtrl voiceOnUnit; 
        private bool isAdminChanging; 
        private Random.State tempRandomState; 
        private Dictionary<int, UnitCtrl> currentEnemyUnitCtrlDictionary; 
        private List<UnitCtrl>[] allWaveEnemyUnitCtrlListArray; 
	    private List<Vector2> questWinPositionList; 
        private List<BattleSpineController> unitSpineControllerList; 
        private bool isUpdateFrameExecuted; 
        private TowerTempData towerTempData; 
        private SpaceBattleTempData spaceBattleTempData; 
        private ReplayTempData replayTempData; 
        private ColosseumTempData colosseumTempData; 
        private bool isSkipCoroutineRunning; 
        private float startRemainTime; 
	    private int noneVoiceCount; 
        private int lastVoiceId; 
        public float LatestSkillVoiceTime; 
        private eBattleClearType clearType; 
        public float ActionStartTimeCounter; 
	    private int currentWaveOffset; 
        private int suspendCount; 
        private ViewManager viewManager; 
        private BlockLayerManager blockLayerManager; 
        private ResourceManager resourceManager; 
        private ApiManager apiManager; 
        private SoundManager soundManager; 
        private DialogManager dialogManager; 
        private LoadingManager loadingManager; 
        private Elements.Data.TempData tempData; 
        private bool isStarted; 
        private float blackoutTime; 
        private float blackoutTimeCounter; 
        private float fadeoutDuration; 
        private Action onEndFadeOut; 
        private float startalpha; 
	    private Dictionary<BattleDefine.eExtraEffectExecTiming, bool> isExtraEffectCalled; 
        public bool IsPlayedFirstWaveStartStory; 
	    private Dictionary<BattleManager.eBonusType, List<BattleManager.BonusData>> bonusDictionary; 
        private bool isDefeatBonusOnly; 
        private bool timeUpWin; 
        private BaseBattleProcessor battleProcessor; 
        private BattleCameraEffect battleCameraEffect; 
        private BattleEffectPool battleEffectPool; 
        private BattleTimeScale battleTimeScale; 
        private Yggdrasil<BattleManager> singletonTree; 
        private BattleUnionBurstController battleUnionBurstController; 
	    private ISingletonNodeForInstanceEditing battleManagerNode; 
        private bool isValid; 
	    private long allLogBarrierEffectValue; 
        private long allLogBarrierStartValue; 
        private Elements.Battle.Core.PassiveSkillInitializer passiveSkillInitializer; 
        private bool isReleaseSkillHasteLogic; 
        private bool isReleaseSlipDamageLogBarrier; 
	    private bool forcePauseNoDialogUpdate; 
	    private bool wasJudgeAllUnitPuppet; 
        private StoryBattleData storyBattleDataPrefab; 
        private List<StoryBattleTimeLineData> timeLineDataList; 
	    private GameObject focusObject; 
        private CustomUIButton focusButton; 
        private List<EventDelegate> cacheEventDelegate; 

        public int UnitCount { get; set; }

        public List<UnitCtrl> UnitList { get; set; }
        public List<UnitCtrl> EnemyList { get; set; }
        public List<UnitCtrl> BossList { get; set; }
        public UnitCtrl BossUnit; 

        public List<UnitCtrl> FadeOutUnitList { get; set; }
        public List<UnitCtrl> BlackOutUnitList { get; set; }
        
        public Dictionary<int, int> PlayerHpDic { get; set; }
        public Dictionary<int, int> EnemyHpDic { get; set; }

        public double EnergyGainValieSkillFront { get; }
        public double EnergyGainValieSkillMiddle { get; }
        public double EnergyGainValieSkillBack { get; }
        public double EnergyStackValueDefeat { get; }
        public double EnergyStackRatioDamagedFront { get; }
        public double EnergyStackRatioDamagedMiddle { get; }
        public double EnergyStackRatioDamagedBack { get; }
        public Vector3 PlayCameraPos0 { get; }
        public bool IsAdminChanging { get; }
        private float specialBattleStartStoryCounter { get; set; }
        private bool hasReservedTimeStartStory { get; set; }
        private Dictionary<int, List<Elements.Battle.Core.FieldDataBase>> fieldDataDictionary { get; set; }
        public int ChangeSpeedOverwriteFieldCounter { get; set; }
        private SaveDataManager.eBattleMaxSpeed settingBattleMaxSpeed { get; set; }
        private Elements.Battle.Core.EnvironmentData unitEnvironment { get; set; }
        private Elements.Battle.Core.EnvironmentData enemyEnvironment { get; set; }
        public Dictionary<int, int> EnvironmentCounterDic { get; set; }
        public int CurrentEnvironmentId { get; set; }
        public long CurrentEnemyPoint { get; set; }
        public int CurrentDefeatCount { get; set; }
        private Dictionary<eStateIconType, Elements.Battle.Core.AllUnitSealDamageCutData> unitAllUnitSealDamageCutDataDic { get; set; }
        private int allUnitSealDamageCutCounter { get; set; }
        private Dictionary<eStateIconType, Elements.Battle.Core.AllUnitSealDamageCutData> enemyAllUnitSealDamageCutDataDic { get; set; }
        public SpBattleShieldEffect SpBattleShieldEffect { get; set; }
        public List<int> KillOrder { get; set; }
        public ObscuredInt FrameCount { get; set; }
        public eBattleGameState GameState { get; set; }
        public UnitUiCtrl UnitUiCtrl { get; }
        public float TimeLimit { get; set; }
        public float StartLimitTimeForDefense { get; }
        public float TakeOverTimeForDefense { get; }
        public bool IsShowBossGauge { get; }
        private bool isTimeUp { get; }
        public int CurrentWave { get; set; }
        public Dictionary<int, long> UnitTalentFormationBonusDictionary { get; set; }
        public Dictionary<int, int> UnitTalentLevelDictionary { get; set; }
        public Dictionary<int, int> EnemyTalentLevelDictionary { get; set; }
        public Dictionary<int, Dictionary<eParamType, int>> UnitTalentBuffParameterDictionary { get; set; }
        public Dictionary<int, Dictionary<eParamType, int>> EnemyTalentBuffParameterDictionary { get; set; }
        public bool IsDefenseReplayMode { get; set; }
        public bool IsSortBackBossBattle { get; set; }
        public UnitCtrl DecoyUnit { get; set; }
        public UnitCtrl DecoyOther { get; set; }
        public UnitCtrl DecoyUnitFire { get; set; }
        public UnitCtrl DecoyOtherFire { get; set; }
        public eBattleCategory BattleCategory { get; set; }
        public CoroutineManager CoroutineManager { get; set; }
        public eChargeSkillTurn ChargeSkillTurn { get; set; }
        public UnitCtrl UnionBurstUseUnit { get; set; }
        public int ServerDeadFrame { get; set; }
        public int FrameRate { get; set; }
        public float DeltaTime { get; set; }
        public bool IsPlayingPauseEffect { get; }
        public List<long> ExecutedActionList { get; set; }
        public eBattleResult BattleResult { get; set; }
        public int PlayVoiceUnitId { get; set; }
        public int PlayVoiceIndex { get; set; }
        public bool PlayVoiceUnitIsRarity6 { get; set; }
        public int PlayVoiceGroupId { get; set; }
        public int PlayVoiceGroupUnitId { get; set; }
        public bool IsPauseFrameCount { get; set; }
        public bool IsPlayingNoCutInMotion { get; set; }
        public bool IsNoCutInMotionRightAfter { get; set; }
        public bool IsPlayingNoCutInMotionForPSkill { get; set; }
        public List<UnitCtrl> BlackoutUnitTargetList { get; set; }
        public Dictionary<string, GameObject> ReActionEffectDictionary { get; set; }
        public bool IsEnemyCreated { get; set; }
        public List<RewardData> RewardList { get; set; }
        public bool IsBossBattle { get; set; }
        public bool IsClanBattle { get; }
        public bool IsTrialClanBattle { get; }
        public bool IsDispTotalDamageBattle { get; }
        public long TotalBossDamage { get; set; }
        public long SekaiAccumulateDamage { get; set; }
        public bool IsHatsuneQuest { get; }
        public bool IsHatsuneBoss { get; }
        public bool IsHatsuneBattle { get; }
        public bool IsUekTowerBattleContent { get; }
        public bool IsSpaceBattle { get; }
        public bool IsSpecialBattle { get; }
        public bool IsEndlessBattle { get; }
        public bool IsDefenseBattle { get; }
        public bool IsDefenseBattleInMode { get; }
        public bool IsTowerContent { get; }
        public bool IsHighRarityQuest { get; }
        public bool IsTowerReplayContent { get; }
        public bool IsDungeonBattle { get; }
        public bool IsDungeonSpecialBattle { get; }
        public bool IsMainStoryRaidBattle { get; }
        public bool IsSubStoryRaidBattle { get; }
        public bool IsAcnBossBattle { get; }
        public bool IsAcnSpeicalBattle { get; }
        public bool IsAcnUnknownBattle { get; }
        public float LastRetireVoiceTime { get; set; }
        public float LastDamageVoiceTime { get; set; }
        public int CountIsNotPartsBossReady { get; set; }
        public float MultiTimeEffectTimer { get; set; }
        private bool multiTargetEffectDone { get; set; }
        public bool IsPausingEffectSkippedInThisFrame { get; set; }
        public bool IsPrincessSkillMovieRunning { get; set; }
        public bool IsPrincessSkillMovieFirstHalfRunning { get; set; }
        public bool IsPrincessSkillRunning { get; set; }
        public bool IsSuspendLose { get; set; }
        public long StartBattleUnixTime { get; set; }
        private bool isArenaContents { get; }
        public bool IsArenaBattle { get; }
        private bool isArenaReplay { get; }
        public bool CanAllSetMode { get; }
        public bool CanReserveSkill { get; }
        public bool IsColosseumBattle { get; }
        public bool IsDomeBattle { get; }
        public bool IsReplayContents { get; }
        public bool CanQuadruple { get; }
        public bool IsTalentBonusEffectPlaying { get; }
        public bool IsActiveUnitTalentFormationBonus { get; }
        public bool IsReleasedKnightEnhance { get; set; }
        private bool enemySetUp { get; set; }
        public int FieldIndex { get; set; }
        public UnitCtrl SkillReadyUnit { get; set; }
        public UnitCtrl ChainVoicePlayUnit { get; set; }
        public bool HideDamageNumFlag { get; set; }
        private UnitCtrl skillExeUnitForBlackoutFadeout { get; set; }
        public bool CancelByAwake { get; set; }
        private int ubUsedCount { get; set; }
        public bool IsMultiTargetAppearPlaying { get; set; }
        private Dictionary<int, int> bonusIdIconIndexPairsLeft { get; set; }
        private Dictionary<int, int> bonusIdIconIndexPairsRight { get; set; }
        public bool IsCurtain { get; set; }
        private bool isWinTeamFadeOutWaitMode { get; set; }
        private bool loseTeamfadeOutDone { get; set; }
        private bool allTeamFadeoutDone { get; set; }
        private bool ignoreAllActionDone { get; set; }
        private BattleManager.eIgnoreAllActionDoneState ignoreAllActionDoneCoroutineState { get; set; }
        public List<Dictionary<eParamType, Elements.Battle.Core.PassiveActionValue>> UnitPassiveDictionaryByUnit { get; set; }
        public List<Dictionary<eParamType, Elements.Battle.Core.PassiveActionValue>> EnemyPassiveDictionaryByUnit { get; set; }
        public List<Dictionary<eParamType, Elements.Battle.Core.PassiveActionValue>> EnemyPassiveDictionaryByEnemy { get; set; }
        public List<Dictionary<eParamType, Elements.Battle.Core.PassiveActionValue>> UnitPassiveDictionaryByEnemy { get; set; }
        public Dictionary<eDamageEffectType, Dictionary<eDamageEffctTypeDetail, GameObject>> DamageNumberEffectDictionary { get; set; }
        public GameObject TotalDamageEffectPrefabLarge { get; set; }
        public GameObject TotalDamageEffectPrefabSmall { get; set; }
        public bool BattleLogEnable { get; set; }
        public BattleVoiceFlagManager BattleVoiceFlagMgr { get; set; }
        public double DodgeTPRecoverRatio { get; set; }
        private GameObject backgroundEffect { get; set; }
        public bool BattleReady { get; set; }
        public bool IsValid { get; }
        public BattleSpineController MiddleGroundSpine { get; set; }
        public BattleSpineController ForeGroundSpine { get; set; }
        public int EnergyRecoveryRateMax { get; set; }
        public long AllLogBarrierEffectValue { get; }
        public long AllLogBarrierStartValue { get; }
        public bool IsReleaseSkillHasteLogic { get; }
        public bool IsReleaseSlipDamageLogBarrier { get; }
        private BattleManager.eWaveStartAdvState waveStartAdvPlayState { get; set; }
        private bool allStandByDone { get; set; }
        private bool isPlayGuestCutin { get; set; }
        public bool IsGuestCutinPlaying { get; set; }
        public long AbsorberValue { get; set; }
        public bool PrincessFormMoviePausable { get; set; }
        public bool MuteVoice { get; set; }
        private bool tutorialSkillExecDone { get; set; }
        public bool IsStartSkillExec { get; set; }

        private void Awake() { }

        private void Update() { }

        private void OnDestroy() { }

        private void updateFrame() { }
        
        public void CreateUnit(int _unitId, Action<UnitCtrl> _callback, bool _addUnitList = true) 
        {
            
        }
    
        public void CreateUnitSpine(UnitCtrl _unit, eUnitRespawnPos _respawnPos, UnitParameter _pParam, Action<UnitCtrl> _callback, bool _isOther = false) 
        {

        }

        public void SetAdminChanging(bool _flag) { }

        public int GetStartRemainTime() { }

        public int GetBattleElapsedTime() { }
    
        public int GetMiliLimitTime() { }

        public int GetRoundUpTimeLimit() { }

        public void SetPauseTimeLimit(bool _flag) { }

        public int GetUnitCtrlLength() 
        {
            return UnitList.Count;
        }

        public UnitCtrl GetUnitCtrl(int _idx) 
        {
            return UnitList[_idx];
        }

        public UnitCtrl FindUnit(int _id) 
        {
            return UnitList.Find(unit => unit.UnitId == _id);
        }

        public int GetEnemyCtrlLength()
        {
            return EnemyList.Count;
        }

        public UnitCtrl GetEnemyCtrl(int _idx)
        {
            return EnemyList[_idx];
        }

        public UnitCtrl FindEnemy(int _id)
        {
            return EnemyList.Find(enemy => enemy.UnitId == _id);
        }

        public UnitCtrl GetBossUnit() 
        {
            return BossUnit;
        }

        public bool IsShowEffectiveIcon(int _unitId) { }

        public void SetPartsTalentWeakness(int _unitId, BasePartsData _partsData) { }

        public bool GetIsPlayCutin() { }

        public void SetBattleResult(eBattleResult result) { }

        public int GetBlackoutUnitTargetLength() { }

        public UnitCtrl GetBlackoutUnitTarget(int _idx) { }

        public eBattleClearType GetAutoClearType() { }

        public void InitOnlyAutoClearFlag(bool _isUseAllSet) { }

        public void DisableAutoClear() { }

        public void AddSuspendCount() { }

        public void GamePauseOnFrameEnd() { }

        public void GameResumeOnFrameEnd() { }

        private void incrementWave(Action _finishCallback) { }
    
        private IEnumerator incrementWaveCoroutine(Action _finishCallback) { }

        private bool callStartCutIn() { }

        public void PauseAbnormalEffect() { }

        public void ResumeAbnormalEffect() { }

        public void SetSkillEffectSortOrderBack() { }

        public void GamePause(bool _pause, bool _isBlackoutEnd = false) { }

        public void PauseAllSe() { }

        public void FrameCountPause(UnitCtrl _unit) { }

        private IEnumerator resumeFrameCount() { }

        public void RetireBattle() { }

        public void SkipBattle() { }

        private void copyDataFromUserUnitToDungeonTemp(List<DungeonQueryUnit> _userUnitList) { }

        public bool IsSkillExeUnit(UnitCtrl unitCtrl) { }
    
        public void AddUnitSpineControllerList(BattleSpineController _unitSpineController) { }
    
        public void RemoveUnitSpineControllerList(BattleSpineController _unitSpineController) { }
    
        public void AppendCoroutine(IEnumerator cr, ePauseType pauseType, UnitCtrl unit) { }
    
        public void StartCoroutineIgnoreFps(IEnumerator _cr) { }
    
        private IEnumerator updateIgnoreFps(IEnumerator _coroutine) 
        {
            float deltaTimeAccumulated = 0;
        }
    
        public void RemoveCoroutine(UnitCtrl _unit) { }
    
        public void RemoveAllCoroutines() { }
    
        public void AppendEffect(SkillEffectCtrl _skillEffectCtrl, UnitCtrl _unit, bool _isAbnormal = false) { }
    
        public void AppendUITweener(UITweener uiTweener, UnitCtrl unit, bool ignoreBlackout = false) { }
    
        public void AddEffectToUpdateList(SkillEffectCtrl ef) { }
    
        public void RemoveEffectToUpdateList(SkillEffectCtrl ef) { }
    
        public static float Random(float _min, float _max) { }
    
        public static int Random(int _min, int _max) { }
    
        public static int HeldRandom(int _min, int _max) { }
    
        private void appendWaveEndLog() { }
    
        public void NextWaveProcess() { }
    
        public void StopResume() { }
    
        public void CancelInvalidSupportSkill(UnitCtrl _unit) { }
    
        private IEnumerator updateNextBattleWalk() 
        {
            float time = 0;
        }
    
        private void onBossStateChange(eStateIconType _iconType, bool _enable) { }
    
        private void onBossStateNumChange(eStateIconType _iconType, int _num) { }
    
        private void onBossStatePassiveEnableChange(eStateIconType _iconType, bool _enable) { }
    
        private void sortAndSetPositionOneWave(Dictionary<int, UnitCtrl> _pEnemyDataDic) { }

        private void setupEnemyProcess() { }
    
        public bool IsDisplayBossHpUi() { }
    
        public bool IsBossInfinityHpBattle() { }
    
        public bool IsBossInfinityHpMode() { }
    
        public long GetInvalidLifeAmount(long _maxHp) { }
    
        private void initializeSingleBossGauge() { }
    
        private void initializeRaidBossGauge(int _bossGaugeCount) { }
    
        private void initializeAcnUnknownBossGauge() { }
    
        private void onDieEnemy(UnitCtrl _unitCtrl) { }
    
        private IEnumerator playGoldEffectWithDelay(UnitCtrl _unitCtrl) 
        {
            float timer = 0;
        }
    
        private IEnumerator dropTreasureBox(UnitCtrl _unitCtrl) 
        {
            int dropCount;
            float timer;
            float offsetY;
            TreasureEffectController[] treasureEffectControllers;
            int i;
            float dropInterval;
        }
    
        private SkillEffectCtrl createDropPrefab(UnitCtrl _unitCtrl, GameObject _prefab) { }
    
        private void setPauseAllUnit(bool _pause) { }
    
        private void checkBossBattle(Dictionary<int, UnitCtrl> _dic) { }
    
        private void checkBossBattle(List<UnitParameter> _list) { }

        private bool updateMainUnit() { }
    
        private bool updateEnemyUnit() { }
    
        private void onSyncEnd(UnitCtrl _unit) { }
    
        private void resetUnitFrame() { }
    
        public void DisplayUnitFrontOfDialog() { }
    
        public void DisplayEnemyFrontOfDialog() { }

        public IEnumerator UpdateZoom(float _scale, float _posY) 
        {
            CustomEasing _easingScale = new();
            CustomEasing  _easingY = new();
        }
    
        public void DisplayAliveUnitFront() { }
    
        public void RunOutBattleResult() { }
    
        public IEnumerator RecreateDeadUnits(Action _callback, eBattleResult _battleResult) { }
    
        private void resetUnitListOrder() { }
    
        private void updateFrameWithSkip(UnitCtrl _unitCtrl) { }
    
        public void PlayBattleStart() { }
    
        public void SetSpeedUpRate(float _rate) { }
    
        public void UpdateSpeedupFlag() { }
    
        public int GetLatestClearStarNum() { }
    
        public List<UnitCtrl> GetAliveUnitList() { }
    
        public IEnumerator CallTimer(float _time, Action _onComplete) { }
    
        public IEnumerator CallTimer(Action _onComplete) { }
    
        public IEnumerator CallFade(float _from, float _to, float _duration, Action<float> _setFade, Action _onFinish) { }
    
        public int GetCurrentTowerExPartyIndex() { }
    
        public UnitCtrl FindUnitForSoundUnitId(int _soundUnitId) { }
    
        public UnitCtrl FindEnemyForResourceId(int _resourceId) { }
    
        public void RestFrameCount() { }
    
        public void IncrementNoneVoiceAttackCount() { }
    
        public bool JudgeVoicePlay(int _unitId, int _maxNum, float _voiceOffsetRate) { }
    
        public void TurnOffAllEffects() { }
    
        public void OffSkillExeScreen() { }

    
        public void ExecAllUnitSealDamageCut(Elements.Battle.Core.AllUnitSealDamageCutData _data, bool _enemySide) { }

    
        public double TryApplyAllUnitDamageSeal(bool _enemySide, UnitCtrl _target, UnitCtrl _effectTarget, Elements.Battle.Core.ActionParameter _actionParameter) { }
    
        public void ExecField(Elements.Battle.Core.FieldDataBase _fieldData, int _actionId) { }

    
        public void ExecEnvironment(Elements.Battle.Core.EnvironmentData _environmentData, bool _isEnemySide) { }

    
        public int GetEnvironmentId(bool _isEnemy) { }

    
        public void SetEnvironmentResume(bool _isEnemy) { }

    
        public bool ExistsEnvironment(int _id) { }

    
        public void StopField(int _actionId, Elements.Battle.Core.eTargetAssignment _targetAssignment, bool _isOther) { }

    
        public void RestartAbnormalStateField(UnitCtrl _unit, Elements.Battle.Core.eAbnormalState _abnormalState, bool _strict) { }

    
        public bool ExistsField(int _actionId, bool _isOther) { }

    
        public void AddChangeSpeedOverwriteFieldCounter() { }

    
        public IBattleCameraEffectForBattleProcessor GetBattleCameraEffectForBattleProcessor() { }

    
        public IBattleTimeScaleForBattleProcessor GetIBattleTimeScaleForBattleProcessor() { }

    
        public int GetSystemId() { }

    
        private void onChangeBattleCameraScale(bool _cameraOnly) { }

    
        public void SetBossCameraScale(float _scale) { }

    
        private void changeCameraWaveScale() { }

    
        public bool GetEnableShadowEffect() { }

    
        public void StartChangeScale(Skill _skill, float _startTime) { }

    
        public void StopScaleChange() { }

    
        public void SetForegroundEnable(bool _enable) { }

    
        public float GetRespawnPos(eUnitRespawnPos _unitRespawnPos) { }

    
        private void resetAllUnitY() { }

    
        public void ChangeAllUnitDefaultShader() { }

        private IEnumerator skipBattle() 
        {
            Stopwatch stopWatch = new();
        }

        public void FadeOutAllVoices(float _fadeSec) { }

    
        public void FadeOutAllSe(float _fadeSec) { }

    
        public bool CanCreateBattleEffect() { }

    
        public bool IsSkipping() { }

    
        public bool IsLocalReplay() { }

    
        public void ClearLocalReplayData() { }

    
        public void ExecuteSkipProcess(Action _callback) { }

    
        public bool CanSkipBattle() { }

    
        public bool CanPlaySe() { }

    
        public bool CanPlayVoice() { }

    
        public double CalcPlayerDamageTpReduceRate(int _promotionLevel) { }

    
        public double CalcEnemyDamageTpReduceRate(int _promotionLevel) { }

    
        public ValueTuple<long, long> GetTotalBossHp() { }

    
        public bool IsEnableQuestAutoProgress() { }

    
        public bool IsQuestAutoProgressing() { }

    
        public void StartFlatoutEffect(DialogFlatoutPlayer.FlatoutType _type) { }

    
        public bool IsFinishStartFadeIn() { }

    
        public bool CanPlayCutIn() { }

    
        public void ResetThanksTargetUnit() { }

    
        private void calcTalentFormationBonus() { }


        private bool hasTalentFormationBonus() { }
    
        public int GetBlackOutUnitLength() { }

        public void SetStarted(bool _flag) { }

        public void OnBlackOutEnd(UnitCtrl _unit, bool _isForce = false) { }
    
        public void OnCutInEnd(bool _isOther, UnitCtrl _unit) { }
    
        public void SetSkillExeScreen(UnitCtrl _cc, float _exeTime, Color _color, bool _endWithMotion) { }
    
        public void StartBackgroundSpineAnimation(int _skillId, float _skipTime) { }
    
        public void SetSkillExeScreenActive(UnitCtrl _unit, Color _color) { }
    
        private IEnumerator updateBlackoutUnit(UnitCtrl _unit, bool _endWithMotion)
        {
            UnitCtrl blackOutUnit = _unit;
            Elements.Battle.Core.UnitComponentState state = _unit.GetComponent<Elements.Battle.Core.UnitComponentState>();
        }
    
        public void SetBlackoutTimeZero() { }
    
        private IEnumerator updateBlackOutFadeOut(UnitCtrl _unitCtrl, bool _isForce) 
        {

            int tmpUbUsedCount;
            float fadeoutTime;
        }
    
        public void AddBlackOutTarget(UnitCtrl _source, UnitCtrl _target, BasePartsData _parts) { }

        public void FinishBlackFadeOut(UnitCtrl _unit, bool _skipBackgroundAnimeReset) { }
    

        private IEnumerator cameraSizeUpdate(UnitCtrl _unit)
        {
            float time = 0;
            float end = 0;
            CustomEasing easing = null;
        }

        private void showTotalDamage(UnitCtrl _unit) { }

        public void HideDamageNumBySkillScreen() { }
    
        public void SetSkillScreen(bool _enable) { }

        private void execBattleBonus(List<BattleManager.BonusEnemyData> _bonusEnemyDatas) { }
    
        public void StartExtraEffect(BattleDefine.eExtraEffectExecTiming _timing) { }

    
        private void displayBonusIcon() { }
    
        private IEnumerator waitMultiTargetAppearEnd(List<BattleManager.BonusEnemyData> _bonusEnemyDatas) { }

        private IEnumerator waitPlayFirstWaveStartStoryEnd(List<BonusEnemyData> _bonusEnemyDatas)
        {
            bool isNeedWait = false;
        }

    
        private void startBonusEffectImpl(List<BattleManager.BonusEnemyData> _bonusEnemyDatas) { }

    
        public void OpenBonusDetailDialog() { }

    
        public void DeleteBonusIcon(int _bonusId) { }

        public void RevivalAtFinishBattle() { }
    
        private void finishBattle(eBattleResult _battleResult) { }
    
        private List<UnitDamageInfo> createDamageUnitInfoList(int _enemyViewerId, int _myViewerId) { }
        private void adjustUnitDamageInfo() { }
   
        private void adjustEnemyDamageInfo() { }

        public List<UnitHpInfo> CreateUnitHpInfoList(int _enemyViewerId, int _myViewerId) { }

        public List<UnitHpInfoForFriendBattle> CreateUnitHpInfoListForFriendBattle(int _enemyViewerId, int _myViewerId) { }
    
        public void ResultApiSendExec(Action _execCallback, Action<int> _errorCallback) { }
    
        public void StartCameraZoomReset(Action _callback) { }
    
        private IEnumerator cameraZoomReset(Action _callback) 
        {

            float time = 0;
            CustomEasing easing = new();
        }
    
        public void CallbackRequestFinishBattle() { }
    
        private void createHpList() { }

        private void waitAndStartUnitMove() { }
    
        public void SetupLosePlayVoiceUnitId() { }
    
        public void StartCoroutineBossLose() { }
    
        public void OpenTowerExResultDialog(bool _isVictory, int _finalWaveIndex, bool _isFirst) { }
    
        public void OpenResultWinDialog() { }
    
        private void startUnitMove() { }
    
        private void playMiddleGroundLose(bool _timeUp) { }

        private IEnumerator updateGroundSpine(BattleSpineController _spine) 
        {

        }
    
        public void PlayFlatoutAfterMove(bool _isPlayUnitJoyMotion) { }
    
        public IEnumerator InitializeAndUpdateWalkPlayer(Action _onWalkEnd, bool _isOutOfSystemUpdate = false) 
        {
            float[][] speedRandArray;
            float guestSpeed;
            float deltaTimeAccumulated;
            float time;
        }

    
        private bool unitCtrlsWalk(UnitCtrl[] _unitCtrls, float[][] _speedRandArray, bool _keepWalkForMain, int _index, UnitCtrl _guestUnit, ref float _guestSpeed) { }

    
        private bool isReached(bool _isLeft, Vector2 _fromPos, Vector2 _toPos) { }
    
        public void PlayPartyUnitJoyMotion() { }
    
        private Dictionary<int, ResultMotionInfo> createCombineMotionDictionary() { }
    
        private void initCombineMotionArrays(UnitCtrl[] _unitArray, int[] _unitIdArray, int[] _defaultArray, bool _isDeadUnitRecreated) { }
    
        private bool checkIsMatchCombination(int[] _unitIdArray, int[] _targetArray) { }
    
        private bool isRecreateDeadUnit() { }
    
        private void playEnemyResultMotion() { }


        private IEnumerator waitResultMotion(UnitCtrl _unit) 
        {
            eSpineCharacterAnimeId resultLoopAnimeId;
        }

    
        public void StartResult() { }

    
        public void ShowResultDialog() { }

    
        public void ShowResultDialogCoroutine(bool _isWin) { }

        private IEnumerator fadeOutSkillExeScreenWhenTimeUp() { }

    
        public void ResetFieldTimeUp() { }

        private IEnumerator bossLoseCoroutine() 
        {
            bool isExpectBossFadeOut = false;
            bool isSummonOwnUnitFadeOut = false;
            float time = 0;
            Color fadeColor = Color.white;
        }

        public IEnumerator UpdateBossIdleMotion(BattleSpineController _unitSpineController, int _motionPrefix) 
        {
            float alpha = 0;
        }

    
        public void ForceFadeUnitOut() { }

    
        private void stopAllAbnormalEffect(List<UnitCtrl> _unitList) { }

    
        public List<TowerQueryUnit> CreateTowerQueryUnitList(bool _isEx, bool _isPlayer) { }

    
        public void AddTempDataBattleLog() { }

    
        public bool IsAuraRemainBattle() { }

    
        public float GetResultCameraScale() { }
    
        private IEnumerator waitActionWhile(Func<bool> _condition, Action _action) { }

        public IEnumerator SetupPlayerResultPosition(Action _finishCallBack) 
        {

        }

        public void CallbackActionEnd(long actionId) { }
    
        private void onExecutedActionListCountZero() { }
    
        public void CallbackIdleOnlyDone(UnitCtrl unit) { }
    
        public void CallbackFadeOutDone(UnitCtrl unit) { }
    
        private void judgeWinUnitFadeOutDone(bool _winUnitIsOther) { }
    
        private bool isCheckDeadAllUnit(UnitCtrl _unit) { }
    
        public void CallbackDead(UnitCtrl _unit) { }
    
        private IEnumerator updateIgnoreAllActionDoneCounter() 
        {
            float timer = 0;
        }

    
        public void UekOnDeadLastUnit(UnitCtrl _unit, int _area) { }

    
        public void TowerOnDeadLastUnit(UnitCtrl _unit) { }

    
        public void HighRarityOnDeadLastUnit(UnitCtrl _unit, eBattleTreasureBoxType _treasureType) { }
    
        private void finishWave(bool _win) { }
    
        private BaseBattleProcessor createBattleProcessor(UekTempData _uekTempData) { }
    
        public BaseBattleProcessor CreateBattleProcessorImpl(UekTempData _uekTempData) { }
    
        public void Init(ViewBattle _viewBattle) { }
    
        private IEnumerator coroutineStartProcess(ViewBattle _viewBattle) 
        {
            int seed = 0;
            int currentWave = 0;
        }

        public List<UnitCtrl> GetMyUnitList() { }

        public List<UnitCtrl> GetOpponentUnitList() { }

    
        private void initializePassiveSkill() { }

        private void initializePrincessKnightEnhance() { }

        public void InitializePassiveSkillUnitList(List<UnitParameter> _unitList, Elements.Battle.Core.ePassiveInitType _passiveInitType, int _waveNumber) { }

        public void InitializeExAndFreeSkill(UnitData _unitData, Elements.Battle.Core.ePassiveInitType _passiveInitType, int _waveNumber, UnitCtrl _unitController) { }

        public Dictionary<eParamType, Elements.Battle.Core.PassiveActionValue> GetPassiveDictionaryByEnemy(bool _isOther) { }

        public Dictionary<eParamType, Elements.Battle.Core.PassiveActionValue> GetPassiveDictionaryByUnit(bool _isOther) { }
    

        private IEnumerator InitializeEnemyFirst()
        {
            int count = 0;
            int i = 0;
        }

        public void InitializeEnemyForIncliment(Action _finishCallback) { }

        private void setupCurrentEnemy(int _currentWaveIndex) { }

        private void loadEnemy(int _waveIndex, Action finishCallback) { }

        private void loadEnemyPrime(int _waveIndex, int _waveMax, List<UnitParameter> _enemyDeck, List<UnitParameter> _enemyExtraDeck, List<InventoryInfo> _questReward, List<ContinuousUnit> _continuousUnitList, Action _finishCallback) { }

        private UnitCtrl loadEnemyCallback(GameObject _loadedObject, UnitData _uniqueData, List<ContinuousUnit> _continuousUnitList) { }

        public void UpdateSkillCounter(ContinuousUnit _continuousUnit, UnitCtrl _unitCtrl) { }

        private void loadAnimationTexture() { }

        public void UnloadAnimationTexture() { }

        public bool GetForceNormalSD() { }

        private void addLoadDamageNumEffects() { }

        private void addLoadLandscapeResources(int _bgId) { }

        public bool GetAdvPlayed() { }

        public void CallbackStanbyDone(UnitCtrl _unit) { }

    
        public void CallbackStartDashDone(UnitCtrl _unit) { }

        public void PlayStory(Action _callback, int _storyId, bool _end) { }

        private void playGuestBattle(Action _callback) { }

    
        private void playTalentBonusEffect() { }
    
        public long GetPurposeCount() { }
    
        public eHatsuneSpecialPurpose GetPurpose() { }
    
        public void InstantiatePointCounter(Transform _transform, ref PartsHastunePointCounter _counter) { }

    
        public void InstantiateDefenseTimeGauge(Transform _parent, ref PartsHatsuneDefenseTimeGauge _timeGauge) { }

    
        public void InstantiateSpeicalBattleModeWithoutGauge(Transform _parent, ref PartsSpecialBattleMode _specialBattleMode) { }

    
        public int GetEnemyPoint(int _unitId) { }

    
        public int GetInitialPosition(int _unitId) { }

    
        public int GetTriggerHpPercent() { }

    
        public int GetCurrentWaveOffset() { }

    
        public bool GetPlayNext() { }

    
        public void SetPlayNext(bool _value) { }

    
        public bool GetBossGaugeColorChange() { }

    
        public float GetBossGaugeValue(long _currentHp) { }

    
        public void SetSpecialBattleGaugeColor(UIProgressBar _gauge) { }

    
        public List<ContinuousUnit> GetContinuousUnits() { }

    
        public void SetDamageGoldModeMaxHpAttackNum(ref long _damage, ref int _gold, ref int _mode, ref long _maxHp, ref int _attackNum) { }

    
        public void SubstructEnemyPoint(long _point) { }

    
        public void IncrementDefeatCountForEndleeBattle() { }

    
        public void CheckAcnLosingBattleFinish() { }
    
        private IEnumerator waitAndFinishBattle() 
        {
            float timer;
        }

    
        public void SpecialBattleModeChangeOnHpChange() { }

    
        public void DeterminePositionOrder() { }

    
        private int comparePositionX(UnitCtrl _a, UnitCtrl _b) { }
    
        public void SetStoryBattleDataPrefab(StoryBattleData _storyBattleDataPrefab) { }
    
        public IEnumerator StoryBattleAnimationUpdate() 
        {
            int index = 0;
        }
    
        private IEnumerator storyBattleVoiceTimeLineUpdate() 
        {
            int index;
            List<StoryBattleVoiceTimeLineData> timeLineData;
        }
    
        private void execTimeLineData(StoryBattleTimeLineData _timeLineData) { }

        private UnitCtrl searchUnit(int _unitId) { }

        public List<int> GetStoryIdListToStoryBattleData() { }

        public UnitCtrl Summon(SummonData _summonData) { }

        public eUnitRespawnPos SearchRespawnPos(eUnitRespawnPos _ownerRespawnPos, List<UnitCtrl> _unitList, int _unitId) { }
    
        public void SetStartSkillExec(bool _flag) { }
    
        public void TutorialSkillExec(GameObject _focus) { }
    
        public void TutorialOpenFocusDialog() { }
    
        private void resetStartSkillExecFlag() { }
    
        public bool IsVoiceDownLoad() { }
    
        private Coroutine Elements.Battle.IBattleManagerForSkillEffectCtrl.StartCoroutine(IEnumerator _routine) { }

    
        private Coroutine Elements.Battle.IBattleManagerForAbromalStateIconController.StartCoroutine(IEnumerator _routine) { }

    
        private void Elements.Battle.IBattleManagerForAbromalStateIconController.StopCoroutine(IEnumerator _routine) { }

    
        private Coroutine Elements.Battle.IBattleManagerForLifeGaugeController.StartCoroutine(IEnumerator _routine) { }

    
        private Coroutine Elements.Battle.IBattleManagerForActionParameter.StartCoroutine(IEnumerator routine) { }

    
        private Coroutine Elements.Battle.IBattleManagerForUnitActionController.StartCoroutine(IEnumerator routine) { }

    
        private Coroutine Elements.Battle.IBattleManagerForBaseBattleProcessor.StartCoroutine(IEnumerator routine) { }

        public class BonusEnemyData 
        {
            public int Id { get; set; }
            public List<ValueTuple<int, int>> SkillIdAndBonusIdList { get; set; }
        }


        public enum eBonusType 
        {
            DefeatEnemy = 0,
            DominanceEnemy= 1,
            DefeatAllies = 2,
            DominanceAllies = 3,
        }


        public class BonusData 
        {
            public int IconId; 
            public int TextId; 
            public int BonusId; 
        }

        private enum eIgnoreAllActionDoneState 
        {
            NotRunning = 0,
            Running= 1,
            StopPulse = 2,
        }

        private enum eWaveStartAdvState 
        {
            Invalid = 0,
            StandBy = 1,
            Playing= 2,
            Finished= 3,
        }
    }
}