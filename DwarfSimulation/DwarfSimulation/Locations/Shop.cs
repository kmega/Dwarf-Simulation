using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfSimulation
{
    internal class Shop
    {
        int Food { get; set; }
        public int Alcohol { get; set; }

     

       internal void BuyAlcohol(int i)
        {
            Alcohol = i;
        }
    }
}
