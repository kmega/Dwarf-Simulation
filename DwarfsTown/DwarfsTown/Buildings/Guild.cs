using System;
using System.Collections.Generic;

namespace DwarfsTown
{
    public class Guild: INewsPaper
    {      
        public decimal GuildMoney {get;set;}
        public List<string> TheJournalist { get ; set; }

        Bank bank = new Bank();
        public void GetTaxesFromDwarfsAccounts(List<Dwarf> dwarfs)
        {         
            foreach (Dwarf dwarf in dwarfs)
            {
                dwarf.BankAccount.Moneys = 0.75m * dwarf.BankAccount.Moneys;
                GuildMoney += 0.25m * dwarf.BankAccount.Moneys;
            }
            AddInformation("Guild", "Today Guild earn " + GuildMoney);
        }

        public void AddInformation(string idBuilding, string message)
        {
            TheJournalist.Add(idBuilding + ": " + message + ".");
        }
    }
}