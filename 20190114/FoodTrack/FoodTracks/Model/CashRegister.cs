using System;

namespace FoodTracks.Model
{
    public class CashRegister
    {
        private readonly IDiscountCalculator _discountCalculator;

        public CashRegister()
        {
            _discountCalculator = null;
        }

        public CashRegister(IDiscountCalculator discountCalculator )
        {
            _discountCalculator = discountCalculator;
        }
      
        public decimal HowMuch(Burger burger)
        {
            if (_discountCalculator != null)
                return ValueBurger(burger) + _discountCalculator.Calculate();
            else
                return ValueBurger(burger);

        }

        private decimal ValueBurger(Burger burger)
        {
            if (burger.Name == "cheeseburger")
                return 10;
            else if (burger.Name == "dcheeseburger")
                return 20;
            else if (burger.Name == "vegeburger")
                return 5;
            else if (burger.Name == "englishburger")
                return 25;
            else
                return 0;
        }
    }
}