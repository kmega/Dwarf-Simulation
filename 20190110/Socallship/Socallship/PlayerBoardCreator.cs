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
            return new BoardCellType[10, 10];
        }
    }
}
