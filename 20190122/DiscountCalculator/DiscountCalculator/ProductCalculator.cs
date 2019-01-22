using System;
using System.Collections.Generic;
using System.Text;

namespace DiscountCalculator
{
    public class ProductCalculator
    {
        private ICalendarDiscountCalculator _calendarCalc;
        private IDiscountCalculator _typeCalc;

        public virtual double Calculate(DateTime date, Product product)
        {
            double discount = 1;

            
                discount = _calendarCalc.CalculateDiscount(date);
                discount += _typeCalc.CalculateDiscount(product.ProductType);


            return product.Price * discount;
        }
    }
}
