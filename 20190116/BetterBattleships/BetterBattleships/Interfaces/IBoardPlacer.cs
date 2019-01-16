namespace BetterBattleships
{
    public interface IBoardPlacer
    {
        CellStatus GetCurrentCellStatus(int[] coords, CellStatus[,] Board);
        int[] GetCoordinatesToSetShip();
        string GetDirectionsForCoordinates();
        void SetShipsOnBoard(CellStatus[,] Board);
        void ExecuteShipPlacement(string direction, int[] startCoords, ShipTypes ship, CellStatus[,] Board);
    }
}
