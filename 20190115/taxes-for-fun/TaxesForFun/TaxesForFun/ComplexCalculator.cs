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

            int money = 20000;
            PersonalTaxCalculator personal = new PersonalTaxCalculator();
            int owed = personal.CalculateTax(money);
            return owed;
          
        }

        public int ProcessCustomers(List<Customer> customers)
        {
            //List<Customer> customers = new List<Customer>()
            //{
            //    new Customer(20000, CustomerType.Personal),
            //    new Customer(30000, CustomerType.Personal),
            //    new Customer(30000, CustomerType.BusinessLinear)
            //};

            //ComplexCalculator calculator = new ComplexCalculator();

            //// When
            //int owed = calculator.ProcessCustomers(customers);

            //// Then
            //Assert.AreEqual(11820, owed);
            PersonalTaxCalculator personal = new PersonalTaxCalculator();
            LinearTaxCalculator linear = new LinearTaxCalculator();
            int thesum = 0;
            int owed = 0;
            foreach (Customer cus in customers)
            {
                if (cus.Type == CustomerType.Personal)
                {
                    owed = personal.CalculateTax(cus.Money);
                }
                else if (cus.Type == CustomerType.BusinessLinear)
                {
                    owed = linear.CalculateTax(cus.Money);
                }
                thesum =thesum+ owed;
            }
            
            return thesum;
            
        }
    }
}
