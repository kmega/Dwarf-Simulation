namespace TaxesForFun.TaxCalculators
{
    public class TotalPersonalTaxCalculator : ITaxCalculator
    {
        public int CalculateTax(int receivedMoney)
        {
            int TotalPersonalTax = 0;

            if(receivedMoney > 85528)
            {
                int ToFirstLevelTax = receivedMoney - 85528;

                TotalPersonalTax += (int)((85528 - 8000) * 0.18);
                TotalPersonalTax += (int)((ToFirstLevelTax) * 0.32);

                return TotalPersonalTax;
            }

            return (int)((receivedMoney - 8000) * 0.18);
        }
    }
}
