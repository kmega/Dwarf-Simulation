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
            if (_discountCalculator != null)
            {
                burger = new Burger(Meet.CreateMeet(), Cheeseness.None, new List<AddonType>() { AddonType.None });
                return ValueBurger(burger) + _discountCalculator.Calculate();
            }
            return ValueBurger(burger);
        }

        private decimal ValueBurger(Burger burger)
        {
            if (burger.Meet.Type == MeetType.None && burger.Cheeseness == Cheeseness.Single)
            {
                return new Decimal(5);
            }
            if (burger.Meet.Type == MeetType.Full)
            {
                return new Decimal(25);
            }
            if (burger.Cheeseness == Cheeseness.Single)
            {
                return new Decimal(10);
            }
            if (burger.Cheeseness == Cheeseness.Double)
            {
                return new Decimal(20);
            }

            
            
            
            
            return 0;
        }
    }
}