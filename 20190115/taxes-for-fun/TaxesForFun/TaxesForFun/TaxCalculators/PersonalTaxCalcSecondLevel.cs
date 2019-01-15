using System;
using System.Collections.Generic;
using System.Text;

namespace TaxesForFun.TaxCalculators
{
    public class PersonalTaxCalcSecondLevel : ITaxCalculator
    {
        public string Type { get; set; }
        public int PriceOfGoods { get; set; }

        public int CalculateTax(int receivedMoney)
        {

            int sum = 0;
            if (receivedMoney == 10000)
            {
                return (int)(receivedMoney * 0.32);
            }
            else if (receivedMoney > 10000)
            {
                ITaxCalculator taxFreeCalc = new PersonalTaxCalculator();
                int tax_1 = taxFreeCalc.CalculateTax(85528);
                int tax_2 = (int)((receivedMoney - 85528)*0.32);
                sum = tax_1 + tax_2;

                return sum;
            }
            else return sum;

        }
    }
}
