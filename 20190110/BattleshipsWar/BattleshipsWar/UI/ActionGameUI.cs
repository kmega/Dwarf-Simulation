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
            DrawBoard(Game);
        }

        public static void DrawBoard(StartGame Game)
        {
            for (int i = 0; i < 10; i++)
            {
                switch (i)
                {
                    case 0:
                        {
                            Console.Write("A");
                            GiveCellStatus(Game, i);
                            Console.WriteLine();
                            break;
                        }
                    case 1:
                        {
                            Console.Write("B");
                            GiveCellStatus(Game, i);
                            Console.WriteLine();
                            break;
                        }
                    case 2:
                        {
                            Console.Write("C");
                            GiveCellStatus(Game, i);
                            Console.WriteLine();
                            break;
                        }
                    case 3:
                        {
                            Console.Write("D");
                            GiveCellStatus(Game, i);
                            Console.WriteLine();
                            break;
                        }
                    case 4:
                        {
                            Console.Write("E");
                            GiveCellStatus(Game, i);
                            Console.WriteLine();
                            break;
                        }
                    case 5:
                        {
                            Console.Write("F");
                            GiveCellStatus(Game, i);
                            Console.WriteLine();
                            break;
                        }
                    case 6:
                        {
                            Console.Write("G");
                            GiveCellStatus(Game, i);
                            Console.WriteLine();
                            break;
                        }
                    case 7:
                        {
                            Console.Write("H");
                            GiveCellStatus(Game, i);
                            Console.WriteLine();
                            break;
                        }
                    case 8:
                        {
                            Console.Write("I");
                            GiveCellStatus(Game, i);
                            Console.WriteLine();
                            break;
                        }
                    case 9:
                        {
                            Console.Write("J");
                            GiveCellStatus(Game, i);
                            Console.WriteLine();
                            break;
                        }
                }
                //for (int j = 0; j < 10; j++)
                //{
                //    IEnumerable<string> status = GiveCellStatus(Game);
                //    status
                //    Console.Write($"[{GiveCellStatus(Game).ToString()}]");
                //}
                Console.WriteLine();
            }
        }


        private static void GiveCellStatus(StartGame Game, int k)
        {
                for (int j = 0; j < 9; j++)
                {
                    if (Game.PlayerOneBoard[k, j] == CellProperty.Empty)
                    {
                        Console.Write("[O]"); 
                    }
                    if (Game.PlayerOneBoard[k, j] == CellProperty.Occupied)
                    {
                        Console.Write("[X]");
                    }
                }               
            
        }
    }
}
