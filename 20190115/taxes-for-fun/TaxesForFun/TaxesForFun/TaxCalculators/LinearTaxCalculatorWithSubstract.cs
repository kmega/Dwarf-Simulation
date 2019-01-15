using System.Collections.Generic;
using TaxesForFun.Business;

namespace TaxesForFun.TaxCalculators
{
    public class LinearTaxCalculatorWithSubstract : ITaxCalculator
    {
     public List<Goods> Goods;

        public LinearTaxCalculatorWithSubstract (List<Goods> goods)
        {
            Goods = goods;

        }

        public int CalculateTax(int receivedMoney)
        {

            foreach (var item in Goods)
            {
                if (item.Value < 10000)
                {
                    receivedMoney -= item.Value;
                }
                else
                {
                    receivedMoney -= (int)(item.Value * 0.25);
                }

            }

            int expectedtax = (int)(receivedMoney * 0.19);
                return expectedtax;
            

        }
    }
}