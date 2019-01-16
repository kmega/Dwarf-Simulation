using barcosFinal.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace barcosFinal
{
    public class UI
    {
        public void ShowBoard(char[,] board)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("   |   ");
                    switch (board[i, j])
                    {
                        case 'o':
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            break;
                        case 'x':
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;
                        case '^':
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            break;
                    }

                    Console.Write(board[i,j]);
                    
                    if (j == 9)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("   |   ");
                        Console.WriteLine("");
                        Console.WriteLine("");
                    }
                    Console.ResetColor();
                }
            }
        }
    }
}
