using System;
using System.Collections.Generic;
using System.Text;

namespace Discounts
{
    public class ProductCalc
    {
        IDiscountCalc DiscountCalculator;
        ICalendarDiscountCalculator CalendarDiscount;
        IDataBaseProducts DataBaseProduct;

        public ProductCalc(IDataBaseProducts DataBase)
        {
            DataBaseProduct = DataBase;
        }
        public ProductCalc(IDiscountCalc DiscountCalc, IDataBaseProducts DataBase)
        {
            DiscountCalculator = DiscountCalc;
            DataBaseProduct = DataBase;
        }   
        
        public decimal CalculatePrice(string type)
        {
            if (!DataBaseProduct.DoesProductExist(type))
            {
                return 0.00m;
            }

            if(type == "Ubranie")
            {
                decimal discount = DiscountCalculator.GiveMeDiscount(type);
                decimal price = DataBaseProduct.GivePrice(type);

                price = price - (price * discount);

                return price;
            }
            else if(type == "Buty Zolwia")
            {
                decimal discount = DiscountCalculator.GiveMeDiscount(type);
                decimal price = DataBaseProduct.GivePrice(type);

                price = price - (price * discount);

                return price;
            }
            return 1;
            
        }
    }
}
