using MockShop;
using NUnit.Framework;
using Moq;
using System;

namespace Tests
{
    public class Tests
    {
        private Mock<ICalendarDiscountCalculator> calendarDiscountCalculator;
        private Mock<IDiscountCalculator> discountCalculator;
        private Mock<IPriceRepo> priceRepo;
        private Product defaultProduct;
        [SetUp]
        public void Setup()
        {
            calendarDiscountCalculator = new Mock<ICalendarDiscountCalculator>();
            discountCalculator = new Mock<IDiscountCalculator>();
            priceRepo = new Mock<IPriceRepo>();

            defaultProduct = new Product("szalik", ProductType.Clothes);
            calendarDiscountCalculator
                .Setup(x => x.Calculate(It.Is<DateTime>(i => !CheckDateDiscount(i))))
                .Returns(1.0);
            discountCalculator.Setup(x => x.Calculate(ProductType.Clothes)).Returns(0.7);
            priceRepo.Setup(x => x.GetProductPrice(ProductType.Clothes)).Returns(10.0);  
        }

        [Test]
        public void T01_ShouldReturn3dot5WhenDateIsBlackFridayAndProductIsCloth()
        {
            //given
            calendarDiscountCalculator.Setup(x => x.Calculate(new DateTime(2019, 11, 29))).Returns(0.5);
            var productCalculator = new ProductCalculator(calendarDiscountCalculator.Object, 
                discountCalculator.Object, priceRepo.Object);
            //when
            var result = productCalculator.Calculate(new DateTime(2019, 11, 29), defaultProduct);
            //then
            Assert.AreEqual(3.5, result);
        }
        [Test]
        public void T02_ShouldReturn5dot6WhenDateIsChristmasAndProductIsCloth()
        {
            //given
            calendarDiscountCalculator
                .Setup(x => x.Calculate(It.IsInRange(new DateTime(2019,12,19),new DateTime(2019,12,23),Range.Inclusive)))
                .Returns(0.8);
            var productCalculator = new ProductCalculator(calendarDiscountCalculator.Object,
                discountCalculator.Object, priceRepo.Object);
            //when
            var result = productCalculator.Calculate(new DateTime(2019, 12, 22), defaultProduct);
            //then
            Assert.AreEqual(5.6, result);
        }
        [Test]
        public void T03_ShouldReturn7WhenDateWithoudDiscountAndProductIsCloth()
        {
            //given
            var productCalculator = new ProductCalculator(calendarDiscountCalculator.Object,
                discountCalculator.Object, priceRepo.Object);
            //when
            var result = productCalculator.Calculate(new DateTime(2019, 12, 18), defaultProduct);
            //then
            Assert.AreEqual(7, result);
        }
        [Test]
        public void T04_ShouldReturn18WhenDateWithoudDiscountAndProductIsTurtleShoes()
        {
            //given
            discountCalculator.Setup(x => x.Calculate(ProductType.TurtleOrthopedicShoes)).Returns(1.2);
            priceRepo.Setup(x => x.GetProductPrice(ProductType.TurtleOrthopedicShoes)).Returns(15.0);
            var productCalculator = new ProductCalculator(calendarDiscountCalculator.Object,
                discountCalculator.Object, priceRepo.Object);
            defaultProduct.type = ProductType.TurtleOrthopedicShoes;
            //when
            var result = productCalculator.Calculate(new DateTime(2019, 12, 18), defaultProduct);
            //then
            Assert.AreEqual(18, result);
        }
        [Test]
        public void T05_ShouldReturn14dot4WhenChristmasAndProductIsTurtleShoes()
        {
            //given
            discountCalculator.Setup(x => x.Calculate(ProductType.TurtleOrthopedicShoes)).Returns(1.2);
            priceRepo.Setup(x => x.GetProductPrice(ProductType.TurtleOrthopedicShoes)).Returns(15.0);
            calendarDiscountCalculator
                .Setup(x => x.Calculate(It.IsInRange(new DateTime(2019, 12, 19), new DateTime(2019, 12, 23), Range.Inclusive)))
                .Returns(0.8);
            var productCalculator = new ProductCalculator(calendarDiscountCalculator.Object,
                discountCalculator.Object, priceRepo.Object);
            defaultProduct.type = ProductType.TurtleOrthopedicShoes;
            //when
            var result = productCalculator.Calculate(new DateTime(2019, 12, 20), defaultProduct);
            //then
            Assert.AreEqual(14.4, result, 0.01);
        }
        [Test]
        public void T06_ShouldReturn14dot4WhenChristmasAndProductIsTurtleShoes()
        {
            //given
            calendarDiscountCalculator.Setup(x => x.Calculate(new DateTime(2019, 11, 29))).Returns(0.5);
            discountCalculator.Setup(x => x.Calculate(ProductType.TurtleOrthopedicShoes)).Returns(1.2);
            priceRepo.Setup(x => x.GetProductPrice(ProductType.TurtleOrthopedicShoes)).Returns(15.0);
            
            var productCalculator = new ProductCalculator(calendarDiscountCalculator.Object,
                discountCalculator.Object, priceRepo.Object);
            defaultProduct.type = ProductType.TurtleOrthopedicShoes;
            //when
            var result = productCalculator.Calculate(new DateTime(2019, 11, 29), defaultProduct);
            //then
            Assert.AreEqual(9.0, result, 0.01);
        }
        private bool CheckDateDiscount(DateTime i)
        {
            if(i.Month == 12)
            {
                if(i.Day >= 19 && i.Day <= 23)
                {
                    return true;
                }
            }
            return false;
        }
    }
}