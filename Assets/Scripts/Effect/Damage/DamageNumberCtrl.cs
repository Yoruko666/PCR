using System;
using System.Collections.Generic;
using UnityEngine;

namespace Elements
{
    [Serializable]
    public class DamageNumberCtrl : MonoBehaviour
    {
        // Fields
        private static readonly Dictionary<eDamageEffectColor, string> spriteNameDictionary; 
        private const string MINUS_SUFFIX_NAME = "minus";
        private const string SHADOW_SPRITE_NAME = "battle_num_shadow_";
        private static readonly Dictionary<int, string> shadowSpriteColorDictionary;
        private static readonly Dictionary<eDamageEffectColor, string> effectSpriteNameDictionary;
        [SerializeField]
        private UISprite numSprite; 
        [SerializeField]
        private UISprite numShadowSprite; 
        [SerializeField]
        private UISprite numEffectSprite; 
        public void SetNumber(string _num, eDamageEffectColor _color, List<int> _talentIds)
        {

        }
        public void SetMinus(eDamageEffectColor _color, List<int> _talentIds)
        {

        }
        public void Hide() { }
        private int firstOrDefaultTalentId(List<int> _talentIds)
        {

        }

        public DamageNumberCtrl() { }

        static DamageNumberCtrl() { }
    }
}