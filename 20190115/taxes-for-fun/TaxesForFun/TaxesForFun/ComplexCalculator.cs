using System;
using System.Collections.Generic;
using System.Text;
using TaxesForFun.Business;
using TaxesForFun.TaxCalculators;

namespace TaxesForFun
{
    public class ComplexCalculator
    {
        public int ProcessCustomer(Customer customer)
        {
            return (int)((customer.Money - 8000) * 0.18);
        }

        public int ProcessCustomers(List<Customer> customers)
        {
            int owed = 0;
            foreach(var singleCustomer in customers)
            {
                if(singleCustomer.Type == CustomerType.Personal)
                {
                    if (singleCustomer.Money < 85528)
                    {
                        owed += (int)((singleCustomer.Money - 8000) * 0.18);
                    }
                    else owed += new TotalPersonalTaxCalculator().CalculateTax(singleCustomer.Money);
                }

                if (singleCustomer.Type == CustomerType.BusinessLinear)
                {
                    owed += (int)(singleCustomer.Money * 0.19);
                }
            }

            return owed;
        }
    }
}
