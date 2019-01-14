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
            else
            {
                return ValueBurger(burger);
            }
        }

        private decimal ValueBurger(Burger burger)
        {
            if(burger.Cheeseness == Cheeseness.Single)
            {
                if(burger.Meet.Type == MeetType.None)
                {
                    return 5;
                }
                if(burger.Addons.Contains(AddonType.Halapenio) 
                    && burger.Addons.Contains(AddonType.Egg))
                {
                    return 25;
                }
                return 10;
            }
            else if(burger.Cheeseness == Cheeseness.Double)
            {
                return 20;
            }
            else
            {
                return 0;
            }
        }
    }
}