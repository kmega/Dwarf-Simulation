using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace DiscountApp
{
    public class ProductCalculator
    {
        public ProductCalculator(ICalendarDiscountCalculator calendarDiscount, IDiscountCalc discountCalculator, IPriceProduct productPrice, IProductExist productExist)
        {
            _calendarDiscount = calendarDiscount;
            _diescountCalc = discountCalculator;
            _productPrice = productPrice;
            _productExist = productExist;
        }


        public ICalendarDiscountCalculator _calendarDiscount;
        public IDiscountCalc _diescountCalc;
        public IPriceProduct _productPrice;
        public IProductExist _productExist;


        public decimal Calculate(DateTime Day, Product product)
        {

            if (!_productExist.ProductExist())
            {
                return 0.00m;
            }

            return _productPrice.Price(product.Typ) * (1 - (_calendarDiscount.CalendarDiscount(Day) + _diescountCalc.DiscountCalc(product.Typ)));

        }
    }
}
