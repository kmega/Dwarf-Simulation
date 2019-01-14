using System;

namespace FoodTracks.Model
{
    public class CashRegister
    {
        private readonly IDiscountCalculator _discountCalculator;

        public CashRegister(IDiscountCalculator discountCalculator = null)
        {
            if (discountCalculator == null)
                discountCalculator = new DiscountCalculator();
            
            _discountCalculator = discountCalculator;
        }
      
        public decimal HowMuch(Burger burger)
        {
            
            return ValueBurger(burger) + _discountCalculator.Calculate();
        }

        private decimal ValueBurger(Burger burger)
        {
            if (burger.BurgerType == BurgerType.Chesseburger)
                return 10;
            if (burger.BurgerType == BurgerType.Doublecheesseburger)
                return 20;
            if (burger.BurgerType == BurgerType.Vegeburger)
                return 5;
            if (burger.BurgerType == BurgerType.Englishburger)
                return 25;
            return 0;
        }
    }
}