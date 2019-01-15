using NUnit.Framework;
using System.Collections.Generic;
using TaxesForFun;
using TaxesForFun.Business;
using TaxesForFun.TaxCalculators;

namespace Tests
{
    public class Tests
    {

        [Test]
        public void T001_CalculateLinearTaxForCompany()
        {
            // Given
            int receivedMoney = 20000;

            // Expected
            int expectedTax = (int)(receivedMoney * 0.19);

            // When
            int linearTax = new LinearTaxCalculator().CalculateTax(receivedMoney);

            // Then
            Assert.AreEqual(expectedTax, linearTax);
        }

        [Test]
        public void T002_CalculatePersonalTax()
        {
            // Given
            int receivedMoney = 20000;
            int taxCredit = 8000;

            // Expected
            int expectedTax = (int)((receivedMoney - taxCredit) * 0.18);

            // When
            int actualTax = new PersonalTaxCalculator().CalculateTax(receivedMoney - taxCredit);

            // Then
            Assert.AreEqual(expectedTax, actualTax);
        }

        [Test]
        public void T003_SelectTaxCalculatorAsPersonal()
        {
            // When
            ITaxCalculator calculator = TaxCalculatorFactory.Create("personal first tax level");

            // Then
            Assert.IsTrue(calculator is PersonalTaxCalculator);
        }

        [Test]
        public void T004_SelectTaxCalculatorAsBusinessLinear()
        {
            // When
            ITaxCalculator calculator = TaxCalculatorFactory.Create("linear business");

            // Then
            Assert.IsTrue(calculator is LinearTaxCalculator);
        }

        [Test]
        public void T005_CustomerAsksForPersonalTax()
        {
            // Here, you will have to build a second method of a Factory
            // Given
            Customer customer = new Customer(20000, CustomerType.Personal);
            ITaxCalculator calculator = TaxCalculatorFactory.Create(customer.Type);

            // When
            int owed = calculator.CalculateTax(customer.Money);

            // Then
            Assert.AreEqual(2160, owed);
        }

        [Test]
        public void T006_CustomerAsksForPersonalTaxComplexCalculator()
        {
            // Here, you will have to move (copy) the code from test T005 a bit.
            // Note that you have effectively done this in T005 - but now it is a separate class.

            // Given
            Customer customer = new Customer(20000, CustomerType.Personal);
            ComplexCalculator calculator = new ComplexCalculator();

            // When
            int owed = calculator.ProcessCustomer(customer);

            // Then
            Assert.AreEqual(2160, owed);
        }

        [Test]
        public void T007_ProcessThreeCustomers()
        {
            // Technically, a new method operating on groups.
            // Feel free to use OLD method from T006, but in a foreach.

            // Given
            List<Customer> customers = new List<Customer>()
            {
                new Customer(20000, CustomerType.Personal),
                new Customer(30000, CustomerType.Personal),
                new Customer(30000, CustomerType.BusinessLinear)
            };

            ComplexCalculator calculator = new ComplexCalculator();

            // When
            int owed = calculator.ProcessCustomers(customers);

            // Then
            Assert.AreEqual(11820, owed);
        }


        [Test]
        public void T008_CalculatePersonalTaxAbove85528()
        {
            // Given
            int receivedMoney = 100000;

            // Note: you have to build a NEW ITaxCalculator member - add a new class
            ITaxCalculator calculator = TaxCalculatorFactory.Create("personal second tax level");

            // Expected
            // Money above 85528: 32%, as this is the second tax level. Forget about tax credit this time.
            // TOTAL: 32000
            int expectedTax = 32000;

            // When
            int actualTax = calculator.CalculateTax(receivedMoney);

            // Then
            Assert.AreEqual(expectedTax, actualTax);
        }

        [Test]
        public void T009_CalculateTotalPersonalTax()
        {
            // Given
            int receivedMoney = 100000;
            // int taxCredit = 8000; kwota wolna od podatku
            // int taxLevel = 85528; zmiana progu podatkowego

            // Once again, you may add a TotalPersonalTaxCalculator class and 
            // swap old PersonalTax with this new one in the factory.
            // You may note for previous tests it will work like first level tax, but it will let you
            // CHAIN two calculators. Look at Expected and split money appropriately.
            // If you don't know what I want from you, call me when you get here.
            ITaxCalculator calculator = TaxCalculatorFactory.Create(CustomerType.Personal);

            // Expected
            // Money up to 85528: calculated like T002, so: 13955.04. But we have int, so 13955.
            // Money above 85528: 32%. In this case, 4631.04. But we have int, so 4631.
            // TOTAL: 18586
            int expectedTax = 17466;

            // When
            int actualTax = calculator.CalculateTax(receivedMoney);

            // Then
            Assert.AreEqual(expectedTax, actualTax);
        }

        [Test]
        public void T010_ObserveEverythingWorksForComplexCalculator()
        {
            // Given
            List<Customer> customers = new List<Customer>()
            {
                new Customer(20000, CustomerType.Personal), // this one uses "old" personal calc -> 2160
                new Customer(100000, CustomerType.Personal), // this one uses "new" personal calc -> 18586
                new Customer(20000, CustomerType.BusinessLinear)  // this one uses linear tax -> 3800
            };

            ComplexCalculator calculator = new ComplexCalculator();

            // When
            int owed = calculator.ProcessCustomers(customers);

            // Then
            Assert.AreEqual(23426, owed);
        }

