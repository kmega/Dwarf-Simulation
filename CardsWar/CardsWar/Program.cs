using CardsWar.GameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsWar
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Cards game war made by ™Cold™Phobos*/

            //do
            //1. Starting UI
            //1.1 bool permissionStart = StartUI.Run(); //Showing UI and return permission to running game (true or false)

            //2. Run the game
            //2.1 Game.Run(permissionStart); //Takes permission true or false
            Game.Run(true);

            //3. Ending UI     
            //3.1 EndUI.Run(permissionStart);
            //while(permissionStart); // Doing loop unitil permissionStart = true
        }
    }
}
