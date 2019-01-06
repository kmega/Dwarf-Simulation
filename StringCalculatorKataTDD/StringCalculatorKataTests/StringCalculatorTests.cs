using NUnit.Framework;
using StringCalculatorKata;
using System;

namespace StringCalculatorKataTests
{
    [TestFixture]
    public class StringCalculatorTests
    {
        public StringCalculator sc = new StringCalculator();

        [TestCase(0, "")]
        public void Add_EmptyString_ReturnsZero(int expected, string numbers)
        {
            var result = sc.Add(numbers);

            Assert.That(expected, Is.EqualTo(result));
        }

        [TestCase(14, "14")]
        [TestCase(0, "0")]
        public void Add_SingleNumber_ReturnsThatNumber(int expected, string numbers)
        {
            var result = sc.Add(numbers);

            Assert.AreEqual(expected, result);
        }

        [TestCase(3, "1,2")]
        [TestCase(9, "1,2,6")]
        [TestCase(10, "5,0,5")]
        [TestCase(6, "1\n2,3")]
        [TestCase(3, "//;\n1;2")]
        [TestCase(2, "2,1001")]
        [TestCase(6, "//***\n1***2***3")]
        [TestCase(6, "//*****\n1*****2*****3")]
        [TestCase(6, "//*%\n1*2%3")] 
        public void Add_MultipleNumbers_ReturnsSum(int expected, string numbers)
        {
            var result = sc.Add(numbers);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Add_NegativeNumbers_ThrowsException()
        {
            string number = "1\n2,-3";
            var exception = Assert.Throws<Exception>(() => sc.Add(number));
            Assert.AreEqual("Negatives not allowed -3", exception.Message);
        }

        
    }
}
