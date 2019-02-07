using System;
using System.Collections.Generic;
using DwarfMineSimulator.Dwarfs;

namespace DwarfMineSimulator.Building.Mine
{
    internal class Mine
    {
        List<IShaft> Shafts = new List<IShaft>();
        List<Dwarf> DwarfsInMine = new List<Dwarf>();

        public Mine(List<Dwarf> dwarfsInMine)
        {
            DwarfsInMine = dwarfsInMine;
            Shafts.Add(new Shaft("ShaftA"));
            Shafts.Add(new Shaft("ShaftB"));
        }

        public IShaft WhichShaft()
        {
            return new Random().Next(0, 2) == 1 ? Shafts[1] : Shafts[0];
        }

        public void DwarfsGoToShaft()
        {
            DwarfsInMine.ForEach(x =>
            {
                x.GoToShaft(WhichShaft());
            });
        }
    }
}
