using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using DiscountCalcualtorWithMocks;
using System;

namespace tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var calendar = new Mock<ICalendarDiscountCalculator>();
            calendar.Setup(x => x.SetDiscountByDate()).Returns(new DateTime(2018, 12, 1));

            var product = new ProductFactory().CreateSingleProduct("Buty", 100);

            var temp = new DiscountCalculator();
            var result = temp.CalculateFinalDiscount(calendar.Object, product);

            Assert.AreEqual(170, result);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var calendar = new Mock<ICalendarDiscountCalculator>();
            calendar.Setup(x => x.SetDiscountByDate()).Returns(new DateTime(2018, 12, 24));

            var product = new ProductFactory().CreateSingleProduct("Buty", 100);
            //product.Setu(x => x.CreateSingleProduct(It.IsAny<string>(),
                                //It.IsAny<decimal>())).Returns(new Product("Buty", 100));

            var temp = new DiscountCalculator();
            var result = temp.CalculateFinalDiscount(calendar.Object, product);

            Assert.AreEqual(120, result);
        }
    }
}
