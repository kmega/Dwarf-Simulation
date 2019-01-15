using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaxesForFun.Business;

namespace TaxesForFun.TaxCalculators
{
    public class LinearTaxCalculator : ITaxCalculator
    {
 
        public string Type { get; set; }
        public int PriceOfGoods { get ; set ; }

        public int CalculateTax(int receivedMoney)
        {
            receivedMoney -= PriceOfGoods;
            return (int)(receivedMoney * 0.19);
        }
    }
}
