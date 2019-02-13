using System;
using System.Collections.Generic;
using System.Text;
using Mine.Locations;
using Mine.Locations.Interfaces;

namespace Mine
{
    class SymulationEngine
    {

        public SymulationEngine()
        {
            IHospital hospital = Hospital.Instance;
            IGuild guild = Guild.Instance;
            IMine mine = Locations.Mine.Instance;
        }
    }
}
