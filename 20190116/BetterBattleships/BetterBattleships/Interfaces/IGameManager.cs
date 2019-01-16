namespace BetterBattleships
{
    public interface IGameManager
    {
        CellStatus GetCurrentCellStatus(int[] coords, IPlayer player);
        int[] GetCoordinatesToSetShip();
        string GetDirectionsForCoordinates();
        void SetShipsOnBoard(IPlayer player);
        void ExecuteShipPlacement(string direction, int[] startCoords, ShipTypes ship, IPlayer player);
    }
}
