using System;

namespace FoodTracks.Model
{
    public class CashRegister
    {
        private readonly IDiscountCalculator _discountCalculator;

        public CashRegister(IDiscountCalculator discountCalculator=null)
        {
            _discountCalculator = discountCalculator;
        }
      
        public decimal HowMuch(Burger burger)
        {
            if (_discountCalculator != null)
            {
                return (ValueBurger(burger) + _discountCalculator.Calculate()) / _discountCalculator.RandomBonus();
            }

            else
            {
                return ValueBurger(burger);
            }
        }

       

        private decimal ValueBurger(Burger burger)
        {
            
            if (!burger.Addons.Contains(AddonType.None))
            {

                return 25;
            }

            else if (burger.Cheeseness == Cheeseness.Double)
            {
                return 20;
            }
            else if (burger.Meet.Type == MeetType.Medium)
            {
                return 10;
            }
            else if (burger.Cheeseness == Cheeseness.Single)
            {
                return 5;
            }


            return 0;
        }
    }
}