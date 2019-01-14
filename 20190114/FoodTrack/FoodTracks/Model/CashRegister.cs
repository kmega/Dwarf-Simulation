using System;

namespace FoodTracks.Model
{
    public class CashRegister
    {
        public CashRegister()
        {
            _discountCalculator = new DiscountCalculator();
        }

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
            switch (burger.Name)
            {
                case "Cheeseburger":
                    return 10;
                case "DoubleCheeseburger":
                    return 20;
                case "VegeBurger":
                    return 5;
                case "EnglishBurger":
                    return 25;
            }


            return 0;
        }
        

    }
}