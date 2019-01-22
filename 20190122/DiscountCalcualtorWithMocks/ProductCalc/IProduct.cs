namespace ProductCalc
{
    public interface IProduct
    {
        decimal GetPrice();
        EProductType GetProductType();
    }
}