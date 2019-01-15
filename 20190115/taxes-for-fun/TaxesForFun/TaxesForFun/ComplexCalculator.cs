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
            //throw new NotImplementedException("Implement me for happiness and joy!");
            ITaxCalculator calculator = TaxCalculatorFactory.Create(customer.Type);
            return calculator.CalculateTax(customer.Money);
        }

        public int ProcessCustomers(List<Customer> customers)
        {
            //throw new NotImplementedException("Implement me for happiness and joy!");
            int sumCustomerTaxes = 0;

            customers.ForEach(x =>
            {
                ITaxCalculator calculator = TaxCalculatorFactory.Create(x.Type);
                sumCustomerTaxes += calculator.CalculateTax(x.Money);
            });

            return sumCustomerTaxes;
        }
    }
}
