using DwarfLifeSimulation.Dwarves;
using DwarfLifeSimulation.Dwarves.BuyStrategies;
using DwarfLifeSimulation.Dwarves.Interfaces;
using DwarfLifeSimulation.Dwarves.WorkStrategies;
using DwarfLifeSimulation.Enums;
using DwarfLifeSimulation.Randomizer.HitsRandomizer;
using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfLifeSimulationsTests.E2ETests
{
    internal class FakeDwarves
    {
        internal List<IDwarf> CreateDwarves(int numberOfDwarves, DwarfType dwarfType, IHitsRandomizer hitsRandomizer)
        {
            List<IDwarf> dwarves = new List<IDwarf>();
            for(int i = 0; i<numberOfDwarves; i++)
            {
                dwarves.Add(CreateSingle(dwarfType, hitsRandomizer));
            }
            return dwarves;
        }

        internal IDwarf CreateSingle(DwarfType dwarfType, IHitsRandomizer hitsRandomizer=null)
        {
            IWorkStrategy workStrategy = null;
            IBuyStrategy buyStrategy = null;
            if (dwarfType != DwarfType.Suicide)
            {
                workStrategy = new StandardWorkStrategy(hitsRandomizer);
                buyStrategy = new BuyFoodStrategy();
            }
            else
            {
                workStrategy = new SuicideStrategy();
                buyStrategy = new BuyNoneStrategy();
            }

            return new Dwarf("", dwarfType, workStrategy, buyStrategy);
        }
    }
}
