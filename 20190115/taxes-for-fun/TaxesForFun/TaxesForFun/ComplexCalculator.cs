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
         
            if (customer.Type==CustomerType.Personal)
            {
                PersonalTaxCalculator ptc = new PersonalTaxCalculator();
                int tax= ptc.CalculateTax(customer.Money);
                return tax;
            }
            else
            {
                LinearTaxCalculator ltc = new LinearTaxCalculator();
                int tax = ltc.CalculateTax(customer.Money);
                return tax;
            }
        }

        public int ProcessCustomers(List<Customer> customers)
        {
            int tax = 0;


            foreach (var item in customers)
            {

                if (item.Type == CustomerType.Personal)
                {
                    PersonalTaxCalculator ptc = new PersonalTaxCalculator();
                     tax += ptc.CalculateTax(item.Money);
                   
                }
                else
                {
                    LinearTaxCalculator ltc = new LinearTaxCalculator();
                     tax += ltc.CalculateTax(item.Money);
                }

            }

            return tax;

        }
    }
}
