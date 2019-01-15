using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipsWar
{
   public class GameEngine
    {
        bool Winner = false;

        public void PlayWar(StartGame game)
        {
            PlayerTurn pt = new PlayerTurn();

            while (true)
            {

                pt.MakeTurn(game.PlayerTwoShips, game.PlayerTwoBoard);
                if (Winner == true)
                {
                    break;
                }
                pt.MakeTurn(game.PlayerOneShips, game.PlayerOneBoard);
                if (Winner == true)
                {
                    break;
                }
            }

        }
        

    }
}
