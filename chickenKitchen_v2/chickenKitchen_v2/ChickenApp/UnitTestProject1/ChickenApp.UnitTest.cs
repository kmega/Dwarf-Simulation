using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class ChickenAppTest
    {
        [TestMethod]
        public void JulieMirage_BuysFishInWater_IsAllergicTo_False()
        {
            //Given
            var waiter = new ChickenApp.Domain.Waiter();
            string name = "Julie Mirage";
            string dish = "fish in water";

            waiter.CallWaiter(name, dish);

            var answer = waiter.asnwerUnitTest;

            Assert.AreEqual(answer, false);
        }
        
        [TestMethod]
        public void ElonCarousel_BuysFishInWater_IsAllergicTo_True()
        {
            //Given
            var waiter = new ChickenApp.Domain.Waiter();
            string name = "Elon Carousel";
            string dish = "fish in water";

            waiter.CallWaiter(name, dish);

            var answer = waiter.asnwerUnitTest;

            Assert.AreEqual(answer, true);
        }

        [TestMethod]
        public void JulieMirage_BuysEmperorChicken_IsAllergicTo_False()
        {
            //Given
            var waiter = new ChickenApp.Domain.Waiter();
            string name = "Julie Mirage";
            string dish = "emperor chicken";

            waiter.CallWaiter(name, dish);

            var answer = waiter.asnwerUnitTest;

            Assert.AreEqual(answer, false);
        }

        [TestMethod]
        public void BernardUnfortunate_BuysEmperorChicken_IsAllergicTo_True()
        {
            //Given
            var waiter = new ChickenApp.Domain.Waiter();
            string name = "Bernard Unfortunate";
            string dish = "emperor chicken";

            waiter.CallWaiter(name, dish);

            var answer = waiter.asnwerUnitTest;

            Assert.AreEqual(answer, true);
        }
    }
}
