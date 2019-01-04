using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void Return0IfNull()
        {
            //given
            StringCalc_v2.StringCalculator calc = new StringCalc_v2.StringCalculator();

            string number = "";

            //result

            int result = calc.Add(number);

            Assert.AreEqual(0, result);

        }

        [Test]
        public void ReturnSimpleSumWithoutUsingDelimiter()
        {
            //given
            StringCalc_v2.StringCalculator calc = new StringCalc_v2.StringCalculator();

            string number = "2,3,4";

            //result

            int result = calc.Add(number);

            Assert.AreEqual(9, result);

        }

        [Test]
        public void ChosenDelimiter()
        {
            //given
            StringCalc_v2.StringCalculator calc = new StringCalc_v2.StringCalculator();

            string number = "//[***]\n2***5";

            //result

            int result = calc.Add(number);

            Assert.AreEqual(7, result);

        }
    }
}