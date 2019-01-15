using System;

namespace FoodTracks.Model
{
    public class CashRegister
    {
        private readonly IDiscountCalculator _discountCalculator;

        public CashRegister(IDiscountCalculator discountCalculator = null)
        {
            _discountCalculator = discountCalculator;
        }
      
        public decimal HowMuch(Burger burger)
        {
            return ValueBurger(burger) + _discountCalculator.Calculate();
        }

        private decimal ValueBurger(Burger burger)
        {
            return 0;
        }
    }
}