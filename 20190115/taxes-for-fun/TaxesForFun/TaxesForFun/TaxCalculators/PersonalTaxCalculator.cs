using System;
using System.Collections.Generic;
using System.Text;

namespace TaxesForFun.TaxCalculators
{
    public class PersonalTaxCalculator : ITaxCalculator
    {
 
        public string Type { get; set; }
        public int PriceOfGoods { get; set; }

        public int CalculateTax(int receivedMoney)
        {
            receivedMoney -= PriceOfGoods;
            if(receivedMoney > 85528)
            {
                ITaxCalculator taxCalc = new PersonalTaxCalcSecondLevel();
                return taxCalc.CalculateTax(receivedMoney);
            }
            else
            {
                int taxCredit = 8000;
                return (int)((receivedMoney - taxCredit) * 0.18);
            }
                
        }
    }
}
