using System;
using System.Collections.Generic;
using System.Text;
using TaxesForFun.Business;

namespace TaxesForFun.TaxCalculators
{
    public static class TaxCalculatorFactory
    {
        public static ITaxCalculator Create(string type)
        {
            if(type == "personal first tax level")
			{
				return new PersonalTaxCalculator();
			} else if (type == "personal second tax level")
			{
				return new PersonalTaxCalculatorLevel2();
			} else 
			{
				return new LinearTaxCalculator();
			}
        }

        public static ITaxCalculator Create(CustomerType type)
        {
			if(type == CustomerType.Personal)
			{
				return new TotalPersonalTaxCalculator();
			} else
			{
				return new LinearTaxCalculator();
			}
        }

        public static ITaxCalculator Create(CustomerType type, List<Goods> goods)
        {
			if (type == CustomerType.BusinessLinear)
			{
				int sum = 0;
				foreach (var good in goods)
				{
					sum += good.Value;
				}
				return new LinearTaxCalculator(sum);
			}
			else
				throw new Exception("buhahahah");

        }
    }
}
