using System;
using System.Collections.Generic;
using System.Text;

namespace FoodTracks.Model
{
    public class AddDiscount
    {
        public decimal Discoutn50PerCent(CashRegister cashRegister, Burger burger, bool flag)
        {
            decimal price;
            if (flag)
            {
                price = (cashRegister.HowMuch(burger))/2;
                return price;
            }

            price = (cashRegister.HowMuch(burger));
            return price;
        }

        public bool Draw()
        {
            var discount = Math.Round(1.9, 0);
            return (1 > discount);
        }
    }
}
