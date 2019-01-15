using System;
using System.Collections.Generic;
using System.Text;

namespace TaxesForFun.TaxCalculators
{
    public class PersonalTaxCalculator : ITaxCalculator
    {
		int taxCredit = 8000;
		public int CalculateTax(int receivedMoney)
        {
			return (int)((receivedMoney - taxCredit ) * 0.18);
        }
    }
}
