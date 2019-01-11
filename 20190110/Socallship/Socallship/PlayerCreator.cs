using System;
using System.Collections.Generic;
using System.Text;

namespace Socallship
{
    public class PlayerCreator
    {
        private string PlayerName { get; set; }
        private BoardCellType[,] PlayerBoard { get; set; }

        public PlayerCreator(string name)
        {
            PlayerName = name;
            PlayerBoard = new PlayerBoardCreator().CreateBoard();
        }

        public string GetName()
        {
            return PlayerName;
        }

        public BoardCellType[,] GetPlayerBoard()
        {
            return PlayerBoard;
        }
    }
}
