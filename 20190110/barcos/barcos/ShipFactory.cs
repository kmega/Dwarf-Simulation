using System;
using barcos.Enums;

namespace barcos
{
    public class ShipFactory
    {
        
        public Ship CreateFourMastsShip(ShipOrientation orientation, int XStartPosition, int YStartPosition)
        {
            return new Ship(orientation,ShipMasts.four, XStartPosition, YStartPosition);
        }
        public Ship CreateThreeMastsShip(ShipOrientation orientation, int XStartPosition, int YStartPosition)
        {
            return new Ship(orientation,ShipMasts.three , XStartPosition, YStartPosition);
        }
        public Ship CreateTwoMastsShip(ShipOrientation orientation, int XStartPosition, int YStartPosition)
        {
            return new Ship(orientation,ShipMasts.two, XStartPosition, YStartPosition);
        }
        public Ship CreateFiveMastsShip(ShipOrientation orientation, int XStartPosition, int YStartPosition)
        {
            return new Ship(orientation,ShipMasts.five, XStartPosition, YStartPosition);
        }
    }
}
