using System;

namespace FoodTracks.Model
{
    public class CashRegister
    {
        private readonly IDiscountCalculator _discountCalculator;
        private readonly IRandomDiscount _randomDiscountCalculator;
        public bool HasDiscount { get; private set; }

        public CashRegister(IDiscountCalculator discountCalculator = null)
        {
            _discountCalculator = discountCalculator;
        }
        public CashRegister(IRandomDiscount randomDiscount)
        {
            _randomDiscountCalculator = randomDiscount;
        }

        public decimal HowMuch(Burger burger)
        {
            if (_discountCalculator != null)
            {
                return CalculateFinalPrice(ValueBurger(burger) + _discountCalculator.Calculate());
            }
            else
            {
                return CalculateFinalPrice(ValueBurger(burger));
            }
        }
        private decimal CalculateFinalPrice(decimal price)
        {
            if(_randomDiscountCalculator != null)
            {
                HasDiscount = _randomDiscountCalculator.DrawDiscount();
            }           
            if(HasDiscount)
            {
                return price / 2;
            }
            else
            {
                return price;
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