using System;
using System.Collections.Generic;
using System.Text;

namespace Dwarf.Town.Locations.Guild.OreValue
{
    public class SilverValue : IOreValue
    {
        public decimal GenerateOreValue()
        {
            Random rand = new Random();
            int value = rand.Next(5, 15);
            return value;
        }
    }
}
