using System;
using System.Collections.Generic;
using System.Text;

namespace Dwarf_Town.Locations.Guild.OreValue
{
    class MithrilValue : IOreValue
    {
        public decimal GenerateOreValue()
        {
            Random rand = new Random();
            int value = rand.Next(15, 25);
            return value;
        }
    }
}
