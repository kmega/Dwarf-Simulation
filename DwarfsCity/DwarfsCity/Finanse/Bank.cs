using System.Collections.Generic;
using DwarfsCity.DwarfContener;
using DwarfsCity.DwarfContener.DwarfEquipment;
using DwarfsCity.Reports;
using DwarfsCity.Tools;

namespace DwarfsCity
{
    public class Bank : IReport
    {

        public void ExchangeItemsToMoney(List<Dwarf> dwarfs)
        {
            decimal totalPayment = 0;
            foreach(Dwarf dwarf in dwarfs)
            {
                decimal payment = 0;
                for(int i=0;i<dwarf.Backpack.Items.Count;i++ )
                {
                    Item item = dwarf.Backpack.Items[i];
                    decimal valueOfitem = Randomizer.ValueOfItem(item);
                    payment += valueOfitem;
                    dwarf.Backpack.Items.Remove(item);
                }
                dwarf.Backpack.Money += payment;
                totalPayment += payment;
                GiveReport("Dwarf gets " + payment + " money for items");
            }
        }

        public void GiveReport(string message)
        {
            Logger.GetInstance().AddLog(message);
        }
    }
}