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
        private int AmortizedCash { get; set; }
        public bool AmortizeMode;

        public int CalculateTax(int receivedMoney)
        {
            receivedMoney -= PriceOfGoods;

            return (int)(receivedMoney * 0.19);
        }

        public int CalculateTax(int receivedMoney, bool amortize)
        {
            receivedMoney -= PriceOfGoods;
            AmortizeMode = amortize;
            if (receivedMoney >= 10000 && AmortizeMode == true)
            {
                AmortizedCash = (int)(receivedMoney * 0.25);
                receivedMoney = (int)(receivedMoney * 0.75);
            }
            return (int)(receivedMoney * 0.19);
        }
    }
}
