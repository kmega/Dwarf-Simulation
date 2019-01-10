using System;
using System.Collections.Generic;
using System.Text;

namespace Socallship
{
    public class BoardGame
    {
        char[,] Board = new char[10, 10];
        public BoardGame()
        {
            InitializeBoard();
        }

        public void ShowBoard()
        {
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    Console.Write(Board[i,j] + " ");
                }
                Console.WriteLine();
            }
        }
        private void InitializeBoard()
        {
            for(int i=0;i<Board.GetLength(0);i++)
            {
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    Board[i, j] = 'O';
                }
            }
        }
        public bool CheckPositon(int x,int y)
        {
            if (Board[x,y] == 'O')
                return true;
            else
                return false;
        }
        public void UpdateBoard(int x,int y)
        {
            Board[x, y] = 'X';
        }
   
    }
}
