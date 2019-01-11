using System;
using System.Collections.Generic;
using System.Text;

namespace Socallship
{
    public class Player
    {
        public BoardGame Board = new BoardGame();
        public Ship ship = new Ship(3);
        public void TryToHit(BoardGame EnemyBoard)
        {
            Console.WriteLine("Podaj koordynaty: ");
            int[] coordinates = Array.ConvertAll(Console.ReadLine().Split(","),
                delegate (string s) { return int.Parse(s); });
           
            EnemyBoard.ShowBoard();
        }
        public bool CheckLose()
        {
            for(int i=0;i<Board.Board.GetLength(0);i++)
            {
                for (int j = 0; j < Board.Board.GetLength(1); j++)
                {
                    if (Board.Board[i, j] != Field.SHIP) return true;
                }
            }
            return false;
        }
    }
}
