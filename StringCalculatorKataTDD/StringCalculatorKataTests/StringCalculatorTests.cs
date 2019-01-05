using NUnit.Framework;
using StringCalculatorKata;

namespace StringCalculatorKataTests
{
    [TestFixture]
    public class StringCalculatorTests
    {
        [Test]
        public void Add_EmptyString_ReturnsZero()
        {
            StringCalculator sc = new StringCalculator();

            int result = sc.Add("");

            Assert.That(0, Is.EqualTo(result));
        }

        [Test]
        public void Add_SingleNumber_ReturnsThatNumber()
        {
            StringCalculator sc = new StringCalculator();

            int result = sc.Add("1");

            Assert.AreEqual(1, result);
        }
    }
}
