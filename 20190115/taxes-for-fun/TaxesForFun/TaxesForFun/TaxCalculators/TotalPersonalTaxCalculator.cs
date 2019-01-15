using System; 

namespace TaxesForFun.TaxCalculators
{
    internal class TotalPersonalTaxCalculator : ITaxCalculator
    {
        public int CalculateTax(int receivedMoney)
        {
            int calculatedTax = 0;

            if (receivedMoney <= 85528)
            {

                calculatedTax += new PersonalTaxCalculator().CalculateTax(receivedMoney);
            }

            if (receivedMoney > 85528)
            {
                int moneyAboveSecondTax = receivedMoney - 85528;
                calculatedTax += new PersonalTaxCalculator().CalculateTax(85528);
                calculatedTax += new PersonalSecondTaxCalculator().CalculateTax(moneyAboveSecondTax);
            }

            return calculatedTax;
            //throw new NotImplementedException("Implement me for happiness and joy!");
        }
    }
}