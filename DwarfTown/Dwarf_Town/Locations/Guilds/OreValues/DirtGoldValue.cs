using System;
using System.Collections.Generic;
using System.Text;

namespace Dwarf.Town.Locations.Guild.OreValue
{
    public class DirtGoldValue : IOreValue
    {
        public decimal GenerateOreValue()
        {
            return 2;
        }
    }
}
