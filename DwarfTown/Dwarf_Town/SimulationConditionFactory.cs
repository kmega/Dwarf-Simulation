using Dwarf_Town.Interfaces;
using Dwarf_Town.Locations;
using Dwarf_Town.Locations.Guild;
using Dwarf_Town.Locations.Mine;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dwarf_Town
{
    public static class SimulationConditionFactory
    {

        public static SimulationStartConditions GenerateStandardStartConditions()
        {

            SimulationStartConditions startConditions = new SimulationStartConditions();
            startConditions.Presenter = new WindowsConsole();
            startConditions.Canteen = new Canteen(200);
            startConditions.Dwarves = new List<Dwarf>();
            startConditions.DwarvesBornFirstDay = 10;
            startConditions.Guild = GuildFactory.CreateStandardGuild(startConditions.Presenter);
            startConditions.Hospital = new Hospital(new Chance());
            startConditions.MaxDay = 30;
            startConditions.Mine = MineFactory.CreateStandardMine(startConditions.Presenter);
            startConditions.Shop = new Shop();
            return startConditions;
        }
    }
}
