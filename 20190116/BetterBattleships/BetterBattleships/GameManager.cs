using System;
using System.Collections.Generic;

namespace BetterBattleships
{
    public class GameManager
    {
        public void SetShipsOnBoard(IPlayer player)
        {
            new BoardPlacer().SetShipsOnBoard(player);
        }
    }
}