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
            DateTime date = DateTime.Today;
            string currentDate = date.ToString("d");

            int day = Convert.ToInt32(currentDate.ToString().Split('-')[2]);
            int month = Convert.ToInt32(currentDate.ToString().Split('-')[1]);

            if (_discountCalculator == null)
            {
                return ValueBurger(burger);
            }
            else
            {
                if (day == 11 && month == 11)
                {
                    return ValueBurger(burger) + _discountCalculator.Calculate();
                }
                else
                {
                    return ValueBurger(burger);
                }
            }
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
            else
            {
                return 0;
            }
        }
    }
}