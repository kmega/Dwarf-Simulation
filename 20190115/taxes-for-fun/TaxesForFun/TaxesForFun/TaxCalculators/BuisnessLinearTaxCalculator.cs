using System;
using System.Collections.Generic;
using System.Text;
using TaxesForFun.Business;

namespace TaxesForFun.TaxCalculators
{
    class BuisnessLinearTaxCalculator : ITaxCalculator
    {
        private List<Goods> Goods { get; set; } = new List<Goods>();
        public BuisnessLinearTaxCalculator(List<Goods> goods)
        {
            Goods = goods;
        }
        public int CalculateTax(int receivedMoney)
        {
            foreach (var item in Goods)
            {
                receivedMoney -= item.Value;
            }

            return (int)(receivedMoney * 0.19);
        }
    }
}
