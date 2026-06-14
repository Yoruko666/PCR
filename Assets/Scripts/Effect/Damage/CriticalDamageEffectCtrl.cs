using System;
using System.Collections.Generic;
using UnityEngine;

namespace Elements
{
    public class CriticalDamageEffectCtrl : DamageEffectCtrl 
    {
        [SerializeField]
        private UISprite criticalDamageSprite; 
        private static readonly Dictionary<eDamageEffectColor, string> CRITICAL_SPRITE_NAME_DIC; 
        protected override void onDestroy() { }

        public override void SetDamageText(string _damageStr, eDamageEffectColor _color, List<int> _talentIds) { }

        public CriticalDamageEffectCtrl() { }

        static CriticalDamageEffectCtrl() { }
    }

}