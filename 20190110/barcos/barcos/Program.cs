using System;

namespace barcos
{
    class Program
    {
        static void Main(string[] args)
        {
            string[][] board = new string[2][]
            {
                new string[] {"*","*"},
                new string[] {"x","x","x"}

            };
            

            for (int i = 0; i < board.Length; i++)
            {
                Console.WriteLine("");
                for (int j = 0; j < board[i].Length; j++)
                {
                    Console.Write(board[i][j]);
                    Console.Write("    ");
                }
            }

            Console.ReadKey();
        }
    }
}
