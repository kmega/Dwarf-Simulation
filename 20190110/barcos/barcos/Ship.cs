using System;
<<<<<<< HEAD
=======
using System.Xml.Linq;
>>>>>>> 178937ba99ef84c06264a21e81dd026adc7c196b
using barcos.Enums;

namespace barcos
{
<<<<<<< HEAD
    public class Ship
    {
        public ShipMasts Masts;
        public int Coordinates;
        public ShipOrientation Orientation;
        public int State;

        public Ship()
        {
        }

        public void SetState()
        {

=======
    public class Ship : IShip
    {
        public ShipMasts Masts { get; private set; }
        public bool Destroyed { get; private set; }
        public ShipOrientation Orientation { get; }
        public int CoordinatesX { get; }
        public int CoordinatesY { get; }

        public Ship(ShipOrientation shipOrientation, ShipMasts masts, int X, int Y)
        {
            Masts = masts;
            Orientation = shipOrientation;
            CoordinatesX = X;
            CoordinatesY = Y;
        }

        public int GetCurrentState()
        {
            return (int)Masts;
>>>>>>> 178937ba99ef84c06264a21e81dd026adc7c196b
        }

        public void HasHit()
        {
<<<<<<< HEAD
            State--;
=======
            Masts--;
            
            if (Masts == ShipMasts.destroyed)
                Destroyed = true;
>>>>>>> 178937ba99ef84c06264a21e81dd026adc7c196b
        }
    }
}
