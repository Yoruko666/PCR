using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Elements.Battle
{
    public interface IBattleManagerForBaseBattleProcessor
    {
        public abstract eBattleResult BattleResult { get; }
        public abstract List<UnitCtrl> BossList { get; set; }
        public abstract bool IsCurtain { get; set; }
        public abstract int GetMiliLimitTime();
        public abstract void CallbackRequestFinishBattle();
        public abstract void ResultApiSendExec(Action _execCallback, Action<int> _errorCallback);
        public abstract Coroutine StartCoroutine(IEnumerator routine);
        public abstract int GetUnitCtrlLength();
        public abstract UnitCtrl GetUnitCtrl(int _idx);
        public abstract int GetEnemyCtrlLength();
        public abstract UnitCtrl GetEnemyCtrl(int _idx);
        public abstract UnitCtrl FindEnemy(int _id);
        public abstract UnitCtrl GetBossUnit();
        public abstract IEnumerator RecreateDeadUnits(Action _callback, eBattleResult _battleResult);
        public abstract void RevivalAtFinishBattle();
        public abstract List<UnitHpInfo> CreateUnitHpInfoList(int _enemyViewerId, int _myViewerId);
        public abstract List<UnitHpInfoForFriendBattle> CreateUnitHpInfoListForFriendBattle(int _enemyViewerId, int _myViewerId);
        public abstract void SetupLosePlayVoiceUnitId();
        public abstract void StartResult();
        public abstract IEnumerator UpdateBossIdleMotion(BattleSpineController _unitSpineController, int _motionPrefix);
        public abstract void TurnOffAllEffects();
        public abstract void OffSkillExeScreen();
        public abstract void ChangeAllUnitDefaultShader();
        public abstract void AppendCoroutine(IEnumerator cr, ePauseType pauseType, UnitCtrl unit);
    }
}