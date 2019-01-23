using System;
using System.Collections.Generic;
using System.Text;

namespace BFC.Console.Heroes
{
    class ChanceGenerator : IProbablilityOfRomantic
    {
        public bool Draw()
        {
            Random rand = new Random();
            int result = rand.Next(2);
            if(result>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
