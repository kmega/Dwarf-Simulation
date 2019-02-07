using DwarfsCity.DwarfContener;
using DwarfsCity.Reports;
using System.Collections.Generic;
namespace DwarfsCity.ShopContener
{
    public class Shop : IReport
    {
       
        public void PerformShopping(List<Dwarf> dwarfs)
        {
            foreach(Dwarf dwarf in dwarfs)
            {
                if(dwarf.Attribute == Type.Father || dwarf.Attribute == Type.Single)
                {
                    decimal price = dwarf.Backpack.Money / 2;
                    dwarf.Backpack.Money /= 2;
                    string product = dwarf.Attribute == Type.Father ? "Alcohol" : "Food";
                    GiveReport("Dwarf bought " + product + " and paid " + price);
                }
            }
        }
        public void GiveReport(string message)
        {
            Logger.GetInstance().AddLog(message);
        }
    }
}