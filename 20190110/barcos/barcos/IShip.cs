using barcos.Enums;

namespace barcos
{
    public interface IShip
    {
        ShipMasts Masts { get; }
        int CoordinatesX { get;  }
        int CoordinatesY { get;  }

        bool Destroyed { get; }
        int GetCurrentState();
        ShipOrientation Orientation { get; }
        void HasHit();
    }
}