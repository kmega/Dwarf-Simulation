using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProgramUnitTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestStringCalculator()
        {
            var calculator = new StringCalculator();
            string number = "0";
            int result = calculator.Add(number);
            Assert.AreEqual(number, result);
        }
    }
}
