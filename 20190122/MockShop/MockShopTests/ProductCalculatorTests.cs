using MockShop;
using NUnit.Framework;
using Moq;
using System;

namespace Tests
{
    public class Tests
    {
        private Mock<ICalendarDiscountCalculator> calendarDiscountCalculator;
        private Mock<ITypeDiscountCalculator> discountCalculator;
        private Mock<IPriceRepo> priceRepo;
        private Mock<IDateProvider> dateProvider;
        private Product defaultProduct;
        [SetUp]
        public void Setup()
        {
            calendarDiscountCalculator = new Mock<ICalendarDiscountCalculator>();
            discountCalculator = new Mock<ITypeDiscountCalculator>();
            priceRepo = new Mock<IPriceRepo>();
            dateProvider = new Mock<IDateProvider>();
            dateProvider.Setup(x => x.Now()).Returns(new DateTime(9999, 11, 9));
            defaultProduct = new Product("", ProductType.Clothes);
            calendarDiscountCalculator
                .Setup(x => x.Calculate())
                .Returns(0.0);
            discountCalculator.Setup(x => x.Calculate(ProductType.Clothes)).Returns(0.3);
            priceRepo.Setup(x => x.GetProductPrice(ProductType.Clothes)).Returns(10.0);  
        }

        [Test]
        public void T01_ShouldReturn2WhenDateIsBlackFridayAndProductIsCloth()
        {
            //given
            calendarDiscountCalculator.Setup(x => x.Calculate()).Returns(0.5);
            var productCalculator = new ProductCalculator(calendarDiscountCalculator.Object, 
                discountCalculator.Object, priceRepo.Object);
            //when
            var result = productCalculator.Calculate(defaultProduct.type);
            //then
            Assert.AreEqual(2, result,0.01);            
        }
        [Test]
        public void T02_ShouldReturn5WhenDateIsChristmasAndProductIsCloth()
        {
            //given
            calendarDiscountCalculator
                .Setup(x => x.Calculate())
                .Returns(0.2);
            var productCalculator = new ProductCalculator(calendarDiscountCalculator.Object,
                discountCalculator.Object, priceRepo.Object);
            //when
            var result = productCalculator.Calculate(defaultProduct.type);
            //then
            Assert.AreEqual(5, result, 0.01);
        }
        [Test]
        public void T03_ShouldReturn7WhenDateWithoudDiscountAndProductIsCloth()
        {
            //given
            var productCalculator = new ProductCalculator(calendarDiscountCalculator.Object,
                discountCalculator.Object, priceRepo.Object);
            //when
            var result = productCalculator.Calculate(defaultProduct.type);
            //then
            Assert.AreEqual(7, result);
        }
        [Test]
        public void T04_ShouldReturn18WhenDateWithoudDiscountAndProductIsTurtleShoes()
        {
            //given
            discountCalculator.Setup(x => x.Calculate(ProductType.TurtleOrthopedicShoes)).Returns(-0.2);
            priceRepo.Setup(x => x.GetProductPrice(ProductType.TurtleOrthopedicShoes)).Returns(15.0);
            var productCalculator = new ProductCalculator(calendarDiscountCalculator.Object,
                discountCalculator.Object, priceRepo.Object);
            defaultProduct.type = ProductType.TurtleOrthopedicShoes;
            //when
            var result = productCalculator.Calculate(defaultProduct.type);
            //then
            Assert.AreEqual(18, result);
        }
        [Test]
        public void T05_ShouldReturn15WhenChristmasAndProductIsTurtleShoes()
        {
            //given
            discountCalculator.Setup(x => x.Calculate(ProductType.TurtleOrthopedicShoes)).Returns(-0.2);
            priceRepo.Setup(x => x.GetProductPrice(ProductType.TurtleOrthopedicShoes)).Returns(15.0);
            calendarDiscountCalculator
                .Setup(x => x.Calculate())
                .Returns(0.2);
            var productCalculator = new ProductCalculator(calendarDiscountCalculator.Object,
                discountCalculator.Object, priceRepo.Object);
            defaultProduct.type = ProductType.TurtleOrthopedicShoes;
            //when
            var result = productCalculator.Calculate(defaultProduct.type);
            //then
            Assert.AreEqual(15, result, 0.01);
        }
        [Test]
        public void T06_ShouldReturn14dot4WhenChristmasAndProductIsTurtleShoes()
        {
            //given
            calendarDiscountCalculator.Setup(x => x.Calculate()).Returns(0.5);
            discountCalculator.Setup(x => x.Calculate(ProductType.TurtleOrthopedicShoes)).Returns(-0.2);
            priceRepo.Setup(x => x.GetProductPrice(ProductType.TurtleOrthopedicShoes)).Returns(15.0);
            
            var productCalculator = new ProductCalculator(calendarDiscountCalculator.Object,
                discountCalculator.Object, priceRepo.Object);
            defaultProduct.type = ProductType.TurtleOrthopedicShoes;
            //when
            var result = productCalculator.Calculate(defaultProduct.type);
            //then
            Assert.AreEqual(10.5, result, 0.01);
        }
    }
}