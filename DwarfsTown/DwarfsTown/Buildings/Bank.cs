using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfsTown
{
    public class Bank 
    {
        public decimal SalaryPerDay {get;set;}
        public decimal SalaryPerDayForAllDwarfs { get; set; }      

        public void ChangeRawMaterialsIntoMoneys(List<Dwarf> dwarfs)
        {
            foreach (Dwarf dwarf in dwarfs)
            {
                ExtractRawMaterialFromBackpack(dwarf);
                SalaryPerDay = 0;               
            }
            AddInformation("Bank", "Today all Dwarfs earn " + SalaryPerDayForAllDwarfs);
            SalaryPerDayForAllDwarfs = 0;
        }
        private void AddSalaryToAccountOfDwarf(Dwarf dwarf)
        {          
            dwarf.BankAccount.Moneys = SalaryPerDay;
            dwarf.Backpack.Materials.Clear();        
            SalaryPerDayForAllDwarfs += SalaryPerDay;          
        }
        public void ExtractRawMaterialFromBackpack(Dwarf dwarf)
        {          
                if (dwarf.Backpack.Materials.Contains(Materials.Mithril))
                    CalculateValueOfMaterial(20);
                if (dwarf.Backpack.Materials.Contains(Materials.Gold))
                    CalculateValueOfMaterial(15);
                if (dwarf.Backpack.Materials.Contains(Materials.Silver))
                    CalculateValueOfMaterial(10);
                if (dwarf.Backpack.Materials.Contains(Materials.DirtyGold))
                    CalculateValueOfMaterial(5);
                AddSalaryToAccountOfDwarf(dwarf);

        }
        private void CalculateValueOfMaterial(int number)
        {                    
            SalaryPerDay +=number;            
        }
        public void AddInformation(string idBuilding, string message)
        {
            City.newsPaper.Add(idBuilding + ": " + message + ".");
        }
    }
}
