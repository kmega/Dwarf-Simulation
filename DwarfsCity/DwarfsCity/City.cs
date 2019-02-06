using DwarfsCity.DwarfContener;
using DwarfsCity.MineContener;
using DwarfsCity.ShopContener;
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

            hospital.InitialiseBasicNumberOfDwarfs(dwarfs, 12);

            //Dwarfs go to minning -> return still alive dwarfs within resources
            dwarfs = mine.StartWorking(dwarfs);


        }

        public List<Dwarf> GetDwarfs()
        {
            return dwarfs;
        }
        
    }
    
}
