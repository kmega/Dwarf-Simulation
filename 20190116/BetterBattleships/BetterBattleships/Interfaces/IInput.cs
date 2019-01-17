using System.Collections.Generic;

namespace BetterBattleships
{
    public interface IInput
    {
        int[] GetCoordinatesToSetShip();
        int[] GetCoordinatesToShootShip(string name);
        string GetNameForNewPlayer();
        string GetDirectionsForCoordinates();
    }
}