using Elements.Battle.Core;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Elements
{
    [Serializable]
    public class Skill 
    {
        public bool IsPrincessForm; 
        public List<PrincessSkillMovieData> PrincessSkillMovieDataList; 
        private List<ActionParameter> actionParameters;
        public List<ActionParameterOnPrefab> ActionParametersOnPrefab; 
        public List<NormalSkillEffect> SkillEffects; 
        public List<ShakeEffect> ShakeEffects; 
        public List<BlurEffect.BlurEffectData> BlurEffects; 
        public BattleDefine.ZoomEffect ZoomEffect; 
        public BattleDefine.SlowEffect SlowEffect; 
        public bool ForcePlayNoTarget; 
        public int ParameterTarget; 
        public List<ChangeSortOrderData> ChangeSortDatas; 
        public List<ScaleChanger> ScaleChangers;
	    public int SkillId; 
        public float skillAreaWidth; 
        public eSpineCharacterAnimeId AnimId; 
        public bool Cancel; 
	    public bool DisableOtherCharaOnStart; 
	    private List<SkillEffectCtrl> effectObjs; 
        private List<SkillEffectCtrl> loopEffectObjs;
	    public float BlackOutTime; 
        public bool BlackoutEndWithMotion; 
        public bool ForceComboDamage; 
        public Color BlackoutColor; 
        public float CutInMovieFadeStartTime;
        public float CutInMovieFadeDurationTime; 
        public float CutInSkipTime; 
        public bool ForceCutinOff; 
        public int Level; 
        public string SkillName;
	    public SkillMotionType SkillMotionType; 
        public bool TrackDamageNum; 
        public SystemIdDefine.eWeaponSeType WeaponType; 
	    public bool PauseStopState; 
	    public List<int> BranchIds; 
	    public SubUbVoiceTimingSet SpeedUpWithCutinVoice;
        public SubUbVoiceTimingSet SpeedUpNoCutinVoice; 
        public SubUbVoiceTimingSet NormalWithCutinVoice; 
        public SubUbVoiceTimingSet NormalNoCutinVoice; 
	    public List<Skill> OverrideSkillList;

        public List<ActionParameter> ActionParameters { get; set; }
        public float CastTime { get; set; }
        public float UnionBurstCoolDownTime { get; set; }
        public Dictionary<BasePartsData, BasePartsData> ProtectParts { get; set; }
        public int SkillNum { get; set; }
        public List<SkillEffectCtrl> EffectObjs { get; }
        public List<SkillEffectCtrl> LoopEffectObjs { get; }
        public List<int> HasParentIndexes { get; set; }
        public Vector3 OwnerReturnPosition { get; set; }
        public bool IsModeChange { get; set; }
        public Dictionary<UnitCtrl, double> AccumulatedTpRecovery { get; set; }
        public long AccumulatedLifeSteal { get; set; }
        public bool UseAccumulatedDamage { get; set; }
        public int DefeatEnemyCount { get; set; }
        public bool DefeatByThisSkill { get; set; }
        public bool AlreadyAddAttackSelfSeal { get; set; }
        public bool AlreadyExexActionByHit { get; set; }
        public bool AlreadyAddAttackSealForAllEnemy { get; set; }
        public int LifeSteal { get; set; }
        public bool CountBlind { get; set; }
        public AttackActionBase.eAttackType CountBlindType { get; set; }
        public int EffectBranchId { get; set; }
        public bool HasAttack { get; set; }
        public bool LoopEffectAlreadyDone { get; set; }
        public List<BasePartsData> DamagedPartsList { get; set; }
        public List<BasePartsData> CriticalPartsList { get; set; }
        public long TotalDamage { get; set; }
        public double AweValue { get; set; }
        public bool IsLifeStealEnabled { get; set; }
        public long AbsorberValue { get; set; }
        public int BonusId { get; set; }
        public void SetLevel(int _level)
        {
            Level = _level;
        }
        public void ReadySkill() { }
    }
}