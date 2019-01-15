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
                ITaxCalculator calculator = new PersonalTaxCalculator();
                return calculator.CalculateTax(customer.Money);
            }
            if (customer.Type == CustomerType.BusinessLinear)
            {
                ITaxCalculator calculator = new LinearTaxCalculator();
                return calculator.CalculateTax(customer.Money);
            }
            return 0;
        }

        public int ProcessCustomers(List<Customer> customers)
        {
            var sum = 0;

            foreach (var customer in customers)
            {
                var t = TaxCalculatorFactory.Create(customer.Type);
                sum += t.CalculateTax(customer.Money);
            }
            return sum;
        }
    }
}
