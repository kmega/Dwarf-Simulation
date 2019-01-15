using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaxesForFun.Business;

namespace TaxesForFun.TaxCalculators
{
    public class LinearTaxCalculator : ITaxCalculator
    {
        private List<Goods> goods;

        public LinearTaxCalculator(List<Goods> goods)
        {
            this.goods = goods;
        }

        public int CalculateTax(int receivedMoney)
        {
            if (goods != null)
            {
                for (int i = 0; i < goods.Count; i++)
                {
                    receivedMoney -= goods[i].Value;
                }
            }

            return (int)(receivedMoney * 0.19);
        }
    }
}
