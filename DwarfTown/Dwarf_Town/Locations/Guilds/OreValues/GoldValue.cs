using System;
using System.Collections.Generic;
using System.Text;

namespace Dwarf_Town.Locations.Guild.OreValue
{
    public class GoldValue : IOreValue
    {
        public decimal GenerateOreValue()
        {
            Random rand = new Random();
            int value = rand.Next(10, 20);
            return value;
        }
    }
}
