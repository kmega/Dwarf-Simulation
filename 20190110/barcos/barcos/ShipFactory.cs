using System;
using barcos.Enums;

namespace barcos
{
    public class ShipFactory
    {
        
        public IShip CreateFourMastsShip(ShipOrientation orientation, int XStartPosition)
        {
            return new Ship(orientation,ShipMasts.four, XStartPosition);
        }
        public IShip CreateThreeMastsShip(ShipOrientation orientation, int XStartPosition)
        {
            return new Ship(orientation,ShipMasts.three , XStartPosition);
        }
        public IShip CreateTwoMastsShip(ShipOrientation orientation, int XStartPosition)
        {
            return new Ship(orientation,ShipMasts.two, XStartPosition);
        }
        public IShip CreateFiveMastsShip(ShipOrientation orientation, int XStartPosition)
        {
            return new Ship(orientation,ShipMasts.five, XStartPosition);
        }
    }
}
