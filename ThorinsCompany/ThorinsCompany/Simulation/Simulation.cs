using System;
using System.Collections.Generic;

namespace ThorinsCompany
{
    public class Simulation
    {
        List<Dwarf> _dwarves = new List<Dwarf>();
        private Config _config;

        public Simulation(Config config)
        {
            _config = config;
        }

        public void PerformSimulation()
        {
            for (int i = 0; i < 30; i++)
            {
                _config.Hospital.TryGiveBirthToDwarf(_dwarves);
                //_config.Mine;
               // _config.Cementary;
                _config.Bank.ExchangeMaterialsForMoneyFromAllDwarves(_dwarves);
                _config.Guild.GetTaxesFromDwarvesThatWorked(_dwarves);
                _config.Bar.GiveFoodForWorkingDwarves(_dwarves);
                _config.Shop.PerformShoppingForAllDwarves(_dwarves);
                
            }
        }
    }
}