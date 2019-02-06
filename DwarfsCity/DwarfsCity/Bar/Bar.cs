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

        public void GiveAFoodToDwarfs(int supplyoffood, List<Dwarf> Dwarfs) //Rozdaje porcje jedzenia wszystkim krasnoludom
        {           
            this.GivenFoodToDwarfsDuringOneDay = Dwarfs.Count;         
            this.SupplyofFood = SupplyofFood - GivenFoodToDwarfsDuringOneDay; 
            if (SupplyofFood < 0)
            {
                throw new Exception("There is no more food in bar. The simulation is over");
            }
            else if (SupplyofFood <= 10)
                this.SupplyofFood += 30;
            ReportBar();
        }

        private void ReportBar()
        {
            Reports = new List<string>();
            GiveReport("Today "+ GivenFoodToDwarfsDuringOneDay + "get a portion of food. Actual amount of supply in Bar: " + SupplyofFood + ".");
        }

        public void GiveReport(string message)
        {
            Reports.Add(message);
        }
    }
}