using System;
using System.Collections.Generic;
using System.Text;

namespace MockShop
{
    public class ProductCalculator
    {
        private ICalendarDiscountCalculator calendarDiscountCalculator;
        private ITypeDiscountCalculator discountTypeCalculator;
        private IPriceRepo priceRepo;
        public ProductCalculator(ICalendarDiscountCalculator calendarDiscount, 
            ITypeDiscountCalculator discountCalculator, IPriceRepo priceRepo)
        {
            calendarDiscountCalculator = calendarDiscount;
            discountTypeCalculator = discountCalculator;
            this.priceRepo = priceRepo;
        }
        public double Calculate(ProductType productType)
        {
            var originalPrice = priceRepo.GetProductPrice(productType);
            var calendarDsc = calendarDiscountCalculator.Calculate();
            var typeDsc = discountTypeCalculator.Calculate(productType);            
            return originalPrice *(1 - (calendarDsc + typeDsc));
        }
    }
}
