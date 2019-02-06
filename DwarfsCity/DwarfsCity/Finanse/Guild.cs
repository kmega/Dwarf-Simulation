using DwarfsCity.DwarfContener;
using System;
using System.Collections.Generic;

namespace DwarfsCity
{
    public class Guild
    {
        //private decimal _guildMoney = 0;

        //public void GetMoneyFromDwarfs(List<Dwarf> dwarfs)
        //{
        //    foreach (var dwarfMoney in dwarfs)
        //    {
        //        _guildMoney += 0.20m*dwarfMoney.Backpack.Money;
        //    }
        //}

        //public decimal GetGuildMoney()
        //{
        //    return _guildMoney;
        //}

        //public bool SpendGiuldMoney(decimal amountOfMoneyToSpend)
        //{
        //    if (_guildMoney < amountOfMoneyToSpend)
        //        return false;
        //    else
        //    {
        //        _guildMoney -= amountOfMoneyToSpend;
        //        return true;
        //    }
        //}
                

        public decimal GetTaxesofAllDwarfs(List<Dwarf> dwarfs)
        {
            decimal TheSumOfTaxes = 0;
            foreach (Dwarf dwarf in dwarfs)
            {
                decimal EarnedMoney = dwarf.Backpack.Money;
                decimal TaxesOfGuild = 0.25m * dwarf.Backpack.Money;
                EarnedMoney -= TaxesOfGuild;
                dwarf.Backpack.Money = EarnedMoney;
                TheSumOfTaxes += TaxesOfGuild;
            }
            return TheSumOfTaxes;          
        }
    }
}