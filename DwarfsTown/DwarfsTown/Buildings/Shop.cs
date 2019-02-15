using System;
using System.Collections.Generic;

namespace DwarfsTown
{
    public class Shop : INewsPaper
    {
        public decimal AlcoholPurchased { get; set; }
        public decimal FoodPurchased { get; set; }
        public List<string> TheJournalist { get ; set; }
        private decimal ShopFinances { get; set; }

        public void DoShopping(List<Dwarf> dwarfs)
        {
            foreach (Dwarf dwarf in dwarfs)
            {
                DoShoppingAndGetMoneyForThem(dwarf);                        
            }
            ShopFinances = AlcoholPurchased + FoodPurchased;
            AddInformation("Shop", "Today Shop earn "+ ShopFinances +". Dwarfs spend " + AlcoholPurchased  
                + " for alcohol and " + FoodPurchased +" for food.");
            AlcoholPurchased = 0;
            FoodPurchased = 0;
        }

        private void DoShoppingAndGetMoneyForThem(Dwarf dwarf)
        {
            if (dwarf.Type == TypeEnum.Father)
            {
                FoodPurchased += dwarf.BankAccount.Moneys;
                dwarf.BankAccount.Moneys = 0.5m * dwarf.BankAccount.Moneys;
            }
            else if (dwarf.Type == TypeEnum.Single)
            {
                AlcoholPurchased += dwarf.BankAccount.Moneys;
                dwarf.BankAccount.Moneys = 0.5m * dwarf.BankAccount.Moneys;
            }           
        }
        public void AddInformation(string idBuilding, string message)
        {
            TheJournalist.Add(idBuilding + ": " + message);
        }
    }
}