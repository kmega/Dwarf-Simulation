using DwarfsCity.DwarfContener.DwarfEquipment;
using DwarfsCity;
using System;
using System.Collections.Generic;
using System.Linq;
using DwarfsCity.DwarfContener;

namespace DwarfsCity
{
    public class Bar
    {
        public int SupplyofFood { get; set; } = 200;        
        

        public void GiveAFoodToDwarfs(int supplyoffood, List<Dwarf> Dwarfs)
        {                   
           this.SupplyofFood = SupplyofFood - Dwarfs.Count(); 
            if (SupplyofFood < 0)
            {
                throw new Exception("koniec zapasów, klasa Bar, potrzebny odsyłacz do zakończenia symulacji");
            }
            else if (SupplyofFood <= 10)
                this.SupplyofFood += 30;
        }

    }
}