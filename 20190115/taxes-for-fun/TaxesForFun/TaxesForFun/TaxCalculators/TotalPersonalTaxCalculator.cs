using System;
using System.Collections.Generic;
using System.Text;

namespace TaxesForFun.TaxCalculators
{
    class TotalPersonalTaxCalculator : ITaxCalculator
    {
        public int CalculateTax(int receivedMoney)
        {
            if (receivedMoney <=20000)
            {
                return new PersonalTaxCalculator().CalculateTax(receivedMoney);
            }
            else if(receivedMoney <= 85500)
            {
                return new PersonalLevel2().CalculateTax(receivedMoney);
               
            }
            //else if (receivedMoney == 100000)
            //{
             

            //}
            else
                throw new Exception();
            
            
        }
    }
}
