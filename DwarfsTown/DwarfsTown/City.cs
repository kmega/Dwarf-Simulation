using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfsTown
{
    public class City
    {

        public List<Dwarf> dwarfs;
        public static Randomizer randomizer;
        public Hospital hospital;
        public Mine mine;
        public Bank bank;
        public Guild guild;
        public Bar bar;
        public Shop shop;
        public Cementary cementary;
        public static List<string> newsPaper;
    
        public City()
        {
            randomizer = new Randomizer();           
            dwarfs = new List<Dwarf>();         
            hospital = new Hospital(dwarfs);
            mine = new Mine();
            bank = new Bank();
            guild = new Guild();
            bar = new Bar();
            shop = new Shop();
            cementary = new Cementary();
            newsPaper = new List<string>();
        }
    }
}
