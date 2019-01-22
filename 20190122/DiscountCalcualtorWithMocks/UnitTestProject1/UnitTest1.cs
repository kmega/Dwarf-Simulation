using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProductCalc;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //given
            var product = new ProductFactory().CreateSingleProduct(100, EProductType.Odziez);

            var calendar = new Mock<ICalendarDiscountCalculator>();
            calendar.Setup(x => x.SetDiscountBasedOnCurrentDate()).Returns(0.2m);

            //when
            decimal finalPrice = new DiscountExecutor().ExecutePriceForOneProduct(calendar.Object, product);

            //then
            Assert.AreEqual(50, finalPrice);
        }

        [TestMethod]
        public void TestMethod2()
        {
            //given
            var product = new ProductFactory().CreateSingleProduct(100, EProductType.Odziez);

            var calendar = new Mock<ICalendarDiscountCalculator>();
            calendar.Setup(x => x.SetDiscountBasedOnCurrentDate()).Returns(0m);

            //when
            decimal finalPrice = new DiscountExecutor().ExecutePriceForOneProduct(calendar.Object, product);

            //then
            Assert.AreEqual(70, finalPrice);
        }

        [TestMethod]
        public void TestMethod3()
        {
            //given
            var product = new ProductFactory().CreateSingleProduct(100, EProductType.Buty);

            var calendar = new Mock<ICalendarDiscountCalculator>();
            calendar.Setup(x => x.SetDiscountBasedOnCurrentDate()).Returns(0.5m);

            //when
            decimal finalPrice = new DiscountExecutor().ExecutePriceForOneProduct(calendar.Object, product);

            //then
            Assert.AreEqual(35, finalPrice);
        }

        [TestMethod]
        public void TestMethod4()
        {
            //given
            var product = new ProductFactory().CreateSingleProduct(100, EProductType.Buty);

            var calendar = new Mock<ICalendarDiscountCalculator>();
            calendar.Setup(x => x.SetDiscountBasedOnCurrentDate()).Returns(0.3m);

            //when
            decimal finalPrice = new DiscountExecutor().ExecutePriceForOneProduct(calendar.Object, product);

            //then
            Assert.AreEqual(55, finalPrice);
        }
    }
}
