using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProgramUnitTest
{
    [TestClass]
    public class StringCalculator
    {
        [TestMethod]
        public void Return0When0()
        {
            var calculator = new StringCalculator();
            string value = "0";
            int result = calculator.Add(value);
            Assert.AreEqual(0, result);
        }
    }
}
