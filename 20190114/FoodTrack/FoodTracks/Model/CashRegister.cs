using System;
using System.Collections.Generic;
using System.Linq;

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
            return ValueBurger(burger);
        }

        private decimal ValueBurger(Burger burger)
        {
            List<AddonType> EnglishBurger = new List<AddonType>
            {
                AddonType.Halapenio,
                AddonType.Egg
            };

            if (burger.Cheeseness == Cheeseness.Single && burger.Addons.SequenceEqual(EnglishBurger))
            {
                return 25;
            }

            if (burger.Cheeseness == Cheeseness.Single && burger.Meet.Type == MeetType.Medium)
            {
                return 10;
            }

            if (burger.Cheeseness == Cheeseness.Double)
            {
                return 20;
            }

            if (burger.Cheeseness == Cheeseness.Single)
            {
                return 5;
            }
            return 0;
        }
    }
}