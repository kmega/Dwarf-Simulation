using System;

namespace FoodTracks.Model
{
    public class CashRegister
    {
        private enum BurgerPrize
        {
            Cheap = 0,
            SingleCheese = 10,
            DoubleCheese = 20,
            English = 25,
            Vege = 5
        }

        public int chance = new Random().Next(2);

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
            if (isCheapBurger(burger)) 
            { 
                return (decimal)BurgerPrize.Cheap;
            }

            if (isVegeBurger(burger)) 
            {
                if (chance == 1) { return (decimal)BurgerPrize.Vege / 2; }
                return (decimal)BurgerPrize.Vege; 
            }

            if (isEnglishBurger(burger)) 
            {
                if (chance == 1) { return (decimal)BurgerPrize.English / 2; }
                return (decimal)BurgerPrize.English; 
            }

            if (isCheeseBurger(burger))
            {
                switch (burger.Cheeseness)
                {
                    case Cheeseness.Single:
                        if (chance == 1) { return (decimal)BurgerPrize.SingleCheese / 2; }
                        return (decimal)BurgerPrize.SingleCheese;
                    case Cheeseness.Double:
                        if (chance == 1) { return (decimal)BurgerPrize.SingleCheese / 2; }
                        return (decimal)BurgerPrize.DoubleCheese;
                }
            }

            return 0;
        }

        public CashRegister() { }
    }
}