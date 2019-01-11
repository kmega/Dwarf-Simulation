﻿using System;
using System.Xml.Linq;
using barcos.Enums;

namespace barcos
{ 
    public class Ship : IShip
    {
        public ShipMasts Masts { get; private set; }
        public bool Destroyed { get; private set; }
        public ShipOrientation Orientation { get; }
        public int CoordinatesX { get; }
        public int CoordinatesY { get; }

        public Ship(ShipMasts masts)
        {
            Masts = masts;
        }

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
        }

        public void HasHit()
        {
            Masts--;
            
            if (Masts == ShipMasts.destroyed)
                Destroyed = true;
        }
    }
}
