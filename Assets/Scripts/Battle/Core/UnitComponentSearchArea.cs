using System.Collections;
using System.Collections.Generic;

namespace Elements.Battle.Core
{
    public class UnitComponentSearchArea : UnitComponentBase, IUnitComponent 
    {
        public bool HasSkillTarget { get; }
        public float SearchAreaSize { get; set; }
        public float StartSearchAreaSize { get; set; }
        public Dictionary<int, float> SkillAreaWidthList { get; set; }
        public List<UnitCtrl> SkillTargetList { get; set; }
        public List<UnitCtrl> TargetEnemyList { get; set; }
        public List<UnitCtrl> TargetPlayerList { get; set; }
        private bool searchAreaChangeRunning { get; set; }
        private float searchAreaChangeTimer { get; set; }
        private bool searchAreaChangeReduceEnergy { get; set; }
        private double searchAreaEnergyRate { get; set; }
        private UnitComponentParameter componentParameter { get; set; }
        private UnitComponentState componentState { get; set; }
        private UnitComponentActionPattern componentAttackPattern { get; set; }
        private UnitComponentUnionBurst componentUnionBurst { get; set; }

        public UnitComponentSearchArea(UnitCtrl _unitController): base(_unitController)
        {

        }

        public void RegisterComponentSet(IUnitComponentContainer _container) 
        {
            
        }

        public void UpdateAttackTargetImpl(BasePartsData _tauntSource)
        {

        }


        public void ResetTargetList()
        {

        }

        public void UpdateSkillTarget() 
        {

        }

        public void ChangeSearchArea(float value, float _time, bool _reduceEnergy, double _reduceEnergyRate)
        {

        }

        private bool judgeFrontAreaTargetForBossParts(UnitCtrl _target, float _distance)
        {
            
        }

        private bool judgeFrontAreaTarget(UnitCtrl _target, float _distance)
        {
            
        }

        private IEnumerator updateChangeSearchArea() 
        {

        }
    }
}