using System;

namespace BattleshipsWar.UI
{
    public class ActionGameUI
    {               
        public static void DisplayUI()
        {
            StartGame Game = new StartGame();           

            DrawBoard(Game.PlayerOneBoard);
            Console.WriteLine();

            Game.PlaceShips();

            GameEngine war = new GameEngine();
            war.PlayWar(Game);
        }



        public static void DrawBoard(CellProperty[,] board)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("  1  2  3  4  5  6  7  8  9 10");
            for (int i = 0; i < 10; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                switch (i)
                {
                    case 0:
                        {
                            Console.Write("A");
                            DrawCells(board, i);                           
                            break;
                        }
                    case 1:
                        {
                            Console.Write("B");
                            DrawCells(board, i);                            
                            break;
                        }
                    case 2:
                        {
                            Console.Write("C");
                            DrawCells(board, i);
                            break;
                        }
                    case 3:
                        {
                            Console.Write("D");
                            DrawCells(board, i);
                            break;
                        }
                    case 4:
                        {
                            Console.Write("E");
                            DrawCells(board, i);
                            break;
                        }
                    case 5:
                        {
                            Console.Write("F");
                            DrawCells(board, i);
                            break;
                        }
                    case 6:
                        {
                            Console.Write("G");
                            DrawCells(board, i);
                            break;
                        }
                    case 7:
                        {
                            Console.Write("H");
                            DrawCells(board, i);
                            break;
                        }
                    case 8:
                        {
                            Console.Write("I");
                            DrawCells(board, i);
                            break;
                        }
                    case 9:
                        {
                            Console.Write("J");
                            DrawCells(board, i);
                            break;
                        }
                }
                Console.WriteLine();
                
            }
        }

        public static void DrawBoardWar(CellProperty[,] board)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("  1  2  3  4  5  6  7  8  9 10");
            for (int i = 0; i < 10; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                switch (i)
                {
                    case 0:
                        {
                            Console.Write("A");
                            DrawCellsWar(board, i);
                            break;
                        }
                    case 1:
                        {
                            Console.Write("B");
                            DrawCellsWar(board, i);
                            break;
                        }
                    case 2:
                        {
                            Console.Write("C");
                            DrawCellsWar(board, i);
                            break;
                        }
                    case 3:
                        {
                            Console.Write("D");
                            DrawCellsWar(board, i);
                            break;
                        }
                    case 4:
                        {
                            Console.Write("E");
                            DrawCellsWar(board, i);
                            break;
                        }
                    case 5:
                        {
                            Console.Write("F");
                            DrawCellsWar(board, i);
                            break;
                        }
                    case 6:
                        {
                            Console.Write("G");
                            DrawCellsWar(board, i);
                            break;
                        }
                    case 7:
                        {
                            Console.Write("H");
                            DrawCellsWar(board, i);
                            break;
                        }
                    case 8:
                        {
                            Console.Write("I");
                            DrawCellsWar(board, i);
                            break;
                        }
                    case 9:
                        {
                            Console.Write("J");
                            DrawCellsWar(board, i);
                            break;
                        }
                }
                Console.WriteLine();

            }
        }

        private static void DrawCellsWar(CellProperty[,] board, int k)
        {

            for (int j = 0; j < 10; j++)
            {
                if (board[k, j] == CellProperty.Empty)
                {
                    Console.ForegroundColor = ConsoleColor.Blue; Console.Write("[");
                    Console.ForegroundColor = ConsoleColor.Cyan; Console.Write(" ");
                    Console.ForegroundColor = ConsoleColor.Blue; Console.Write("]");
                }
                if (board[k, j] == CellProperty.Blocked)
                {
                    Console.ForegroundColor = ConsoleColor.Blue; Console.Write("[");
                    Console.ForegroundColor = ConsoleColor.Red; Console.Write("O");
                    Console.ForegroundColor = ConsoleColor.Blue; Console.Write("]");
                }
                if (board[k, j] == CellProperty.Hit)
                {
                    Console.ForegroundColor = ConsoleColor.Blue; Console.Write("[");
                    Console.ForegroundColor = ConsoleColor.Red; Console.Write("X");
                    Console.ForegroundColor = ConsoleColor.Blue; Console.Write("]");
                }
                if (board[k, j] == CellProperty.Occupied)
                {
                    Console.ForegroundColor = ConsoleColor.Blue; Console.Write("[");
                    Console.ForegroundColor = ConsoleColor.Cyan; Console.Write(" ");
                    Console.ForegroundColor = ConsoleColor.Blue; Console.Write("]");
                }
                if (board[k, j] == CellProperty.Destroyed)
                {
                    Console.ForegroundColor = ConsoleColor.Blue; Console.Write("[");
                    Console.ForegroundColor = ConsoleColor.DarkRed; Console.Write("#");
                    Console.ForegroundColor = ConsoleColor.Blue; Console.Write("]");
                }


                Console.ForegroundColor = ConsoleColor.White;
            }

        }

        private static void DrawCells(CellProperty[,] board, int k)
        {
            
                for (int j = 0; j < 10; j++)
                {                 
                if (board[k, j] == CellProperty.Empty)
                {
                    Console.ForegroundColor = ConsoleColor.Blue; Console.Write("[");
                    Console.ForegroundColor = ConsoleColor.Cyan; Console.Write(" ");
                    Console.ForegroundColor = ConsoleColor.Blue; Console.Write("]");
                }
                if (board[k, j] == CellProperty.Blocked)
                {
                    Console.ForegroundColor = ConsoleColor.Blue; Console.Write("[");
                    Console.ForegroundColor = ConsoleColor.Red; Console.Write(" ");
                    Console.ForegroundColor = ConsoleColor.Blue; Console.Write("]");
                }
                if (board[k, j] == CellProperty.Hit)
                {
                    Console.ForegroundColor = ConsoleColor.Blue; Console.Write("[");
                    Console.ForegroundColor = ConsoleColor.Yellow; Console.Write("X");
                    Console.ForegroundColor = ConsoleColor.Blue; Console.Write("]");
                }
                if (board[k, j] == CellProperty.Occupied)
                {
                    Console.ForegroundColor = ConsoleColor.Blue; Console.Write("[");
                    Console.ForegroundColor = ConsoleColor.Yellow; Console.Write("X");
                    Console.ForegroundColor = ConsoleColor.Blue; Console.Write("]");
                }
                
                    Console.ForegroundColor = ConsoleColor.White;
                }        

        }
    }
}
