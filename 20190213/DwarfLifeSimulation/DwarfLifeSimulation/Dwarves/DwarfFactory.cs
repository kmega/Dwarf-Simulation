using DwarfLifeSimulation.Dwarves.BuyStrategies;
using DwarfLifeSimulation.Dwarves.WorkStrategies;
using DwarfLifeSimulation.Enums;
using DwarfLifeSimulation.Dwarves.Interfaces;
using DwarfLifeSimulation.Randomizer.DwarfNameRandomizer;
using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfLifeSimulation.Dwarves
{
    public class DwarfFactory
    {
        private IDwarfNameRandomizer _dwarfNameRandomizer;

        public DwarfFactory(IDwarfNameRandomizer dwarfNameRandomizer)
        {
            _dwarfNameRandomizer = (dwarfNameRandomizer != null) ? dwarfNameRandomizer : new DwarfNameGenerationStrategy();
        }

        public Dwarf Create(DwarfType dwarfType)
        {
            string name = _dwarfNameRandomizer.GiveMeDwarfName();
            switch(dwarfType)
            {
                default:
                case DwarfType.Father:
                    return new Dwarf(name, dwarfType, new StandardWorkStrategy(), new BuyFoodStrategy());
                case DwarfType.Single:
                    return new Dwarf(name, dwarfType, new StandardWorkStrategy(), new BuyAlcoholStrategy());
                case DwarfType.Sluggard:
                    return new Dwarf(name, dwarfType, new StandardWorkStrategy(), new BuyNoneStrategy());
                case DwarfType.Suicide:
                    return new Dwarf(name, dwarfType, new SuicideStrategy(), new BuyNoneStrategy());              
            }

        }
    }
}
