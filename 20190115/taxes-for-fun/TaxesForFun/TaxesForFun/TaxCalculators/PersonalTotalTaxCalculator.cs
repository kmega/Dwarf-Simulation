using System;
using System.Collections.Generic;
using System.Text;

namespace TaxesForFun.TaxCalculators
{
    public class PersonalTotalTaxCalculator : ITaxCalculator
    {
        public int CalculateTax(int receivedMoney)
        {
            PersonalTaxCalculator personalTax = new PersonalTaxCalculator();
            PersonalSecondTaxCalculator personalSecTax = new PersonalSecondTaxCalculator();


            int firstReceivedMoney = 0;
            int secondReceivedMoney = 0;
            int Tax1 = 0;
            int Tax2 = 0;
            int fullTax = 0;

            if (receivedMoney < 85528)
            {              
                fullTax = personalTax.CalculateTax(receivedMoney);
            }   
            else if(receivedMoney >= 85528)
            {
                firstReceivedMoney = 85528;
                secondReceivedMoney = receivedMoney - 85528;
                Tax1 = personalTax.CalculateTax(firstReceivedMoney);
                Tax2 = personalSecTax.CalculateTax(secondReceivedMoney);
                fullTax = Tax1 + Tax2;
            }
            return fullTax;
        }
    }
}
