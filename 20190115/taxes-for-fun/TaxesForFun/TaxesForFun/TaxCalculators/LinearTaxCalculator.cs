using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaxesForFun.Business;

namespace TaxesForFun.TaxCalculators
{
    public class LinearTaxCalculator : ITaxCalculator
    {   
        public int CalculateTax(int receivedMoney)
        {
            int expectedTax = (int)(receivedMoney * 0.19);

            return expectedTax;
            
        }
               
    }
}
