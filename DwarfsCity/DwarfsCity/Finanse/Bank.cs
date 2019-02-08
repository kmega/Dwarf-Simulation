using System;
using DwarfsCity.DwarfContener.DwarfEquipment;
using System.Collections.Generic;
using DwarfsCity.DwarfContener;

namespace DwarfsCity
{
    public class Bank
    {

        // Get Items from Backpack
        City city = new City();
        public Bank()
        {
            
            List<Dwarf> Dwarfs = city.GetDwarfs();
            foreach(Dwarf dwarf in Dwarfs)
            {
                Backpack backpack = dwarf.Backpack;
            }
            
        }
        
        // Change Items to Money
        
        // return Money
        public decimal ReturnMoney()
        {
            decimal returnMoney = 0;
            return returnMoney;
        }
    }
}