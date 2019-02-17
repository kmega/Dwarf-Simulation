using System;
using System.Collections.Generic;
using System.Text;

namespace ThorinsCompany
{
    public class Bar
    {
        private int _foodRations { get; set; }
        public Bar(int foodRations = 200)
        {
            _foodRations = foodRations;
        }
        public void GiveFood()
        {
            if (_foodRations <= 10)
                OrderFood();
            _foodRations--;
        }

        public void OrderFood()
        {
            _foodRations += 30;
        }

        public void GiveFoodForWorkingDwarves(List<Dwarf> dwarves)
        {
            foreach(Dwarf dwarf in dwarves)
            {
                GiveFood();
            }
        }
    }
}
