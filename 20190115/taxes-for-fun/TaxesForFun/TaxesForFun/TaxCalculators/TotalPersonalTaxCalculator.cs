using System;
using System.Collections.Generic;
using System.Text;

namespace TaxesForFun.TaxCalculators
{
    public class TotalPersonalTaxCalculator : ITaxCalculator
    {
        
        public int CalculateTax(int receivedMoney)
        {
            int firstPart = 0;
            int secondPart = 0;
            int taxCredit = 8000;

            receivedMoney = receivedMoney - taxCredit;

            if (receivedMoney > 85528)
            {
                firstPart = (int)(85528 * 0.18);
                secondPart = (int)((receivedMoney - 85528) * 0.32);
            }
            else
            {
                firstPart = (int)(receivedMoney * 0.18);
            }


            return firstPart + secondPart;

        }
    }
}