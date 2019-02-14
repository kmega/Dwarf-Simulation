using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfsTown
{
    public class Simulation
    {
        public static void Run(City city)
        {
            for (int i = 0; i < 30; i++)
            {
                //Get new dwarf -> 1% saboteur, 33% Father, 33% Single, 33% Lazy
                city.dwarfs.Add(city.hospital.BirthDwarf());
                //Dwarfs go to digging
                city.mine.ExtractRawMaterials(city.dwarfs);
                //Changing materials to moneys and transfer into dwarfs account 
                city.bank.ChangeRawMaterialsIntoMoneys(city.dwarfs);
                //Get taxes from dwarfs Accounts
                city.guild.GetTaxesFromDwarfsAccounts(city.dwarfs);
                //Dwarf go to bar
                city.bar.FeedDwarfs(city.dwarfs);
                //Dwarfs go shopping
                city.shop.DoShopping(city.dwarfs);
                //Display raport from one day
                Displayer.DisplayInformationAfterOneDay(City.newsPaper);
            }
        }

    }
}
