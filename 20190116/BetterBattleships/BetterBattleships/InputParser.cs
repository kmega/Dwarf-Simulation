using System.Collections.Generic;

namespace BetterBattleships
{
    public class InputParser : IInput
    {
        public string GetNameForNewPlayer()
        {
            System.Console.WriteLine("Podaj imie: ");
            return System.Console.ReadLine();
            //throw new System.NotImplementedException();
        }
    }
}