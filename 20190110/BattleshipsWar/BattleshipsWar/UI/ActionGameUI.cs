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
            MakeUI();
            Console.ReadKey();

            
        }

        private static void MakeUI()
        {
            StartGame Game = new StartGame();
            Game.PlaceShips();

            string cellStatus = "O";
            Console.Write("  1  2  3  4  5  6  7  8  9 10");
            Console.WriteLine();


           

            for (int i = 0; i < 10; i++)
            {
                switch (i)
                {
                    case 0:
                        {
                            Console.Write("A");
                            break;
                        }
                    case 1:
                        {
                            Console.Write("B");
                            break;
                        }
                    case 2:
                        {
                            Console.Write("C");
                            break;
                        }
                    case 3:
                        {
                            Console.Write("D");
                            break;
                        }
                    case 4:
                        {
                            Console.Write("E");
                            break;
                        }
                    case 5:
                        {
                            Console.Write("F");
                            break;
                        }
                    case 6:
                        {
                            Console.Write("G");
                            break;
                        }
                    case 7:
                        {
                            Console.Write("H");
                            break;
                        }
                    case 8:
                        {
                            Console.Write("I");
                            break;
                        }
                    case 9:
                        {
                            Console.Write("J");
                            break;
                        }
                }
                for (int j = 0; j < 10; j++)
                {
                    Console.Write($"[{cellStatus}]");
                }
                Console.WriteLine();
            }

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; i++)
                {
                    if (Game.PlayerOneBoard[i, j] == CellProperty.Empty)
                    {
                        Console.Write("[O]");
                    }
                    if (Game.PlayerOneBoard[i, j] == CellProperty.Occupied)
                    {
                        Console.Write("[X]");
                    }
                }
            }
        }
    }
}
