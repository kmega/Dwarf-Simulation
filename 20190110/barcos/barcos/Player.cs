using System;
using barcos.Enums;

namespace barcos
{
    public class Player
    {
        public Ship[] Ships =
        {
            new Ship(ShipMasts.two),
            new Ship(ShipMasts.two),
            new Ship(ShipMasts.three),
            new Ship(ShipMasts.three),
            new Ship(ShipMasts.four),
            new Ship(ShipMasts.four),
            new Ship(ShipMasts.five)
        };

        public Board Board;
        public string Name;

        public Player(Hypervisor hypervisor)
        {
            hypervisor.RegisterPlayer(this);
        }

        public void SetShipsOnBoard(Ship ship, 
            int coordinateX, int coordinateY, ShipOrientation orientation)
        {

        }

        public void AttackShipAtCoordinates()
        {

        }
    }
}
