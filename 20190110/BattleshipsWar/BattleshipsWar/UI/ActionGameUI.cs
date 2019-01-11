using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipsWar.UI
{
    public class ActionGameUI
    {               
        public void DisplayUI()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    //if(i)
                    Console.Write("[O]");
                }
                Console.WriteLine();
            }
            Console.ReadKey();

           StartGame Game = new StartGame();
           Game.PlaceShips();
        }
    }
}
