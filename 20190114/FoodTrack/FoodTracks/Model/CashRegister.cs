using System;

namespace FoodTracks.Model
{
    public class CashRegister
    {
        private readonly IDiscountCalculator _discountCalculator;


        public CashRegister()
        {
            _discountCalculator = new DiscountCalculator();
        }

        public CashRegister(IDiscountCalculator discountCalculator = null)
        {
            _discountCalculator = new DiscountCalculator();
        }
               

        public decimal HowMuch(Burger burger)

        {
            
            if (_discountCalculator == null && burger == null)
            {
                return 0;
            }
            else
            {
                return ValueBurger(burger) + _discountCalculator.Calculate();
            }
           
        }

        private decimal ValueBurger(Burger burger)
        {
            if (burger == null)
            {
                return 0;
            }
            else if (burger.Name == "Cheeseburger")
            {
                return 10;
            }
            else if (burger.Name == "DoubleCheeseburger")
            {
                return 20;
            }
            else if (burger.Name == "VegeBurger")
            {
                return 5;
            }else if(burger.Name == "EnglishBurger")
            {
                return 25;
            }

            return 0;
        }
    }
}