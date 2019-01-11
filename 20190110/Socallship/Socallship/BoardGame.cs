using System;
using System.Collections.Generic;
using System.Text;

namespace Socallship
{
    public class BoardGame
    {
        public Field[,] Board = new Field[10, 10];
        public BoardGame()
        {
            InitializeBoard();
        }
        public void AddShip(Ship ship, bool horizontal)
        {
            if (horizontal)
            {
                for (int i = 0; i < ship.ShipDeck.Length; i++)
                {
                    Board[3, i] = Field.SHIP;
                }
            }
        }
        public void ShowBoard()
        {
            Console.Write("    ");
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                Console.Write(i + " | ");
            }
            Console.WriteLine();
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    char sign = GetChar(Board[i, j]);
                    if (j == 0) Console.Write(i + " | ");
                    Console.Write(sign + " | ");
                }
                Console.WriteLine();
            }
        }
        private void InitializeBoard()
        {
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    Board[i, j] = Field.EMPTY;
                }
            }
        }
        private char GetChar(Field field)
        {
            switch (field)
            {
                case Field.EMPTY: return '-';
                case Field.MISS: return 'M';
                case Field.SHIP: return 'S';
                default: return 'P';
            }
        }


    }
}

