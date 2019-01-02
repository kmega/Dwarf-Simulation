using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculator;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]

        public void ShouldReturn1()
        {
            int expected = 6;
            var calculator = new Calculator();
            string value = "1,2\n3";
            int result = calculator.Add(value);
            Assert.AreEqual(expected, result);
            
        }

        [TestMethod]

        public void ShouldReturn1IfGiven1()
        {
            // Given
            int expected = 1;
            string value = "1";
            var calculator = new Calculator();
            
            // When
            int result = calculator.Add(value);

            // Then
            Assert.AreEqual(expected, result);

        }

        [TestMethod]

        public void ShouldReturn3For1And2EvenIfManyDelimiters()
        {
            // Given
            int expected = 3;
            string value = "1,,2";
            var calculator = new Calculator();

            // When
            int result = calculator.Add(value);

            // Then
            Assert.AreEqual(expected, result);

        }

    }
}
