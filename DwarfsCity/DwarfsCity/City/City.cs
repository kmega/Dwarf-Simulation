using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfsCity
{
    public class City
    { //Start simulation

        List<DwarfContener.Dwarf> dwarfs = new List<DwarfContener.Dwarf>();
       
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
            


            //


        }
        
    }
    
}
