using System;

namespace FoodTracks.Model
{
    public class CashRegister
    {
        private readonly IDiscountCalculator _discountCalculator;
        private readonly IDiscountCalculator _50PercentChance;

        public CashRegister(IDiscountCalculator discountCalculator = null)
        {
            _discountCalculator = discountCalculator;
        }
      
        public decimal HowMuch(Burger burger)
        {
            if (_50PercentChance != null)
            {
                return ValueBurger(burger) - (ValueBurger(burger) * _50PercentChance.Calculate()) ;
            }

            if (_discountCalculator == null) return ValueBurger(burger);
           
            return ValueBurger(burger) + _discountCalculator.Calculate();
        }

        private decimal ValueBurger(Burger burger)
        {

            //Calculate cost for cheesburger
            if ((burger.Meet.Type == MeetType.Medium) &&
            (burger.Cheeseness == Cheeseness.Single)&&
            (burger.Addons.Contains(AddonType.None) == true))
            {
                return 10;
            }
            //Calculate cost for double cheesburger
            if ((burger.Meet.Type == MeetType.Medium) &&
            (burger.Cheeseness == Cheeseness.Double) &&
            (burger.Addons.Contains(AddonType.None) == true))
            {
                return 20;
            }
            //Calculate cost for vege burger
            if ((burger.Meet.Type == MeetType.None) &&
            (burger.Cheeseness == Cheeseness.Single) &&
            (burger.Addons.Contains(AddonType.None) == true))
            {
                return 5;
            }
            //Calculate cost for vege burger
            if ((burger.Meet.Type == MeetType.Full) &&
            (burger.Cheeseness == Cheeseness.Single) &&
            (burger.Addons.Contains(AddonType.Egg) == true)&&
            (burger.Addons.Contains(AddonType.Halapenio) == true))
            {
                return 25;
            }
            return 0;
        }
    }
}