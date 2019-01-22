using System;

namespace Shop
{
    public class ProductCalculator
    {
        private ICalendarDiscountCalculator calendarDiscount;
        private IDiscountCalculator discountCalculator;
        private IPrice price;

        public ProductCalculator(ICalendarDiscountCalculator calendarDiscount, IDiscountCalculator discountCalculator, IPrice price)
        {
            this.calendarDiscount = calendarDiscount;
            this.discountCalculator = discountCalculator;
            this.price = price;
        }

        public double Calculate(Product product, DateTime date)
        {
            var calendarD = calendarDiscount.Calculate(date);
            var discountD = discountCalculator.Calculate(product.Type);
            var pr = price.ReturnPrice();
            return pr * calendarD * discountD;
        }
    }
}