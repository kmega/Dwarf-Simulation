namespace ProductCalc
{
    public interface IProductDiscountCalculator
    {
        decimal SetDiscountBasedOnProductType(IProduct product);
    }
}