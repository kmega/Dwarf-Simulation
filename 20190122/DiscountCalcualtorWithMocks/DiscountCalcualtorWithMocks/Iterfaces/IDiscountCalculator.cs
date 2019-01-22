using System;
namespace DiscountCalcualtorWithMocks
{
    public interface IDiscountCalculator
    {
        decimal CalculateFinalDiscount(ICalendarDiscountCalculator date, IProduct produk);
    }
}
