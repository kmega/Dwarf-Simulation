using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProgramUnitTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void Return0When0()
        {
            StringCalculator.Calculator calculator = new StringCalculator.Calculator();
            string number = "0";
            int result = calculator.Add(number);
            Assert.AreEqual(0, result);
        }
    }
}
