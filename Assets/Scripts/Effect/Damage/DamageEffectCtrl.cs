using System;
using System.Collections.Generic;
using UnityEngine;

namespace Elements
{
    public class DamageEffectCtrl : DamageEffectCtrlBase
    {
        [SerializeField]
        protected DamageNumberCtrl[] DamageNumberCtrls; // 0x58
        public UISprite[] NumSprites; // 0x60
        public UISprite[] NumEffectSprites; // 0x68
        public GameObject NumContainer; // 0x70
        protected float deltaX; // 0x78

        protected override void onDestroy() { }

        public override void ResetParameter(GameObject prefab) { }

        public virtual void SetDamageText(string _damageStr, eDamageEffectColor _color, List<int> _talentIds) { }

        public DamageEffectCtrl() { }
    }
}