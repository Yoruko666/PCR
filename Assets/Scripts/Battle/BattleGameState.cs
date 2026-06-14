using System.Collections.Generic;

namespace Elements
{
    public enum eBattleGameState 
    {
        Play = 0,
        Idle = 1,
        WaitWaveEnd = 2,
        NextWaveProcess = 3,
        InvalidValue = -1
    }

    public class eBattleGameState_DictComparer : IEqualityComparer<eBattleGameState> 
    {
        public bool Equals(eBattleGameState _x, eBattleGameState _y)
        {
            return _x == _y;
        }

        public int GetHashCode(eBattleGameState _obj)
        {
            return (int)_obj;
        }
    }
}