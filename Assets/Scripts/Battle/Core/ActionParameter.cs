using System;
using System.Collections.Generic;
using UnityEngine;

namespace Elements.Battle.Core 
{
    public class ActionParameter : ISingletonField 
    {
        private static Yggdrasil<ActionParameter> staticSingletonTree; 
        private static IBattleManagerForActionParameter staticBattleManager; 
        private static IBattleEffectPool staticBattleEffectPool; 
        public eActionType ActionType; 
        public OnActionEndDelegate OnActionEnd;
        public Dictionary<int, GameObject> ToadPrefab; 
        public bool IsSearchAndSorted; 
        public bool IsAlwaysChargeEnegry;
        public double EnergyChargeMultiple; 
        protected List<SkillEffectCtrl> changePatternCurrentSkillEffect;

        protected IBattleManagerForActionParameter battleManager { get; }
        protected IBattleEffectPool battleEffectPool { get; }
        public eTargetAssignment TargetAssignment { get; set; }
        public PriorityPattern TargetSort { get; set; }
        public int TargetNth { get; set; }
        public int TargetNum { get; set; }
        public float TargetWidth { get; set; }
        public DirectionType Direction { get; set; }
        public float Position { get; set; }
        public int ActionDetail1 { get; set; }
        public int ActionDetail2 { get; set; }
        public int ActionDetail3 { get; set; }
        public int ActionId { get; set; }
        public List<BasePartsData> TargetList { get; set; }
        public Dictionary<eValueNumber, double> Value { get; set; }
        public float[] ExecTime { get; set; }
        public List<ActionExecTime> ActionExecTimeList { get; set; }
        public double ActionWeightSum { get; set; }
        public int DepenedActionId { get; set; }
        public bool ReferencedByEffect { get; set; }
        public bool ReferencedByReflection { get; set; }
        public List<int> ActionChildrenIndexes { get; set; }
        public OnDamageHitDelegate OnDamageHit { get; set; }
        public bool IsFlightStateTargetByReflection { get; set; }
        public List<NormalSkillEffect> ActionEffectList { get; set; }
        public List<NormalSkillEffect> ActionSubEffectList { get; set; }
        public bool TriggerCall { get; set; }
        public AbnormalStateFieldAction AbnormalStateFieldAction { get; set; }
        public eAbnormalState EnvironmentTargetAbnormalState { get; set; }
        public bool IsEnvironmentAbnormalState { get; set; }
        public Action OnDefeatEnemy { get; set; }
        public Action OnInitWhenNoTarget { get; set; }
        public bool CancelByIfForAll { get; set; }
        public Dictionary<BasePartsData, long> IdOffsetDictionary { get; set; }
        public int ContinuousTargetCount { get; set; }
        public GameObject SummonPrefab { get; set; }
        public AnimationCurve KnockAnimationCurve { get; set; }
        public AnimationCurve KnockDownAnimationCurve { get; set; }
        public Dictionary<BasePartsData, bool> HitOnceDic { get; set; }
        public Dictionary<UnitCtrl, Dictionary<int, ActionExecedData>> AlreadyExecedData { get; set; }
        public bool SkipAppendIsAlreadyExeced { get; set; }
        public Dictionary<UnitCtrl, List<int>> AlreadyExecedKeys { get; set; }
        public List<BasePartsData> HitOnceKeyList { get; set; }
        public Dictionary<BasePartsData, List<CriticalData>> CriticalDataDictionary { get; set; }
        public Dictionary<eStateIconType, List<UnitCtrl>> UsedChargeEnergyByReceiveDamage { get; set; }
        public Dictionary<BasePartsData, long> LimitDamageDictionaryAtk { get; set; }
        public Dictionary<BasePartsData, long> LimitDamageDictionaryMgc { get; set; }
        public Dictionary<BasePartsData, long> TotalDamageDictionary { get; set; }
        public Dictionary<eValueNumber, double> AdditionalValue { get; set; }
        public Dictionary<eValueNumber, double> MultipleValue { get; set; }
        public Dictionary<UnitCtrl, double> AllSealDamageCutExecValueDic { get; set; }
        public double AllSealDamageCutValueForCountZero { get; set; }
        public Dictionary<eValueNumber, double> DivideValue { get; set; }
        public Elements.Data.MasterSkillAction.SkillAction MasterData { get; set; }
        public eEffectType EffectType { get; set; }
        public bool IgnoreDecoy { get; set; }
        public List<UnitCtrl> ExecedMultiBossList { get; set; }
        public BasePartsData ProtectedParts { get; set; }
        public bool AlreadyTriggerCause { get; set; }
        public bool IgnoreTriggerCausedByTrigger { get; set; }

        public delegate void OnDamageHitDelegate(long Damage);

        public delegate void OnActionEndDelegate();

        public ActionParameter() { }

        public static void StaticRelease() { }

        public bool JudgeLastAndNotExeced(UnitCtrl _target, int _num) { }

        public bool JudgeIsAlreadyExeced(UnitCtrl _target, int _num) { }
    
        public void AppendTargetNum(UnitCtrl _target, int _num) { }

        public bool IsChangeSpeedAction() { }
        public virtual void SetLevel(int _level) { }

        public virtual void Initialize(UnitCtrl _ownerUnitCtrl) { }

        public virtual void ReadyAction(UnitCtrl _source, UnitActionController _sourceActionController, Skill _skill) { }

        public virtual void ExecActionOnStart(Skill _skill, UnitCtrl _source, UnitActionController _sourceActionController) { }

        public virtual void ExecActionOnWaveStart(Skill _skill, UnitCtrl _source, UnitActionController _sourceActionController) { }

        public virtual void OPOEDGKNIEA(UnitCtrl _ownerUnitCtrl) { }

        public void ResetHitData() { }

        public virtual void Initialize() { }

        public void AppendIsAlreadyExeced(UnitCtrl _target, int _num) { }

        public bool IsAppendTargetNum(UnitCtrl _target) { }

        public virtual void IOJMCFEEMIO() { }

        public virtual void DIEEPOHHJHP(UnitCtrl _source, UnitActionController _sourceActionController, Skill _skill) { }

        public Elements.Battle.Core.AbnormalStateEffectPrefabData CreateAbnormalEffectData() { }

        public virtual void ExecAction(UnitCtrl _source, BasePartsData _target, int _num, UnitActionController _sourceActionController, Skill _skill, float _starttime, Dictionary<int, bool> _enabledChildAction, Dictionary<Elements.Battle.Core.eValueNumber, double> _valueDictionary) { }
    }
}