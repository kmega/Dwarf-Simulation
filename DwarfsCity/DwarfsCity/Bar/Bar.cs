using DwarfsCity.DwarfContener.DwarfEquipment;
using DwarfsCity;
using System;
using System.Collections.Generic;
using System.Linq;
using DwarfsCity.DwarfContener;
using DwarfsCity.Reports;

namespace DwarfsCity
{
    public class Bar: IReport
    {
        public int SupplyofFood { get; set; } = 200;    //Zapas jedzenia w sklepie  
        public int GivenFoodToDwarfsDuringOneDay { get; set; } // Jedzenie wydane w danym dniu
        public List<string> Reports { get; set; }

        public void GiveAFoodToDwarfs(List<Dwarf> Dwarfs) //Rozdaje porcje jedzenia wszystkim krasnoludom
        {           
            GivenFoodToDwarfsDuringOneDay = AmountOfFoodGiven(Dwarfs.Count);
            SupplyofFood = SupplyofFood - Dwarfs.Count;
            ReportBar();          
        }

        private int AmountOfFoodGiven(int DwarfsCount)
        {
            if (DwarfsCount > SupplyofFood)
                return (DwarfsCount - SupplyofFood);
            else
                return DwarfsCount;
        }

        private void ReportBar()
        {
            Reports = new List<string>();
            GiveReport("Today "+ GivenFoodToDwarfsDuringOneDay + "get a portion of food. Actual amount of supply in Bar: " + SupplyofFood + ".");
            if (SupplyofFood < 0)
            {
                GiveReport("There is no more food in bar. Only " + GivenFoodToDwarfsDuringOneDay + " get a portion of food. /nThe simulation is over.");
                throw new Exception("Simulation is over. There is no more food.");
            }
            else if (SupplyofFood <= 10)
            {
                this.SupplyofFood += 30;
                GiveReport("Today " + GivenFoodToDwarfsDuringOneDay + "get a portion of food. There is a delivery food to bar. Actual amount of supply in Bar: " + SupplyofFood + ".");
            }            
            else
                GiveReport("Today " + GivenFoodToDwarfsDuringOneDay + "get a portion of food. Actual amount of supply in Bar: " + SupplyofFood + ".");
        }

        public void GiveReport(string message)
        {
            Reports.Add(message);
        }
    }
}