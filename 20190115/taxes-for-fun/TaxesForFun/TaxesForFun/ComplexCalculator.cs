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
            if (customer.Type == CustomerType.Personal)
            {
                return new TotalPersonalTaxCalculator().CalculateTax(customer.Money);
            }
            else if(customer.Type == CustomerType.BusinessLinear)
            {
                return new LinearTaxCalculator().CalculateTax(customer.Money);
            }
            else return 0;
        }

        public int ProcessCustomers(List<Customer> customers)
        {
            int sum=0;
           foreach(Customer customer in customers)
            {
                sum += ProcessCustomer(customer);
            }
            return sum;
        }
    }
}
