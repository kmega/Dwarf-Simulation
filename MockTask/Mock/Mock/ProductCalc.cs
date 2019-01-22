using System;
using System.Collections.Generic;
using System.Text;

namespace Mock
{
    public class ProductCalc
    {
        public ProductCalc(IDiscountCalc discountCalc)//, ICalendarDiscountCalculator calendarDiscountCalculator)
        {
            disc = discountCalc;
            //calendar = calendarDiscountCalculator;
        }
        public IDiscountCalc disc { get; set; }
        //public ICalendarDiscountCalculator calendar { get; set; }
        
        public decimal Calculate( string type)
        {
            decimal price = 10;
            price = price * (1 - disc.GiveDiscount(type));// + calendar.GiveDiscount(date));

            return price;
        }

    }
}