        [Test]
        public void T011_BusinessHasSubstractions()
        {
            // Given
            int companyMoney = 23000;

            List<Goods> goods = new List<Goods>()
            {
                new Goods(1000, "keyboard"), new Goods(2000, "mouse")
            };

            // Expected
            // Right. So, 23000 - 3000 from 'costs of generating the profits' = 20000
            // Thus, total tax = 0.19 * 20000 = 3800
            int expectedTax = 3800;

            // Yes, you will have to deal with a new method. You will have to pass appropriate parameters
            // to the calculator using the CONSTRUCTOR, because you have no other way of
            // passing without changing the interface of the method - the contract.
            ITaxCalculator calculator = TaxCalculatorFactory.Create(CustomerType.BusinessLinear, goods);

            // When
            int actualTax = calculator.CalculateTax(companyMoney);

            // Then
            Assert.AreEqual(expectedTax, actualTax);
        }
        [Test]
        public void T012_BusinessHasSubstractionsWithAmortizationWith25PercOfGoodValue()
        {
            // Given
            int companyMoney = 23000;

            List<Goods> goods = new List<Goods>()
            {
                new Goods(1000, "keyboard"), new Goods(20000, "car")
            };

            // Expected
            // costOfIncome = 1000 + 20000*0.25 <-- amortization;
            // Right. So, 23000 - 6000 from 'costs of generating the profits' = 20000
            // Thus, total tax = 0.19 * 17000 = 3230
            int expectedTax = 3230;

            // Yes, you will have to deal with a new method. You will have to pass appropriate parameters
            // to the calculator using the CONSTRUCTOR, because you have no other way of
            // passing without changing the interface of the method - the contract.
            ITaxCalculator calculator = TaxCalculatorFactory.Create(CustomerType.BusinessLinear, goods);

            // When
            int actualTax = calculator.CalculateTax(companyMoney);

            // Then
            Assert.AreEqual(expectedTax, actualTax);
        }
        [Test]
        public void T013_CalculateTotalPersonalTaxWhenTaxCreditChangesTaxBorders()
        {
            // Given
            int receivedMoney = 90000;
            // int taxCredit = 8000; kwota wolna od podatku
            // int taxLevel = 85528; zmiana progu podatkowego

            // Once again, you may add a TotalPersonalTaxCalculator class and 
            // swap old PersonalTax with this new one in the factory.
            // You may note for previous tests it will work like first level tax, but it will let you
            // CHAIN two calculators. Look at Expected and split money appropriately.
            // If you don't know what I want from you, call me when you get here.
            ITaxCalculator calculator = TaxCalculatorFactory.Create(CustomerType.Personal);
            // TOTAL: 14760
            int expectedTax = 14760;

            // When
            int actualTax = calculator.CalculateTax(receivedMoney);

            // Then
            Assert.AreEqual(expectedTax, actualTax);
        }
        [Test]
        public void T014_CustomerAsksForPersonalTaxComplexCalculatorWithHouseGoodsInclusion()
        {
            // Given
            List<Goods> goods = new List<Goods>()
            {
                new Goods(500, "Internet Connection")
            };
            Customer customer = new Customer(20000, CustomerType.Personal, goods);
            ComplexCalculator calculator = new ComplexCalculator();

            // When
            int owed = calculator.ProcessCustomer(customer);

            // Then
            Assert.AreEqual(2070, owed);
        }
        [Test]
        public void T015_PersonalCustomersWithGoodsAndReductionsForComplexCalculator()
        {
            // Given
            List<Goods> houseGoods = new List<Goods>()
            {
                new Goods(700, "internet"),
                new Goods(1100, "child")
            };
            List<Customer> customers = new List<Customer>()
            {
                new Customer(30000, CustomerType.Personal, houseGoods), // this one uses new personal calc with goods -> 3636
                new Customer(50000, CustomerType.Personal), // this one uses first stage of taxCalc -> 7560
                new Customer(100000, CustomerType.Personal), // this one uses total two stage calculator -> 17466
                new Customer(100000, CustomerType.Personal, houseGoods), // this one uses "new" personal calc with good and two stage -> 16890
            };

            ComplexCalculator calculator = new ComplexCalculator();

            // When
            int owed = calculator.ProcessCustomers(customers);

            // Then
            Assert.AreEqual(45552, owed);
        }
        [Test]
        public void T016_BusinessCustomersWithGoodsAndAmortizationForComplexCalculator()
        {
            // Given
            List<Goods> companyGoods = new List<Goods>()
            {
                new Goods(500, "mouse"),
                new Goods(25000, "car")
            };
            List<Customer> customers = new List<Customer>()
            {
                new Customer(30000, CustomerType.BusinessLinear, companyGoods), // this one uses amortization with limitation -> 4417 
                new Customer(50000, CustomerType.BusinessLinear),// this one uses simple buisness tax -> 9500
            };

            ComplexCalculator calculator = new ComplexCalculator();

            // When
            int owed = calculator.ProcessCustomers(customers);

            // Then
            Assert.AreEqual(13917, owed);
        }
    }
}