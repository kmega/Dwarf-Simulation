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
                Console.WriteLine("Strzela pierwszy gracz");
                pt.MakeTurn(game.PlayerTwoShips, game.PlayerTwoBoard);
                if (Winner == true)
                {
                    Console.WriteLine("Wygrał pierwszy gracz");
                    break;
                }
                Console.WriteLine("Strzela drugi gracz");
                pt.MakeTurn(game.PlayerOneShips, game.PlayerOneBoard);
                if (Winner == true)
                {
                    Console.WriteLine("Wygrał drugi gracz");
                    break;
                }
            }

        }
        

    }
}
