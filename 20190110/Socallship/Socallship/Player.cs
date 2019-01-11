using System;
using System.Collections.Generic;
using System.Text;

namespace Socallship
{
    public class Player
    {
        string Name;
        public BoardGame Board = new BoardGame();
        public Ship ship = new Ship(3);
        public Player(string Name)
        {
            this.Name = Name;
        }
        public void TryToHit(BoardGame EnemyBoard)
        {
           
        }
        public bool CheckIfLose()
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
