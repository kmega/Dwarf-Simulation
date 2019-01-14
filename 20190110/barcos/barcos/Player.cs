using System;
using System.Collections.Generic;
using barcos.Enums;

namespace barcos
{
    public class Player
    {
        //public Ship[] Ships =
        //{
        //    new Ship(ShipMasts.two),
        //    new Ship(ShipMasts.two),
        //    new Ship(ShipMasts.three),
        //    new Ship(ShipMasts.three),
        //    new Ship(ShipMasts.four),
        //    new Ship(ShipMasts.four),
        //    new Ship(ShipMasts.five)
        //};

        public Board Board = new Board();
        public string Name;
        public List<IShip> ships;

        public Player(Hypervisor hypervisor)
        {
            hypervisor.RegisterPlayer(this);
            ships = new List<IShip>();
            
        }

        public void SetShipsOnBoard(Ship ship)
        {
<<<<<<< HEAD
            ships.Add(ship);
=======
            ship.CoordinatesX = coordinateX;
            ship.CoordinatesY = coordinateY;
            ship.Orientation = orientation;

>>>>>>> origin/20190110/barcos-owca
        }

        public void AttackShipAtCoordinates(int x, IShip enemyShip)
        {
            if (enemyShip.Orientation == ShipOrientation.vertically)
            {
               
            }
        }
    }
}
