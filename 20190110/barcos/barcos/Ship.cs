using System;
using System.Xml.Linq;
using barcos.Enums;

namespace barcos
{ 
    public class Ship
    {
        public ShipMasts Masts { get; private set; }
        public bool Destroyed { get; private set; }
        public ShipOrientation Orientation { get; set; }
        public int CoordinatesX { get; set; }
        public int CoordinatesY { get; set; }

        public Ship(ShipOrientation shipOrientation, ShipMasts masts, int x, int y)
        {
            Masts = masts;
            Orientation = shipOrientation;
            CoordinatesX = x;
            CoordinatesY = y;
        }

        public int GetCurrentState()
        {
            return (int)Masts;
        }

        public void HasHit()
        {
            Masts--;
            
            if (Masts == ShipMasts.destroyed)
                Destroyed = true;
        }
    }
}
