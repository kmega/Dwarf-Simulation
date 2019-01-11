using System;
using System.Collections.Generic;
using System.Text;

namespace Socallship
{
    public class Player
    {
        private string PlayerName { get; set; }
        private BoardCellType[,] PlayerBoard { get; set; }

        public Player(string name)
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

        public BoardCellType GetBoardCellStatus(BoardCellType[,] board, int x, int y)
        {
            return board[x, y];
        }

        public void SetBoardCellStatus(int x, int y, BoardCellType NewType)
        {
            PlayerBoard[x, y] = NewType;
        }

        public void ShotAtPlayersBoard(Player player, int[] coords)
        {
            BoardCellType[,] board  = player.GetPlayerBoard();
            BoardCellType status = GetBoardCellStatus(board, coords[0], coords[1]);

            if(status == BoardCellType.DECK)
            {
                board[coords[0], coords[1]] = BoardCellType.HIT;
            }

            if (status == BoardCellType.EMPTY)
            {
                board[coords[0], coords[1]] = BoardCellType.MISS;
            }

            if (status == BoardCellType.MISS)
            {
                throw new NotImplementedException();
            }

            if(status == BoardCellType.HIT)
            {
                throw new NotImplementedException();
            }
        }
    }
}
