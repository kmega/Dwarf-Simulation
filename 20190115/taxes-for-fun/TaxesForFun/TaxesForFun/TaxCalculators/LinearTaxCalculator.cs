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

        public int CalculateTax(int receivedMoney)
        {
           double value = (receivedMoney-goodsValue) * 0.19;
            return (int)value;
        }
                      

        public LinearTaxCalculator()
        {

        }

        public LinearTaxCalculator(int goodsValue)
        {
            this.goodsValue = goodsValue;
        }
    }
}
