using DwarfsCity.DwarfContener;
using DwarfsCity.Reports;
using System;
using System.Collections.Generic;

namespace DwarfsCity
{
    public class Guild
    {
        public decimal GeneralGuildFunds { get; set; }
        public decimal TheSumOfTaxesOnOneDay { get; set; }     
        public void GetTaxesofAllDwarfs(List<Dwarf> dwarfs)
        {
            TheSumOfTaxesOnOneDay = 0;
            foreach (Dwarf dwarf in dwarfs)
            {
                decimal TaxesOfGuild = TaxesCalculator(dwarf);
                EarningsCalculator(dwarf, TaxesOfGuild);              
            }            
            ReportGuild();
        }

        private void EarningsCalculator(Dwarf dwarf,decimal taxes)
        {
                decimal EarnedMoney = dwarf.Backpack.Money - taxes;
                dwarf.Backpack.Money = EarnedMoney;
        }

        private decimal TaxesCalculator(Dwarf dwarf)
        {           
            decimal taxes = 0.20m * dwarf.Backpack.Money;
            TheSumOfTaxesOnOneDay += taxes;
            GeneralGuildFunds += TheSumOfTaxesOnOneDay;
            return taxes;
        }

        private void ReportGuild()
        {
             GiveReport("Guild: Today all dwarfs pay " + TheSumOfTaxesOnOneDay + " taxes. The current state of the guild account is " + GeneralGuildFunds + ".");    
        }

        public void GiveReport(string message)
        {
            Logger.GetInstance().AddLog(message);
        }
    }
   
}