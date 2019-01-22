using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DiscountApp;
using Moq;

namespace TestDiscount
{
    [TestClass]
    public class UnitTest1
    {
        Mock<IDiscountCalc> _discountCalc = new Mock<IDiscountCalc>();
        Mock<ICalendarDiscountCalculator> _calendarDiscount = new Mock<ICalendarDiscountCalculator>();
        Mock<IPriceProduct> _productPrice = new Mock<IPriceProduct>();
        Mock<IProductExist> _productExists = new Mock<IProductExist>();
        
            [TestMethod]
            public void ShouldReturn0WhenProductDoesntExist()
            {
            //Given
            DateTime dateTime = new DateTime(2018, 6, 10);
            Product product = new Product("Ubranie", "Spodnie");


            ProductCalculator productCalculator = new ProductCalculator(_calendarDiscount.Object, _discountCalc.Object, _productPrice.Object, _productExists.Object);

            //When
            decimal price = productCalculator.Calculate(dateTime, product);

            //Then
            Assert.AreEqual(0, price);
            }

        [TestMethod]
        public void ShouldReturn7WhenUbranieAndDayWithoutDiscount()
        {
            //Given
            DateTime dateTime = new DateTime(2018, 6, 10);
            Product product = new Product("Ubranie", "Spodnie");

            _productExists.Setup(i => i.ProductExist()).Returns(true);
            _productPrice.Setup(i => i.Price(product.Typ)).Returns(10);
            _discountCalc.Setup(i => i.DiscountCalc(product.Typ)).Returns(0.3m);

            ProductCalculator productCalculator = new ProductCalculator(_calendarDiscount.Object, _discountCalc.Object, _productPrice.Object, _productExists.Object);

            //When
            decimal price = productCalculator.Calculate(dateTime, product);

            //Then
            Assert.AreEqual(7, price);
        }

        [TestMethod]
        public void ShouldReturn5WhenUbranieAndDayWithDiscount()
        {
            //Given
            DateTime dateTime = new DateTime(2018, 12, 19);
            Product product = new Product("Ubranie", "Spodnie");

            _productExists.Setup(i => i.ProductExist()).Returns(true);
            _productPrice.Setup(i => i.Price(product.Typ)).Returns(10);
            _discountCalc.Setup(i => i.DiscountCalc(product.Typ)).Returns(0.3m);
            _calendarDiscount.Setup(i => i.CalendarDiscount(dateTime)).Returns(0.2m);

            ProductCalculator productCalculator = new ProductCalculator(_calendarDiscount.Object, _discountCalc.Object, _productPrice.Object, _productExists.Object);

            //When
            decimal price = productCalculator.Calculate(dateTime, product);

            //Then
            Assert.AreEqual(5, price);
        }

        [TestMethod]
        public void ShouldReturn6WhenButyAndDayWithDiscount()
        {
            //Given
            DateTime dateTime = new DateTime(2018, 12, 19);
            Product product = new Product("Buty", "Kozaki");

            _productExists.Setup(i => i.ProductExist()).Returns(true);
            _productPrice.Setup(i => i.Price(product.Typ)).Returns(15);
            _discountCalc.Setup(i => i.DiscountCalc(product.Typ)).Returns(0.2m);
            _calendarDiscount.Setup(i => i.CalendarDiscount(dateTime)).Returns(0.2m);

            ProductCalculator productCalculator = new ProductCalculator(_calendarDiscount.Object, _discountCalc.Object, _productPrice.Object, _productExists.Object);

            //When
            decimal price = productCalculator.Calculate(dateTime, product);

            //Then
            Assert.AreEqual(9, price);
        }

        [TestMethod]
        public void ShouldReturn6WhenButyAndDayWithoutDiscount()
        {
            //Given
            DateTime dateTime = new DateTime(2018, 6, 10);
            Product product = new Product("Buty", "Kozaki");

            _productExists.Setup(i => i.ProductExist()).Returns(true);
            _productPrice.Setup(i => i.Price(product.Typ)).Returns(15);
            _discountCalc.Setup(i => i.DiscountCalc(product.Typ)).Returns(0.2m);
            _calendarDiscount.Setup(i => i.CalendarDiscount(dateTime)).Returns(0.0m);

            ProductCalculator productCalculator = new ProductCalculator(_calendarDiscount.Object, _discountCalc.Object, _productPrice.Object, _productExists.Object);

            //When
            decimal price = productCalculator.Calculate(dateTime, product);

            //Then
            Assert.AreEqual(12, price);
        }


    }
}


