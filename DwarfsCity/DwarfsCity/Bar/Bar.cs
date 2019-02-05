using DwarfsCity.DwarfContener.DwarfEquipment;
using DwarfsCity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DwarfsCity
{
    public class Bar
    {
        public int SupplyofFood { get; set; } = 200;
        //public Bar()
        //{
            
        //    GiveAFoodToDwarfs(SupplyofFood);
        //}

        public void GiveAFoodToDwarfs(int supplyoffood)
        {
            City city = new City();
            List<DwarfContener.Dwarf> Dwarfs = city.GetDwarfs();
           this.SupplyofFood = SupplyofFood - 10 /*Dwarfs.Count()*/; 
            if (SupplyofFood < 0)
            {
                throw new Exception("koniec zapasów, klasa Bar");
            }
            else if (SupplyofFood <= 10)
                this.SupplyofFood += 30;
         
         

        }

    }
}