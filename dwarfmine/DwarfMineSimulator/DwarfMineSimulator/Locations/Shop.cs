using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfMineSimulator
{
    class Shop
    {
        internal int FoodBought { get; private set; } = 0;

        internal int AlcoholBought { get; private set; } = 0;

        internal decimal EarnedMoney { get; private set; } = 0;

        internal void BuyProducts(List<Dwarf> listOfDwarfs)
        {
            if (listOfDwarfs.Count > 0)
            {
                foreach (var dwarf in listOfDwarfs)
                {
                    if (dwarf.Type == DwarfTypes.Father)
                        FoodBought += 1;

                    if (dwarf.Type == DwarfTypes.Single)
                        AlcoholBought += 1;

                    if (dwarf.Type != DwarfTypes.Lazy)
                        EarnedMoney += 0.5M * dwarf.MoneyEarndedThisDay;
                }
            }
        }

        internal void DisplaySaleValues()
        {
            Console.WriteLine("\n");
            Console.WriteLine("### SHOP ###");
            Console.WriteLine($"Dwarfs bought: {FoodBought} food.");
            Console.WriteLine($"Dwarfs bought: {AlcoholBought} alcohol.");
            Console.WriteLine($"Shop earn: {Math.Round(EarnedMoney,2)}.");
            Console.WriteLine("\n");
            
        }
    }
}
