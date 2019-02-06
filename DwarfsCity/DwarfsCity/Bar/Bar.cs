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
        //public Bar()
        //{ //zostawiam tu konstruktor, który wywoła całość kodu z klasy jakby był potrzebny
        //    City city = new City();
        //    List<Dwarf> Dwarfs = city.GetDwarfs();
        //    GiveAFoodToDwarfs(SupplyofFood, Dwarfs);
        //}

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