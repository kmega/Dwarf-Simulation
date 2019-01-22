using System;
namespace DiscountCalcualtorWithMocks
{
    public class DiscountCalculator
    {
        public decimal CalculateFinalDiscount(ICalendarDiscountCalculator calendar, IProduct product)
        {
            decimal ProductDiscount = 1;
            DateTime date1 = new DateTime(2018, 11, 24);
            DateTime date2 = new DateTime(2018, 12, 1);

            if(product.GetProductType() == "Buty")
            {
                ProductDiscount -= 0.3m;
            }

            ProductDiscount -= calendar.SetDiscountByDate();

            return product.GetPrice() * ProductDiscount;
        }
    }
}
