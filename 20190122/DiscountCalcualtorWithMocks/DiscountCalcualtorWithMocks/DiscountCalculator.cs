using System;
namespace DiscountCalcualtorWithMocks
{
    public class DiscountCalculator
    {
        public decimal CalculateFinalDiscount(ICalendarDiscountCalculator calendar, IProduct product)
        {
            decimal ProductDiscount = 0;
            DateTime date1 = new DateTime(2018, 11, 24);
            DateTime date2 = new DateTime(2018, 12, 1);
            var inputDate = calendar.SetDiscountByDate();

            if (product.GetProductType() ==  "Buty")
                ProductDiscount = 1.2m;
            else
                ProductDiscount = 0.2m;

            if (DateTime.Compare(inputDate, date1) == 0)
                {
                ProductDiscount += 0.2m;
            }
            else if (DateTime.Compare(inputDate, date2) == 0)
            {
                ProductDiscount += 0.5m;
            }

            return product.GetPrice() * ProductDiscount;
        }
    }
}
