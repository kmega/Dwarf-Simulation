using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaxesForFun.Business;

namespace TaxesForFun.TaxCalculators
{
    public class LinearTaxCalculator : ITaxCalculator
    {
		int goodsValue = 0;
		public LinearTaxCalculator() { }

		public LinearTaxCalculator(int goodsCost)
		{
			goodsValue = goodsCost;
		}
        public int CalculateTax(int receivedMoney)
        {
			return (int)((receivedMoney - goodsValue) * 0.19);
        }
    }
}
