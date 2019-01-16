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
                        
            if(_discountCalculator != null)
            {
                
                return ValueBurger(burger) + _discountCalculator.Calculate();
            }
            else  
            return ValueBurger(burger);
        }
        

        private decimal ValueBurger(Burger burger)
        {
            if(burger.Cheeseness == Cheeseness.Single)
            {
                return 10;
            }
            if(burger.Cheeseness == Cheeseness.Double)
            {
                return 20;
            }

            return 0;
        }
    }
}