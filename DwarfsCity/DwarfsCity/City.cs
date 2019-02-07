using DwarfsCity.DwarfContener;
using DwarfsCity.MineContener;
using DwarfsCity.Reports;
using DwarfsCity.ShopContener;
using DwarfsCity.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfsCity
{
    public class City
    {
        List<Dwarf> dwarfs = new List<Dwarf>();       
        //Start simulation
        public void Run()
        {
            //Create new instance hospital, mine, bank, guild, bar, shop, cementary
            Hospital hospital = new Hospital();
            Mine mine = new Mine();
            Bank bank = new Bank();
            Guild guild = new Guild();
            Bar bar = new Bar();
            Shop shop = new Shop();
            Cementary cementary = new Cementary();
            DisplayReport ui = new DisplayReport();
            Report report = new Report();
            var listOfMainClasses = new List<IReport>() { hospital, mine, bank, bar, shop, cementary };

            hospital.InitialiseBasicNumberOfDwarfs(dwarfs, 10);

            for (int i = 0; i < 30; i++)
            {
                //Dwarfs go to minning -> return still alive dwarfs within resources

                try
                {
                    hospital.GiveBirthToDwarf(dwarfs);
                    dwarfs = mine.StartWorking(dwarfs);
                    bank.ExchangeItemsToMoney(dwarfs);
                    guild.GetTaxesofAllDwarfs(dwarfs);
                    bar.GiveAFoodToDwarfs(dwarfs);
                    shop.PerformShopping(dwarfs);
                    report.AnaliseReports(listOfMainClasses);                
                    ui.Display(report);
                }
                catch (Exception)
                {
                    break;
                }

            }
           
        }

        public List<Dwarf> GetDwarfs()
        {
            return dwarfs;
        }
        
    }
    
}
