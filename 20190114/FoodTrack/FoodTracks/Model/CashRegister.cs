using System;

namespace FoodTracks.Model
{
    public class CashRegister
    {
        private bool isCheapBurger(Burger burger)
        {
            if (burger.Meet.Type.Equals(MeetType.None) &&
                burger.Cheeseness.Equals(Cheeseness.None) &&
                burger.Addons.Contains(AddonType.None))
            {
                return true;
            }

            return false;
        }

        private bool isCheeseBurger(Burger burger)
        {
            if (!burger.Cheeseness.Equals(Cheeseness.None))
            {
                return true;
            }

            return false;
        }

        private bool isEnglishBurger(Burger burger)
        {
            if (burger.Meet.Type.Equals(MeetType.Full) &&
                burger.Cheeseness.Equals(Cheeseness.Single) &&
                burger.Addons.Contains(AddonType.Halapenio) &&
                burger.Addons.Contains(AddonType.Egg))
            {
                return true;
            }

            return false;
        }

        private bool isVegeBurger(Burger burger)
        {
            if (burger.Meet.Type.Equals(MeetType.None))
            {
                return true;
            }

            return false;
        }

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

            return ValueBurger(burger) + _discountCalculator.Calculate();
        }

        private decimal ValueBurger(Burger burger)
        {
            if (isCheapBurger(burger)) { return 0; }
            if (isVegeBurger(burger)) { return 5; }
            if (isEnglishBurger(burger)) { return 25; }
            if (isCheeseBurger(burger))
            {
                switch (burger.Cheeseness)
                {
                    case Cheeseness.Single:
                        return 10;
                    case Cheeseness.Double:
                        return 20;
                }
            }

            return 0;
        }

        public CashRegister() { }
    }
}