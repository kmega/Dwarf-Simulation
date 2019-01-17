using System.Collections.Generic;
using System;

namespace BetterBattleships
{
    public class Player : IPlayer 
    {
        public string Name { get; }
        public CellStatus[,] Board;
        public Player(string name, CellStatus[,] board)
        {
            Name = name;
            Board = board;
        }

        public CellStatus[,] GetBoard()
        {
            return Board;
        }
    }
}