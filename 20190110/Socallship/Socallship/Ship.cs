using System;
using System.Collections.Generic;
using System.Text;

namespace Socallship
{
    public class Ship
    {
        public Field[] ShipDeck;
        public bool isSink;
        public Ship(int size)
        {
            ShipDeck = new Field[size];
        }
    }
}
