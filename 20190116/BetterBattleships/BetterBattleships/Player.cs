using System.Collections.Generic;
using System;

namespace BetterBattleships
{
    public class Player : IPlayer , IBoard, IInput
    {
        public string Name { get; }
        public CellStatus[,] Board;
        public GameManager GM { get; set; }
        public Player(string name, CellStatus[,] board)
        {
            Name = name;
            Board = board;
            GM = new GameManager();
        }

        public CellStatus SetCellEmptyStatus()
        {
            return CellStatus.EMPTY;
        }

        public CellStatus SetCellDeckStatus()
        {
            return CellStatus.DECK;
        }

        public string SetNameForNewPlayer()
        {
            throw new System.NotImplementedException("Input not woriking");
        }

        public string GetPlayerName()
        {
            throw new System.NotImplementedException();
        }

        public CellStatus[,] GetBoard()
        {
            return Board;
        }
    }
}