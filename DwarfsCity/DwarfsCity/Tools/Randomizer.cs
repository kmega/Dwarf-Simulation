using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfsCity.Tools
{
    public class Randomizer
    {
        public static int GetChanceRatio()
        {
            Random rand = new Random();
            return rand.Next(1, 100);
        }
    }
}
