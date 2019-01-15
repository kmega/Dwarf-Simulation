using System;
using System.Collections.Generic;
using System.Text;

namespace TaxesForFun.TaxCalculators
{
    class TotalPersonalTaxCalculator : ITaxCalculator
    {
        int taxLevel = 85528;
        public int CalculateTax(int receivedMoney)
        {
            
            if (receivedMoney > taxLevel)
            {
                int lvl2Tax = receivedMoney - taxLevel;
                int lvl1Tax = new PersonalTaxCalculator().CalculateTax(taxLevel);
                return (int)(lvl1Tax + lvl2Tax * 0.32);
            }
            else return new PersonalTaxCalculator().CalculateTax(receivedMoney);

        }
    }
}
