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
            calendar.Setup(x => x.SetDiscountByDate()).Returns(0.5m);

            var product = new ProductFactory().CreateSingleProduct("Buty", 100);

            var temp = new DiscountCalculator();
            var result = temp.CalculateFinalDiscount(calendar.Object, product);

            Assert.AreEqual(20, result);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var calendar = new Mock<ICalendarDiscountCalculator>();
            calendar.Setup(x => x.SetDiscountByDate()).Returns(0.2m);

            var product = new ProductFactory().CreateSingleProduct("Buty", 100);

            var temp = new DiscountCalculator();
            var result = temp.CalculateFinalDiscount(calendar.Object, product);

            Assert.AreEqual(50, result);
        }
    }
}
