using System;
using System.Collections.Generic;
using System.Text;

namespace FoodTracks.Model
{
    public class DiscountLottery : IDiscountCalculator
    {
        bool HasDiscount { get; }
        bool HasDoubleDiscount { get; }

        public DiscountLottery()
        {
            Random rnd = new Random();
            if (rnd.Next(1, 100) <= 50)
            {
                HasDiscount = true;
            }
            if (HasDiscount == true && rnd.Next(1,100)<=50)
            {
                HasDoubleDiscount = true;
            }
                
        }

        public DiscountLottery(bool hasDiscount, bool hasDoubleDiscount)
        {
            HasDiscount = hasDiscount;
            HasDoubleDiscount = hasDoubleDiscount;
        }

        public decimal Calculate(decimal burgerPrice)
        {
            if (HasDiscount == true && HasDoubleDiscount == true)
                return (burgerPrice / 2) / 2;
            else if (HasDiscount == true)
                return burgerPrice / 2;
            else return burgerPrice;
        }

        public decimal Calculate()
        {
            throw new NotImplementedException();
        }
    }
}
