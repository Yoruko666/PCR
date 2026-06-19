using System.Collections;
using System.Collections.Generic;

namespace Elements.Battle.Core
{
    public class UnitComponentUnionBurst : UnitComponentBase 
{
        private float unionBurstCoolDownTime; 
        private bool isUbDisabledByChangePattern;
        private Dictionary<Elements.Battle.Core.eReduceEnergyType, bool> isReduceEnergyDictionary;

        public int ThanksTargetUnitId { get; set; }
        public bool IsCoolDown { get; }
        public int Counter { get; set; }
        public bool IsCutInSkip { get; set; }
        public bool PlayCutInFlag { get; set; }
        public bool PlayingNoCutinMotion { get; set; }
        public bool IsUbExecTrying { get; set; }
        public bool MoviePlayed { get; set; }
        public int MovieId { get; set; }
        public int UsedCount { get; set; }
        private DialogManager dialogManager { get; set; }
        private SoundManager soundManager { get; set; }
        private MovieManager movieManager { get; set; }
        private BattleManager battleManager { get; set; }
        private IBattleTimeScaleForUnitCtrl battleTimeScale { get; set; }

        private Elements.Battle.Core.UnitComponentAbnormal componentAbnormal { get; set; }
        private UnitComponentState componentState { get; set; }
        private Elements.Battle.Core.UnitComponentSortOrder componentSortOrder { get; set; }
        private UnitComponentParameter componentParameter { get; set; }
        private Elements.Battle.Core.UnitComponentParameterClamped componentParameterClamped { get; set; }
        private UnitComponentSearchArea componentSearchArea { get; set; }

        
        public UnitComponentUnionBurst(UnitCtrl _unitController, BattleManager _battleManager, IBattleTimeScaleForUnitCtrl _battleTimeScale): base(_unitController)
        {
            battleManager = _battleManager;
            battleTimeScale = _battleTimeScale;
        }

        public void SetPlayCutInFlag(bool _isEnable) { }

        public IEnumerator waitMovieEndFrame(Action _callback, int _movieId) 
        {    
            float oneFrame;
            float duration;
            float previous;
        }

        public bool IsAutoOrUbExecTrying() { }

        public void SetIsCutInSkip(bool _isSkip) { }

        public void IncrementCounter() { }

        public bool ExistsReduceEnergyAction() { }
        public void SetIsUbDisabledByChangePattern(bool _isDisable) { }

        public void SetCoolDownTime(float _coolDownTime) { }
        public void SetReduceEnergyAction(Elements.Battle.Core.eReduceEnergyType _type, bool _isEnable) { }
        public void SubtractCoolDownTime(float _subtractTime, bool _isBlackout) { }

        private void addUnionBurstTimelineData(int _remainTime, bool _isBattleFinish) { }

        public void StartCutIn()
        {
            UnitActionController actionController; 

            bool alreadyCalled;
            bool changeFPS; 
        }

        public bool CheckIsSkillReady() { }
        private bool needsCutIn() { }
        public void IncrementUsedCount() { }
        public void RegisterComponentSet(Elements.Battle.Core.IUnitComponentContainer _container) { }
        public void SetIsUbExecTrying(bool _isUbExecTrying) { }

        public eConsumeResult ConsumeEnergy() { }
        private bool isMyTurn() { }

        public bool JudgeSkillReadyAndIsMyTurn() { }
    }
}