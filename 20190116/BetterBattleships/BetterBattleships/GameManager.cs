using System;
using System.Collections.Generic;

namespace BetterBattleships
{
    public class GameManager
    {
        public void ManageBoard(IPlayer player)
        {
            new BoardPlacer().SetShipsOnBoard(player.GetBoard());
        }
    }
}