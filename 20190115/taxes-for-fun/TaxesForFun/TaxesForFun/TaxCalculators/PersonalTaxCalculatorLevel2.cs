using System;
using System.Collections.Generic;
using System.Text;

namespace TaxesForFun.TaxCalculators
{
	public class PersonalTaxCalculatorLevel2 : ITaxCalculator
	{
		public int CalculateTax(int receivedMoney)
		{
			return (int)(receivedMoney * 0.32);
		}
	}
}
