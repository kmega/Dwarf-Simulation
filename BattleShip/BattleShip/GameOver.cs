using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public static class GameOver
    {
       static public bool ShipsAreDestroyed(Board board,int counter)
        {
            bool result = false;

            int count = 0;

            foreach (var field in board.Fields)
            {
                if (field == Field.H)
                {
                    count++; 
                }
            }

            if (count == counter)
            {
                result = true;
            }

            return result;
        }

    }
}
