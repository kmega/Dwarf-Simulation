using System;
using DwarfsCity.DwarfContener.DwarfEquipment;
using System.Collections.Generic;
using DwarfsCity;
using DwarfsCity.DwarfContener;


namespace DwarfsCity
{
    public class Bank
    {

        // Get Items from Backpack
        City city = new City();
        public Bank()
        {
            city.GetDwarfs();
            List<Dwarf> Dwarfs = city.GetDwarfs();
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