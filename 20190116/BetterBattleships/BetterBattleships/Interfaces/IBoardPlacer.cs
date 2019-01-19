namespace BetterBattleships
{
    public interface IBoardPlacer
    {
        CellStatus GetCurrentCellStatus(int[] coords, CellStatus[,] Board);
        void SetShipsOnBoard(CellStatus[,] Board, string Name);
        void ExecuteShipPlacement(string direction, int[] startCoords, ShipTypes ship, CellStatus[,] Board, bool testCondition);
    }
}
