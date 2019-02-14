using Dwarf_Town.DwarfStrategies.BuyingStrategy;
using Dwarf_Town.DwarfStrategies.WorkingStrategy;
using Dwarf_Town.Interfaces;
using Dwarf_Town.Interfaces.SellingStrategy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dwarf_Town.Models
{
    public static class DwarfFactory
    {

        public static Dwarf CreateDwarf(int chance)
        {
            Dwarf dwarf = new Dwarf();


               if (chance == 1)
            {
                //Create Suicide Dwarf
                dwarf.WorkStrategy = new SuicideStrategy();
            }
             else if (chance <= 34)
            {
                //Create Dwarf Father
                dwarf.BuyStrategy = new FoodBuyingStrategy();
                dwarf.SellStrategy = new StandardSellingStrategy(dwarf.Backpack, dwarf.Wallet);
                dwarf.WorkStrategy = new DigStrategy(dwarf.Backpack);
                   
            }
            else if (chance <= 67)
            {
                //Create Dwarf Single
                dwarf.BuyStrategy = new AlcoholBuyingStrategy();
                dwarf.SellStrategy = new StandardSellingStrategy(dwarf.Backpack, dwarf.Wallet);
                dwarf.WorkStrategy = new DigStrategy(dwarf.Backpack);
            }
               else
            {
                dwarf.BuyStrategy = new NothingBuyingStrategy();
                dwarf.SellStrategy = new StandardSellingStrategy(dwarf.Backpack, dwarf.Wallet);
                dwarf.WorkStrategy = new DigStrategy(dwarf.Backpack);

            }
            return dwarf;






        }


    }
}
