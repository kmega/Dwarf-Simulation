using barcos.Enums;

namespace barcos
{
    public interface IShip
    {
        ShipMasts Masts { get; }
        bool Destroyed { get; }
        int GetCurrentState();
        ShipOrientation Orientation { get; }
        void HasHit();
    }
}