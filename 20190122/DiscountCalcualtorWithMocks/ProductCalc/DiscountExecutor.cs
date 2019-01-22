using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCalc
{
    public class DiscountExecutor
    {
        public decimal ExecutePriceForOneProduct(ICalendarDiscountCalculator calendarDiscountCalculator, IProduct product)
        {
            decimal finalDiscountValue = 1;

            decimal CalendarDiscountValue = calendarDiscountCalculator.SetDiscountBasedOnCurrentDate();

            decimal ProductTypeDiscountValue = new ProductDiscountCalculator().SetDiscountBasedOnProductType(product);

            return product.GetPrice() * (finalDiscountValue - CalendarDiscountValue - ProductTypeDiscountValue);
        }
    }
}
