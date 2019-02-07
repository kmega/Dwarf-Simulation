using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfMineSimulator
{
    class CalculatingDataForTheReport
    {
        public void NumberOfBirthsAndTypes(DwarfTypes dwarfTypes)
        {
            if (dwarfTypes == DwarfTypes.Father)
            {
                Simulation.FatherBorn++;
            }
            else if (dwarfTypes == DwarfTypes.Lazy)
            {
                Simulation.LazyBorn++;
            }
            else if (dwarfTypes == DwarfTypes.Single)
            {
                Simulation.SingleBorn++;
            }
            else if (dwarfTypes == DwarfTypes.Suicider)
            {
                Simulation.SuiciderBorn++;
            }
            Simulation.TotalBorn++;
        }

        public void MoneyAndTaxFromGuild(decimal earnedMoney, decimal taxMoney)
        {
            Simulation.TotalMoneyEarned += earnedMoney;
            Simulation.TaxedMoney += taxMoney;
        }
    }
}
