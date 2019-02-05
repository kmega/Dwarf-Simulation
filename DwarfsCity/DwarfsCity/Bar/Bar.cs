using DwarfsCity.DwarfContener.DwarfEquipment;
using DwarfsCity;
using System;

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

           this.SupplyofFood = SupplyofFood - 10; 
            if (SupplyofFood < 0)
            {
                throw new Exception("koniec zapasów, klasa Bar");
            }
            else if (SupplyofFood <= 10)
                this.SupplyofFood += 30;
         
            //minus dlugosclistykrasnali

        }

    }
}