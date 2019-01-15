using System.Collections.Generic;
using TaxesForFun.Business;

namespace TaxesForFun.TaxCalculators
{
    public class TaxCalculatorWithSubstract : ITaxCalculator
    {
        public List<Goods> Goods;
        CustomerType Customer;

        public TaxCalculatorWithSubstract(List<Goods> goods, CustomerType customer)
        {
            Goods = goods;
            Customer = customer;

        }

        public int CalculateTax(int receivedMoney)
        {
            if (Customer == CustomerType.BusinessLinear)
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
            else
            {
                int expectedtax = 0;
                int taxCredit = 8000;
                int taxLevel = 85528;

                foreach (var item in Goods)
                {
                    if (receivedMoney < taxLevel)
                    {
                        receivedMoney -= taxCredit;
                        foreach (var elem in Goods)
                        {
                            receivedMoney -= item.Value;
                        }
                        expectedtax = (int)(receivedMoney * 0.18);
                    }

                    else
                    {
                        receivedMoney -= taxCredit;

                        expectedtax += (int)(taxLevel * 0.18);

                        expectedtax += (int)((receivedMoney - taxLevel) * 0.32);

                    }
                    foreach (var elem in Goods)
                    {
                        expectedtax -= item.Value;
                    }
                    
                }
                return expectedtax;

            }

        }
    
    }
}