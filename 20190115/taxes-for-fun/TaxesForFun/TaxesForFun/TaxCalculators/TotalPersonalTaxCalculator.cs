namespace TaxesForFun.TaxCalculators
{
    public class TotalPersonalTaxCalculator : ITaxCalculator
    {
        public int CalculateTax(int receivedMoney)
        {
            int TotalPersonalTax = 0;
            int reliefAtBeginnign = receivedMoney - 8000;

            if (reliefAtBeginnign > 85528)
            {
                int ToFirstLevelTax = reliefAtBeginnign - 85528;
                //6472 * 0.32 = 2071

                TotalPersonalTax += (int)((85528) * 0.18);
                TotalPersonalTax += (int)((ToFirstLevelTax) * 0.32);

                return TotalPersonalTax;
            }

            return (int)((receivedMoney - 8000) * 0.18);
        }
    }
}
