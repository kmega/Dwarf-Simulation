using System;
using System.Collections.Generic;
using System.Text;

namespace barcosFinal.Interfaces
{
    interface IPlayer
    {
        List<IShip> Ships { get; set; }
        IBattleField BattleField { get; set; }
        char[] GetCurrentBattleField();
        char[] Shoot(int x, int y, char[] board);
    }
}
