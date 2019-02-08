using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfMineSimulator
{
    class Shop
    {
        public int FoodBought { get; private set; } = 0;

        public int AlcoholBought { get; private set; } = 0;

        public decimal EarnedMoney { get; private set; } = 0;

        internal void BuyProducts(List<Dwarf> listOfDwarfs)
        {
            if (listOfDwarfs.Count > 0)
            {
                foreach (var dwarf in listOfDwarfs)
                {
                    if (dwarf.Type == DwarfTypes.Father)
                    {
                        FoodBought += 1;
                        EarnedMoney += 0.5M * (dwarf.MoneyEarndedThisDay);
                    }
                    if (dwarf.Type == DwarfTypes.Single)
                    {
                        AlcoholBought += 1;
                        EarnedMoney += 0.5M * dwarf.MoneyEarndedThisDay;
                    }
                }
            }
        }

        internal void DisplaySaleValues()
        {
            Console.WriteLine("\n");
            Console.WriteLine("### SHOP ###");
            Console.WriteLine($"Dwarfs bought: {FoodBought} food.");
            Console.WriteLine($"Dwarfs bought: {AlcoholBought} alcohol.");
            Console.WriteLine($"Shop earn: {EarnedMoney}.");
            Console.WriteLine("\n");
        }
    }
}
