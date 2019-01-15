using System.Collections.Generic;
using barcosFinal.Interfaces;

namespace barcosFinal
{
    public class Player : IPlayer
    {
        public List<IShip> Ships { get; set; }
        public IBattleField BattleField { get; set; }
        public char[] GetCurrentBattleField()
        {
            return BattleField.Board;
        }

        public char[] Shoot(int x, int y, char[] board)
        {
            throw new System.NotImplementedException();
        }
    }
}