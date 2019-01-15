namespace TaxesForFun.TaxCalculators
{
    public interface ITaxCalculator
    {
        int PriceOfGoods { get; set; }
        string Type { get; set; }
        int CalculateTax(int receivedMoney);
    }
}