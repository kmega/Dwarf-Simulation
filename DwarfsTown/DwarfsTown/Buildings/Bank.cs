using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfsTown
{
    public class Bank : INewsPaper
    {
        public decimal SalaryPerDay {get;set;}
        public decimal SalaryPerDayForAllDwarfs { get; set; }
        public List<string> TheJournalist { get; set ; }

        public void ChangeRawMaterialsIntoMoneys(List<Dwarf> dwarfs)
        {
            City city = new City();
            foreach (Dwarf dwarf in dwarfs)
            {
                ExtractRawMaterialFromBackpack(dwarfs);
                AddSalaryToAccountOfDwarf(dwarfs);
            }
            AddInformation("Bank", "Today all Dwarfs earn " + SalaryPerDayForAllDwarfs);
            SalaryPerDayForAllDwarfs = 0;

        }
        private void AddSalaryToAccountOfDwarf(List <Dwarf> dwarfs)
        {
            foreach (Dwarf dwarf in dwarfs)
            {
                dwarf.BankAccount.Moneys = SalaryPerDay;
                dwarf.Backpack.Materials.Clear();
            }
            SalaryPerDayForAllDwarfs += SalaryPerDay;
            SalaryPerDay = 0;
        }
        public void ExtractRawMaterialFromBackpack(List <Dwarf> dwarfs)
        {
            foreach (Dwarf dwarf in dwarfs)
            {
                if (dwarf.Backpack.Materials.Contains(Materials.Mithril))
                    CalculateValueOfMaterial(20);
                if (dwarf.Backpack.Materials.Contains(Materials.Gold))
                    CalculateValueOfMaterial(15);
                if (dwarf.Backpack.Materials.Contains(Materials.Silver))
                    CalculateValueOfMaterial(10);
                if (dwarf.Backpack.Materials.Contains(Materials.DirtyGold))
                    CalculateValueOfMaterial(5);
            }
        }
        private void CalculateValueOfMaterial(int number)
        {                    
            SalaryPerDay +=number;            
        }

        public void AddInformation(string idBuilding, string message)
        {
            TheJournalist.Add(idBuilding + ": " + message + ".");
        }
    }
}
