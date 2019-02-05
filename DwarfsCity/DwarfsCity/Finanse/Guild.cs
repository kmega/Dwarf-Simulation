using DwarfsCity.DwarfContener;
using System;
using System.Collections.Generic;

namespace DwarfsCity
{
    public class Guild
    {
        //public Guild()
        //{ //konstruktor na wypadek jakby był potrzebny
        //    City city = new City();
        //    List<Dwarf> Dwarfs = city.GetDwarfs();
        //    GetTaxesofAllDwarfs(Dwarfs);           
        //}
        public decimal GetTaxesofAllDwarfs(List<Dwarf> dwarfs)
        {
            decimal TheSumOfTaxes = 0;
            foreach (Dwarf dwarf in dwarfs)
            {
                decimal EarnedMoney = dwarf.Backpack.Moneys;
                decimal TaxesOfGuild = 0.25m * dwarf.Backpack.Moneys;
                EarnedMoney -= TaxesOfGuild;
                dwarf.Backpack.Moneys = EarnedMoney;
                TheSumOfTaxes += TaxesOfGuild;
            }
            return TheSumOfTaxes;          
        }
    }
}