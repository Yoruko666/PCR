namespace Elements.Battle.Core
{
    public class UnitComponentAnimation 
    {
        private Func<BattleSpineController> getSpineControllerFunc; 
        private Func<bool> getIsSkippingFunc; 
        private Func<bool> getCanPlaySeFunc; 
        private UnitComponentSound componentSound; 

        public UnitComponentAnimation(Func<BattleSpineController> _getSpineControllerFunc, Func<bool> _getIsSkippingFunc, Func<bool> _getCanPlaySeFunc) { }

        public void PlayAnimeNoOverlap(eSpineCharacterAnimeId _animeId, int _index1 = -1, int _index2 = -1, int _index3 = -1, bool _isLoop = False, BattleSpineController _targetCtr) { }

        public void RegisterComponentSet(IUnitComponentContainer _container) { }

        public void PlayAnime(eSpineCharacterAnimeId _animeId, int _index1 = -1, int _index2 = -1, int _index3 = -1, bool _isLoop = true, BattleSpineController _targetCtr, bool _quiet = false, float _startTime = 0, bool _ignoreBlackout = false) 
        {

        }
    }
}