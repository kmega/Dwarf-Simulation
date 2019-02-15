using System;
using System.Collections.Generic;

namespace DwarfsTown
{
    public class Guild
    {      
        public decimal GuildMoney {get;set;}
     
        public void GetTaxesFromDwarfsAccounts(List<Dwarf> dwarfs)
        {          
            foreach (Dwarf dwarf in dwarfs)
            {
                dwarf.BankAccount.Moneys = 0.75m * dwarf.BankAccount.Moneys;
                GuildMoney += 0.25m * dwarf.BankAccount.Moneys;
            }
            GuildMoney = GuildMoney;
            AddInformation("Guild", "Today Guild earn " + Math.Round(GuildMoney,2));
        }

        public void AddInformation(string idBuilding, string message)
        {
            City.newsPaper.Add(idBuilding + ": " + message + ".");
        }
    }
}