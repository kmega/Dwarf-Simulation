using System.Collections.Generic;

namespace BetterBattleships
{
    public interface IInput
    {
        int[] GetCoordinatesToSetShip();
        int[] GetCoordinatesToShootShip(string vicitmName, string shooter);
        int[] ParseCorrectnessOfInputCoordsFromKeyboard(bool testCondition = false, string testInput = null);
        string GetNameForNewPlayer();
        string GetDirectionsForCoordinates(int[] coords, int ship);
    }
}