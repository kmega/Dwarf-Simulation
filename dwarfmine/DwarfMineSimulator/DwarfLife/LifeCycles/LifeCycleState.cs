using System;
using System.Collections.Generic;
using DwarfLife.Dwarfs;
using DwarfLife.Buildings.Bank;
using DwarfLife.Buildings.Canteen;
using DwarfLife.Buildings.Graveyard;
using DwarfLife.Buildings.Guild;
using DwarfLife.Buildings.Hospital;
using DwarfLife.Buildings.Mine;
using DwarfLife.Buildings.Shop;

namespace DwarfLife.LifeCycles
{
    public class LifeCycleState
    {
        readonly int _maxDays;
        public int MaxDays => _maxDays;
        public int DaysPassed { get; set; }
        public List<IDwarf> Dwarfs { get; private set; }
        public Bank Bank { get; private set; }
        public Canteen Canteen { get; private set; }
        public Graveyard Graveyard { get; private set; }
        public Guild Guild { get; private set; }
        public Hospital Hospital { get; private set; }
        public Mine Mine { get; private set; }
        public Shop Shop { get; private set; }

        public LifeCycleState(int maxDays = 30)
        {
            _maxDays = maxDays;
            DaysPassed = 0;
            Dwarfs = new List<IDwarf>();
            Bank = new Bank();
            Canteen = new Canteen();
            Graveyard = new Graveyard();
            Guild = new Guild();
            Hospital = new Hospital();
            Mine = new Mine();
            Shop = new Shop();
    }       

        public LifeCycleState(List<IDwarf> dwarfs, int maxDays = 30)
        {
            _maxDays = maxDays;
            DaysPassed = 0;
            Dwarfs = dwarfs;
            Bank = new Bank();
            Canteen = new Canteen();
            Graveyard = new Graveyard();
            Guild = new Guild();
            Hospital = new Hospital();
            Mine = new Mine();
            Shop = new Shop();
        }


    }
}
