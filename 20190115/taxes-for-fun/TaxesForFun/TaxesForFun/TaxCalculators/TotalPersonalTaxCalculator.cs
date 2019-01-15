using System;
using System.Collections.Generic;
using System.Text;

namespace TaxesForFun.TaxCalculators
{
	class TotalPersonalTaxCalculator : ITaxCalculator
	{
		public int CalculateTax(int receivedMoney)
		{
			int taxLevel = 85528;
			if(receivedMoney > taxLevel)
			{
				int level2Tax = receivedMoney - taxLevel;
				int level1Tax = new PersonalTaxCalculator().CalculateTax(taxLevel);

				return (int)(level1Tax + level2Tax * 0.32);
			}
			else if(receivedMoney <= taxLevel)
			{
				return new PersonalTaxCalculator().CalculateTax(receivedMoney);
			}
			throw new Exception("nah bro, not gonna happend");
		}
	}
}
