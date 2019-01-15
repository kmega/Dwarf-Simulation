using System;
using System.Collections.Generic;
using System.Text;

namespace TaxesForFun.TaxCalculators
{
    public class TotalPersonalTaxCalculator : ITaxCalculator
    {
        public int CalculateTax(int receivedMoney)
        {
            receivedMoney -= 8000;

            if (receivedMoney > 85528)
            {
                int firstLevel = 85528;
                int secondLevel = receivedMoney - 85528;

                return (int)((firstLevel * 0.18) + secondLevel * 0.32);
            }
            else
            {
                return (int)(receivedMoney * 0.18);
            }
        }
    }
}
