using System;
using barcos.Enums;

namespace barcos
{
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

        }

        public void HasHit()
        {
            State--;
        }
    }
}
