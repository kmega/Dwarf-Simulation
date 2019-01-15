using System;
using System.Collections.Generic;
using System.Text;

namespace TaxesForFun.TaxCalculators
{
    public class TotalPersonalTaxCalculator : ITaxCalculator
    {
        public int CalculateTax(int receivedMoney)
        {
            int belowMoney, aboveMoney;
            int belowTax;
            if(receivedMoney > 85528)
            {
                belowMoney = 85528;
                aboveMoney = receivedMoney - 85528;
                belowTax = new PersonalTaxCalculator().CalculateTax(belowMoney);
                return new PersonalTaxCalculatorSecondStage().CalculateTax(aboveMoney) + belowTax;
            }
            else
            {
                return new PersonalTaxCalculator().CalculateTax(receivedMoney);
            }
        }
    }
}
