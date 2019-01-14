using System;
using System.Collections.Generic;

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

            if (_discountCalculator == null)
            {
                return ValueBurger(burger);
            }
            else
            {
                return ValueBurger(burger) + _discountCalculator.Calculate();
            }
            
            //return ValueBurger(burger);
        }

        private decimal ValueBurger(Burger burger)
        {
            
            if (burger.Cheeseness == Cheeseness.None && burger.Meet.Type == MeetType.None)
            {
                return 0;
            }
            else if (burger.Cheeseness == Cheeseness.Single && burger.Meet.Type == MeetType.Medium)
            {
                return 10;
            }
            else if (burger.Cheeseness == Cheeseness.Double && burger.Meet.Type == MeetType.Medium)
            {
                return 20;
            }
            else if (burger.Cheeseness == Cheeseness.Single && burger.Meet.Type == MeetType.None)
            {
                return 5;
            }
            else if (burger.Cheeseness == Cheeseness.Single && burger.Meet.Type == MeetType.Full
                && burger.Addons[0] == AddonType.Halapenio
                && burger.Addons[1] == AddonType.Egg)
            {
                return 25;
            }
            else
            {
                return 0;
            }
            
        }
    }
}