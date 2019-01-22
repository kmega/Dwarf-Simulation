using System;
using System.Collections.Generic;
using System.Text;

namespace ShopForLearnMock
{
    public class ProductCalc
    {
       public ICalendarDiscountCalculator CalendarDiscountCalculator;
       public IDiscountCalculator DiscountCalculator;
        public IDataBase Database;


       public ProductCalc(ICalendarDiscountCalculator calendarDiscountCalculator,
            IDiscountCalculator discountCalculator, IDataBase database)
        {
            CalendarDiscountCalculator = calendarDiscountCalculator;
            DiscountCalculator = discountCalculator;
            Database = database;


        }

        public double Calculate (DateTime date, Product product)
        {

            double temmprice = Database.Price(product);
            double finalprice = temmprice - DiscountCalculator.CalcDiscount(product);
               finalprice -= CalendarDiscountCalculator.CalcDiscountDate(date);
            return finalprice;
            
        }
    }
}
