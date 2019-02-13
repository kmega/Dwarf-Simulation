using DwarfLifeSimulation.Dwarves.BuyStrategies;
using DwarfLifeSimulation.Dwarves.WorkStrategies;
using DwarfLifeSimulation.Enums;
using DwarfLifeSimulation.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfLifeSimulation.Dwarves
{
    public static class DwarfFactory
    {
        public static Dwarf Create(DwarfType dwarfType)
        {
            string name = "Stefan"; //INameRandomizer.Generate();
            switch(dwarfType)
            {
                default:
                case DwarfType.Father:
                    return new Dwarf(name, new StandardWorkStrategy(), new BuyFoodStrategy());
                case DwarfType.Single:
                    return new Dwarf(name, new StandardWorkStrategy(), new BuyAlcoholStrategy());
                case DwarfType.Sluggard:
                    return new Dwarf(name, new StandardWorkStrategy(), new BuyNoneStrategy());
                case DwarfType.Suicide:
                    return new Dwarf(name, new SuicideStrategy(), new BuyNoneStrategy());              
            }

        }
    }
}
