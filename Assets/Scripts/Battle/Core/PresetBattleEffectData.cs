using System.Collections.Generic;

namespace Elements.Battle.Core 
{
    public class PresetBattleEffectData
    {
        public List<ShakeEffect> GameStartShakes; 
        public List<PrefabWithTime> GameStartEffects; 
        public List<PrefabWithTime> DieEffects;
        public List<ShakeEffect> DieShakes; 
        public List<PrefabWithTime> DamageEffects; 
        public List<ShakeEffect> DamageShakes; 
        public List<PrefabWithTime> SummonEffects; 
        public List<PrefabWithTime> IdleEffects; 
        public List<PrefabWithTime> AuraEffects; 

        public PresetBattleEffectData(List<ShakeEffect> _gameStartShakes, List<PrefabWithTime> _gameStartEffects, List<PrefabWithTime> _dieEffects, List<ShakeEffect> _dieShakes, List<PrefabWithTime> _damageEffects, List<ShakeEffect> _damageShakes, List<PrefabWithTime> _summonEffects, List<PrefabWithTime> _idleEffects, List<PrefabWithTime> _auraEffects)
        {
            GameStartShakes = _gameStartShakes;
            GameStartEffects = _gameStartEffects;
            DieEffects = _dieEffects;
            DieShakes = _dieShakes;
            DamageEffects = _damageEffects;
            DamageShakes = _damageShakes;
            SummonEffects = _summonEffects;
            IdleEffects = _idleEffects;
            AuraEffects = _auraEffects;
        }
    }
}