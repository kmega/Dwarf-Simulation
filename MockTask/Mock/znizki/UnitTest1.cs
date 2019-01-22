using Moq;
using Mock;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Test1()
        {
            Mock<IDiscountCalc> discountCalc = new Mock<IDiscountCalc>();
            ProductCalc product = new ProductCalc(discountCalc.Object);
            
            discountCalc.Setup(i => i.GiveDiscount("ubrania")).Returns(0.2m);

            var result = product.Calculate("ubrania");
            Assert.AreEqual(8 , result);
        }
    }
}