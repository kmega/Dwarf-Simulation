using System;
using System.Collections.Generic;
using System.Text;

namespace MockShop
{
    public class ProductCalculator
    {
        private ICalendarDiscountCalculator calendarDiscountCalculator;
        private IDiscountCalculator discountTypeCalculator;
        private IPriceRepo priceRepo;
        public ProductCalculator(ICalendarDiscountCalculator calendarDiscount, 
            IDiscountCalculator discountCalculator, IPriceRepo priceRepo)
        {
            calendarDiscountCalculator = calendarDiscount;
            discountTypeCalculator = discountCalculator;
            this.priceRepo = priceRepo;
        }
        public double Calculate(DateTime dateTime, Product product)
        {
            var calendarDsc = calendarDiscountCalculator.Calculate(dateTime);
            var typeDsc = discountTypeCalculator.Calculate(product.type);
            var originalPrice = priceRepo.GetProductPrice(product.type);
            return originalPrice * calendarDsc * typeDsc;
        }
    }
}
