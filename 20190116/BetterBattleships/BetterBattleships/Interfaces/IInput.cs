using System.Collections.Generic;

namespace BetterBattleships
{
    public interface IInput
    {
        int[] GetCoordinatesToSetShip();
        int[] GetCoordinatesToShootShip(string vicitmName, string shooter);
        string GetNameForNewPlayer();
        string GetDirectionsForCoordinates();
    }
}