using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public static class GameOver
    {
       static public bool ShipsAreDestroyed(Board board)
        {
            bool result = true;

            foreach (var field in board.Fields)
            {
                if (field == Field.F)
                {
                    result = false;
                }
            }
            return result;
        }

    }
}
