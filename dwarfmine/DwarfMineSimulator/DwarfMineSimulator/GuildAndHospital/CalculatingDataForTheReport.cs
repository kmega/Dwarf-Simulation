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
                Raport.FatherBorn++;
            }
            else if (dwarfTypes == DwarfTypes.Lazy)
            {
                Raport.LazyBorn++;
            }
            else if (dwarfTypes == DwarfTypes.Single)
            {
                Raport.SingleBorn++;
            }
            else if (dwarfTypes == DwarfTypes.Suicider)
            {
                Raport.SuiciderBorn++;
            }
            Raport.TotalBorn++;
        }

        public void MoneyAndTaxFromGuild(decimal earnedMoney, decimal taxMoney)
        {
            Raport.TotalMoneyEarned += earnedMoney;
            Raport.TaxedMoney += taxMoney;
        }
    }
}
