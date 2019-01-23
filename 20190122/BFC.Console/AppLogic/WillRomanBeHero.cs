using System;

namespace BFC.Console.AppLogic
{
    public class WillRomanBeHero : IWillRomanArrive
    {
        public bool IsRomanArrive()
        {
            Random rand = new Random();
            int romanarrive = rand.Next(1);
            if (romanarrive == 1)
            {
                return true;
            }
            else
                return false;

        }
    }
}