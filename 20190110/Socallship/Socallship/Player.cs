using System;
using System.Collections.Generic;
using System.Text;

namespace Socallship
{
    public class Player
    {
        public BoardGame Board = new BoardGame();
        public void TryToHit(BoardGame EnemyBoard)
        {
            Console.WriteLine("Podaj koordynaty: ");
            int[] coordinates = Array.ConvertAll(Console.ReadLine().Split(","),
                delegate (string s) { return int.Parse(s); });
            EnemyBoard.UpdateBoard(coordinates[0], coordinates[1]);
            EnemyBoard.ShowBoard();
        }
    }
}
