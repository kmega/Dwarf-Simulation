using System.Collections.Generic;

namespace BetterBattleships
{
    public interface IPlayer
    {
        //mock 
        string Name { get; }
        string GetPlayerName();
        CellStatus[,] GetBoard();


        CellStatus SetCellEmptyStatus();
    }
}
