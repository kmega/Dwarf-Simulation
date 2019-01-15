using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaxesForFun.Business;

namespace TaxesForFun.TaxCalculators
{
    public class LinearTaxCalculator : ITaxCalculator
    {
        public List<Goods> Goodies { get; set; }
        public LinearTaxCalculator()
        {
            Goodies = new List<Goods>();
        }
        public LinearTaxCalculator(List<Goods> goods)
        {
            Goodies = goods;
        }
        public int CalculateTax(int receivedMoney)
        {
            if (Goodies.Any())
            {
                int costOfIncome = 0;
                foreach (var good in Goodies)
                {
                    if (good.Value > 10000)
                    {
                        costOfIncome += (int)(good.Value * 0.25);
                    }
                    else
                    {
                        costOfIncome += good.Value;
                    }
                }
                receivedMoney -= costOfIncome;
            }
            return (int)(receivedMoney * 0.19);

        }
    }
}
