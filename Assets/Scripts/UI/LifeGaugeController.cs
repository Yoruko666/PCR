using System;
using System.Collections;
using UnityEngine;

namespace Elements
{

    public class LifeGaugeController : MonoBehaviour, ISingletonField
    {

        [SerializeField]
        private UISlider mainSlider;
        [SerializeField]
        private UISlider subSlider;
        [SerializeField]
        private UISlider bgSlider;
        [SerializeField]
        private UISprite mainGaugeSprite;
        [SerializeField]
        private UIPanel panel;
        [SerializeField]
        private UISprite skillNameBalloon;
        [SerializeField]
        private CustomUILabel skillNameLabel;
        private static Yggdrasil<LifeGaugeController> staticSingletonTree;
        private static IBattleManagerForLifeGaugeController staticBattleManager;
        private bool isGaugeVisibleAlways;
        private static readonly string RED_SPRITE_NAME;
        private const float RESET_TIME = 0.05f;
        private const float DURATION = 0.2f;
        private const float END_DURATION = 0.2f;
        private const float BALLOON_DURATION = 1;
        private const int EDGE_SIZE = 38;
        private const int STRING_SIZE = 18;
        private static readonly Vector3 SKILL_NAME_BALLOON_SCALE;
        private static readonly Vector3 SKILL_NAME_BALLOON_POSITION;
        private static readonly Vector3 STATE_ICON_SCALE;
        private static readonly Vector3 STATE_ICON_POSITION;

        private IBattleManagerForLifeGaugeController battleManager { get; }
        private UnitCtrl owner { get; set; }
        private float toValue { get; set; }
        private bool isMoving { get; set; }
        private bool skillBalloonVisible { get; set; }
        private float damagedTime { get; set; }
        private AbromalStateIconController abnormalIconGameObject { get; set; }
        private int iconCount { get; set; }

        private void OnDestroy() { }

        public static void StaticRelease() { }

        public void Initialize(bool _isOther, float _height, UnitCtrl _unit, bool _isGaugeVisibleAlways = false) { }

        private IEnumerator followTarget(UnitCtrl _unit) { }

        public void SetSortOrderFront() { }

        public void SetSortOrderBack() { }

        public void SetNormalizedLifeAmount(float _value, float _maxValue, bool _isInitialize = false, bool _isTowerTimeUp = False) { }

        public void IndicateSkillName(string _skillName) { }

        private IEnumerator updateSkillBalloon(string _skillName) 
        {
            float timer = 0;
            while (timer <= BALLOON_DURATION)
            {
                timer += Time.deltaTime;
                yield return null;
            }
        }

        private IEnumerator updateLateSlider() 
        {
            float oldDamageTime = damagedTime;
            float time = 0;
        }

        public void AddIcon(eStateIconType _state) { }

        public void SetIconNum(eStateIconType _state, int _num) { }

        public void SetIconPassiveEnable(eStateIconType _state, bool _enable) { }

        public void DeleteIcon(eStateIconType _state) { }

        public LifeGaugeController() { }

        static LifeGaugeController() { }
    }
}