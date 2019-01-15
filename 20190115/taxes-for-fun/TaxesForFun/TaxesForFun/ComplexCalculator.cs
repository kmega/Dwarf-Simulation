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
            ITaxCalculator calculator = TaxCalculatorFactory.Create(customer.Type);
            return calculator.CalculateTax(customer.Money);
        }

        public int ProcessCustomers(List<Customer> customers)
        {
            PersonalTotalTaxCalculator personalFullTax = new PersonalTotalTaxCalculator();
            LinearTaxCalculator linearTax = new LinearTaxCalculator();
            int taxes = 0;

            foreach (var customer in customers)
            {


                if (customer.Type == CustomerType.Personal)
                    taxes += personalFullTax.CalculateTax(customer.Money);

                else if (customer.Type == CustomerType.BusinessLinear)
                    taxes += linearTax.CalculateTax(customer.Money);
            }
            return taxes;
        }
    }
}
