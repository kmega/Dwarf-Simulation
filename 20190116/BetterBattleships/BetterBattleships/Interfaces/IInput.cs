using System.Collections.Generic;

namespace BetterBattleships
{
    public interface IInput
    {
        string GetNameForNewPlayer();
        int[] GetCoordinatesToSetShip();
        int[] GetCoordinatesToShootShip();
        string GetDirectionsForCoordinates();
    }
}