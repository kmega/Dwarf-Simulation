namespace TaxesForFun.TaxCalculators
{
    public class SecondLevelTaxCalculator : ITaxCalculator
    {
        public int CalculateTax(int receivedMoney)
        {
            if(receivedMoney > 85528)
            {
                return (int)(receivedMoney * 0.32);
            }
            throw new System.NotImplementedException();
        }
    }
}
