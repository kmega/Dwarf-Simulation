using MockShop;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MockShopTests
{
    class CalendarDiscountCalculatorTests
    {
        private CalendarDiscountCalculator calendarDiscountCalc;
        private Mock<IDateProvider> dateProvider;
        [SetUp]
        public void Setup()
        {
            dateProvider = new Mock<IDateProvider>();
            dateProvider.Setup(x => x.Now()).Returns(new DateTime(9999, 11, 9));
        }

        [Test]
        public void T01_ShouldReturn0WhenCasualDate()
        {
            //given
            calendarDiscountCalc = new CalendarDiscountCalculator(dateProvider.Object);
            //when
            var result = calendarDiscountCalc.Calculate();
            //then
            Assert.AreEqual(0, result);
        }
        [Test]
        [TestCase(19)]
        [TestCase(23)]
        public void T02_ShouldReturn0dot2WhenChristmas(int day)
        {
            //given
            dateProvider.Setup(x => x.Now()).Returns(new DateTime(9999, 12, day));
            calendarDiscountCalc = new CalendarDiscountCalculator(dateProvider.Object);
            //when
            var result = calendarDiscountCalc.Calculate();
            //then
            Assert.AreEqual(0.2, result);
        }
        [Test]
        public void T03_ShouldReturn0dot5WhenBlackFriday()
        {
            //given
            dateProvider.Setup(x => x.Now()).Returns(new DateTime(9999, 11, 29));
            calendarDiscountCalc = new CalendarDiscountCalculator(dateProvider.Object);
            //when
            var result = calendarDiscountCalc.Calculate();
            //then
            Assert.AreEqual(0.5, result);
        }
    }
}
