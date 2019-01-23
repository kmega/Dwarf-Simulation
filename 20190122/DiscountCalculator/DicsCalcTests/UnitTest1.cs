using NUnit.Framework;
using Moq;
using DiscountCalculator;
using System;

namespace Tests
{
    public class Tests
    {
        
        
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void DiscountTypeCalc_ReturnRightPrice()
        {
            //given
            var calculator = new Mock<ProductCalculator>();
            var faktory = new Mock<IProductFactory>();
            var calenderCalc = new Mock<ICalendarDiscountCalculator>();
            var typeCalc = new Mock<IDiscountCalculator>();

            string name = "tortoise shoes";
            string type = "ortopedical shoes";
            double price = 30.00;
            DateTime date = new DateTime(1,1,1);

            faktory.Setup(i => i.CreateProduct(name, type, price)).Returns(new Product(name, type, price));
            faktory.Setup(i => i.CreateProduct("casual shoes", "casual shoes", 20)).Returns(new Product("casual shoes", "casual shoes", 20));
            var tortoiseShoes = faktory.Object.CreateProduct(name, type, price);
            var casualShoes = faktory.Object.CreateProduct("casual shoes", "casual shoes", 20);


            typeCalc.Setup(i => i.CalculateDiscount(tortoiseShoes.ProductType)).Returns(0.2);
            typeCalc.Setup(i => i.CalculateDiscount(casualShoes.ProductType)).Returns(1);
            //when
            calculator.Setup(i => i.Calculate(date, casualShoes)).Returns(30.00);
            calculator.Setup(i => i.Calculate(date,tortoiseShoes)).Returns(30*1.2);
            

            //result
            
            Assert.AreEqual(30.00*1.2, calculator.Object.Calculate(date, tortoiseShoes));
            Assert.AreEqual(30.00, calculator.Object.Calculate(date, casualShoes));

        }

        [Test]
        public void DiscountCalender_Return07Price()
        {
            //given
            var calculator = new Mock<ProductCalculator>();
            var faktory = new Mock<IProductFactory>();
            var calenderCalc = new Mock<ICalendarDiscountCalculator>();
            var typeCalc = new Mock<IDiscountCalculator>();

            string name = "tortoise shoes";
            string type = "ortopedical shoes";
            double price = 30.00;
            DateTime noDiscountDate = new DateTime(1,1,1);
            DateTime discountDate = new DateTime(1,12,19);


            faktory.Setup(i => i.CreateProduct(name, type, price)).Returns(new Product(type, name, price));
            var tortoiseShoes = faktory.Object.CreateProduct(name, type, price);
            

            calenderCalc.Setup(i => i.CalculateDiscount(noDiscountDate)).Returns(1);
            calenderCalc.Setup(i => i.CalculateDiscount(discountDate)).Returns(0.7);
            //when
            calculator.Setup(i => i.Calculate(noDiscountDate, tortoiseShoes)).Returns(30);
            calculator.Setup(i => i.Calculate(discountDate, tortoiseShoes)).Returns(30*0.7);


            //result

            Assert.AreEqual(30, calculator.Object.Calculate(noDiscountDate, tortoiseShoes));
            Assert.AreEqual(30*0.7, calculator.Object.Calculate(discountDate, tortoiseShoes));

        }
    }
}