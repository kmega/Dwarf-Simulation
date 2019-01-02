using Xunit;
using StringCalculator;

namespace StringCalculator.Test
{
    public class StringCalculator_IsStringCalculatorShould
    {
        private readonly StringCalculator _stringCalculator;

        public StringCalculator_IsStringCalculatorShould()
        {
            _stringCalculator = new StringCalculator();
        }

        [Fact]
        public void ReturnFalseGivenValueOf1()
        {
            var result = _stringCalculator.IsStringCalculator(1);

            Assert.False(result, "1 should not be string calculator");
        }
    }
}