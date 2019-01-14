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
			if (_discountCalculator != null)
			{
				return ValueBurger(burger) + _discountCalculator.Calculate();
			}
            return ValueBurger(burger);
        }

        private decimal ValueBurger(Burger burger)
        {
            return burger.Price;
        }
    }
}