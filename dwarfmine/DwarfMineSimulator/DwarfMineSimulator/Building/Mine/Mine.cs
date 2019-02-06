using System;
using System.Collections.Generic;

namespace DwarfMineSimulator.Building.Mine
{
    internal class Mine
    {
        List<IShaft> Shafts = new List<IShaft>();

        public Mine()
        {
            Shafts.Add(new ShaftA());
            Shafts.Add(new ShaftB());
        }

        public IShaft WhichShaft()
        {
            return new Random().Next(0, 2) == 1 ? Shafts[1] : Shafts[0];
        }
    }
}
