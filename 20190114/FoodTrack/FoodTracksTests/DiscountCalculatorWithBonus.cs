using FoodTracks.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodTracks
{
  public class DiscountCalculatorWithBonus : IDiscountCalculator
    {
        bool toBe = true;

        public DiscountCalculatorWithBonus (bool tobe)
        {
            toBe = tobe;
        }
        public decimal Calculate()
        {
            if (DateTime.Now == new DateTime(2019, 11, 11))
            {
                return -15;
            }


            return 0;
        }

        public decimal RandomBonus()
        {
            if (toBe)
            {
                return 2;
            }
            else
            {
                return 1;
            }
           
        }
    }
}
