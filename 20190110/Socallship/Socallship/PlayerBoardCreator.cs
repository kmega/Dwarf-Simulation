using System;
using System.Collections.Generic;
using System.Text;

namespace Socallship
{
    public enum BoardCellType
    {
        EMPTY,
        HIT,
        MISS,
        DECK
    }

    public class PlayerBoardCreator
    {
        public BoardCellType[,] CreateBoard()
        {
            BoardCellType[,] PlayerBoard = new BoardCellType[10, 10];
            return PlayerBoard;
        }
    }
}
