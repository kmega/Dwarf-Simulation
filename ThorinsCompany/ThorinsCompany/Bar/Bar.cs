using System;
using System.Collections.Generic;
using System.Text;

namespace ThorinsCompany
{
    public class Bar : IBar
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
    }
}
