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
            Displayer displayer = new Displayer();
            for (int i = 0; i < 30; i++)
            {
                _config.Hospital.TryGiveBirthToDwarf(_dwarves);
                //_config.Mine;
                Cementary.Funeral(_dwarves);
                _config.Mine.PerformMining(_dwarves);
                _config.Bank.ExchangeMaterialsForMoneyFromAllDwarves(_dwarves);
                _config.Guild.GetTaxesFromDwarvesThatWorked(_dwarves);
                _config.Bar.GiveFoodForWorkingDwarves(_dwarves);
                _config.Shop.PerformShoppingForAllDwarves(_dwarves);
                //_config.Displayer.DisplayDailyReport();
                displayer.DisplayDailyReport(i);
                Console.ReadKey();
            }
            displayer.DisplayFinalReport(0);
            Console.ReadKey();
            //_config.Displayer.DisplayFinalReport();
        }
    }
}