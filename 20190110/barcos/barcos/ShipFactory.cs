using System;
using barcos.Enums;

namespace barcos
{
    public class ShipFactory
    {
        
        public IShip CreateFourMastsShip(ShipOrientation orientation, int XStartPosition, int YStartPosition)
        {
            return new Ship(orientation,ShipMasts.four, XStartPosition, YStartPosition);
        }
        public IShip CreateThreeMastsShip(ShipOrientation orientation, int XStartPosition, int YStartPosition)
        {
            return new Ship(orientation,ShipMasts.three , XStartPosition, YStartPosition);
        }
        public IShip CreateTwoMastsShip(ShipOrientation orientation, int XStartPosition, int YStartPosition)
        {
            return new Ship(orientation,ShipMasts.two, XStartPosition, YStartPosition);
        }
        public IShip CreateFiveMastsShip(ShipOrientation orientation, int XStartPosition, int YStartPosition)
        {
            return new Ship(orientation,ShipMasts.five, XStartPosition, YStartPosition);
        }
    }
}
