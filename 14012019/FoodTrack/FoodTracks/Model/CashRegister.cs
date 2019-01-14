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
            decimal discount = _discountCalculator == null ? 0.0m : _discountCalculator.Calculate();
            return ValueBurger(burger) + discount;
        }

        private decimal ValueBurger(Burger burger)
        {
            if (burger.Meet.Type == MeetType.Medium && burger.Cheeseness == Cheeseness.Single && burger.Addons.Contains(AddonType.None) == true)
            {
                return 10;
            }
            else if (burger.Meet.Type == MeetType.Medium && burger.Cheeseness == Cheeseness.Double && burger.Addons.Contains(AddonType.None) == true)
            {
                return 20;
            }
            else if (burger.Meet.Type == MeetType.None && burger.Cheeseness == Cheeseness.Single && burger.Addons.Contains(AddonType.None) == true)
            {
                return 5;
            }
            else if (burger.Meet.Type == MeetType.Full && burger.Cheeseness == Cheeseness.Single && burger.Addons.Contains(AddonType.Halapenio) == true && burger.Addons.Contains(AddonType.Egg) == true)
            {
                return 25;
            }

            return 0;
        }
    }
}