using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecondStringCalculator;
using System.Collections.Generic;

namespace Calculator.Test
{
    [TestClass]
    public class SumatorTest
    {
        [TestMethod]
        public void ShouldReturn0WhenNumberIs0()
        {
            //given - wsszytskie rzeczy, ktore potrzebuje by moc przeprowadzic test w fazie given
            var sumator = new Sumator();
            string value = "0";
            int expectedResult = 0;
            string temp = ",";

            //when - wywowalnei akcji ktora testujemy w tym wypadku testujemy metode GetSum
            int result = sumator.GetSum(value, temp);

            //then - Aseracje sprawdzenie poprawnosci dzialania kodu. To sa testy
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void ShouldReturn7WhenNumberIs1enetr2przecinek5()
        {
            //given - wsszytskie rzeczy, ktore potrzebuje by moc przeprowadzic test w fazie given
            var sumator = new Sumator();
            string value = "1\n2,4";
            int expectedResult = 7;
            string temp = ",";

            //when - wywowalnei akcji ktora testujemy w tym wypadku testujemy metode GetSum
            int result = sumator.GetSum(value, temp);

            //then - Aseracje sprawdzenie poprawnosci dzialania kodu. To sa testy
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void ShouldReturn3WhenNumberIs1And2()
        {
            //given - wsszytskie rzeczy, ktore potrzebuje by moc przeprowadzic test w fazie given
            var sumator = new Sumator();
            string value = "//;\n1;2";
            int expectedResult = 3;
            string temp = ";";

            //when - wywowalnei akcji ktora testujemy w tym wypadku testujemy metode GetSum
            int result = sumator.GetSum(value, temp);

            //then - Aseracje sprawdzenie poprawnosci dzialania kodu. To sa testy
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void ShouldReturn6WhenDelimiterIsStar()
        {
            //given - wsszytskie rzeczy, ktore potrzebuje by moc przeprowadzic test w fazie given
            var sumator = new Sumator();
            string value = "//[***]\n1***2***3";
            int expectedResult = 6;
            string temp = "***";

            //when - wywowalnei akcji ktora testujemy w tym wypadku testujemy metode GetSum
            int result = sumator.GetSum(value, temp);

            //then - Aseracje sprawdzenie poprawnosci dzialania kodu. To sa testy
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void ShouldReturn5WhenNumberIs5()
        {
            //given - wsszytskie rzeczy, ktore potrzebuje by moc przeprowadzic test w fazie given
            var sumator = new Sumator();
            string value = "5";
            int expectedResult = 5;
            string delimiter = null;

            //when - wywowalnei akcji ktora testujemy w tym wypadku testujemy metode GetSum
            int result = sumator.GetSum(value, delimiter);

            //then - Aseracje sprawdzenie poprawnosci dzialania kodu. To sa testy
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void ShouldReturn0WhenNumberIsNegative5()
        {
            //given - wsszytskie rzeczy, ktore potrzebuje by moc przeprowadzic test w fazie given
            var sumator = new Sumator();
            string value = "-5";
            int expectedResult = 0;
            string delimiter = null;

            //when - wywowalnei akcji ktora testujemy w tym wypadku testujemy metode GetSum
            int result = sumator.GetSum(value, delimiter);

            //then - Aseracje sprawdzenie poprawnosci dzialania kodu. To sa testy
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void ShouldReturn0WhenNumbersAreBothNull()
        {
            //given - wsszytskie rzeczy, ktore potrzebuje by moc przeprowadzic test w fazie given
            var sumator = new Sumator();
            string value = "";
            string value2 = "";
            int expectedResult = 0;
            string delimiter = null;

            //when - wywowalnei akcji ktora testujemy w tym wypadku testujemy metode GetSum
            int result = sumator.GetSum(value, value2, delimiter);

            //then - Aseracje sprawdzenie poprawnosci dzialania kodu. To sa testy
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void ShouldReturn0WhenNumbersAreNegative5AndNull()
        {
            //given - wsszytskie rzeczy, ktore potrzebuje by moc przeprowadzic test w fazie given
            var sumator = new Sumator();
            string value = "-5";
            string value2 = "";
            int expectedResult = 0;
            string delimiter = null;

            //when - wywowalnei akcji ktora testujemy w tym wypadku testujemy metode GetSum
            int result = sumator.GetSum(value, value2, delimiter);

            //then - Aseracje sprawdzenie poprawnosci dzialania kodu. To sa testy
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void ShouldReturn5WhenNumbersAre5AndNull()
        {
            //given - wsszytskie rzeczy, ktore potrzebuje by moc przeprowadzic test w fazie given
            var sumator = new Sumator();
            string value = "5";
            string value2 = "";
            int expectedResult = 5;
            string delimiter = null;

            //when - wywowalnei akcji ktora testujemy w tym wypadku testujemy metode GetSum
            int result = sumator.GetSum(value, value2, delimiter);

            //then - Aseracje sprawdzenie poprawnosci dzialania kodu. To sa testy
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void ShouldReturn6WhenNumbersAre1enetr23AndNull()
        {
            //given - wsszytskie rzeczy, ktore potrzebuje by moc przeprowadzic test w fazie given
            var sumator = new Sumator();
            string value = "1\n2,3";
            string value2 = "";
            int expectedResult = 6;
            string delimiter = ",";

            //when - wywowalnei akcji ktora testujemy w tym wypadku testujemy metode GetSum
            int result = sumator.GetSum(value, value2, delimiter);

            //then - Aseracje sprawdzenie poprawnosci dzialania kodu. To sa testy
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void ShouldReturnExceptionWhenNumbersAre1enetrNegative23AndNull()
        {
            //given - wsszytskie rzeczy, ktore potrzebuje by moc przeprowadzic test w fazie given
            var sumator = new Sumator();
            string value = "1\n-2,3";
            string value2 = "";
            int expectedResult = 4;
            string delimiter = ",";

            //when - wywowalnei akcji ktora testujemy w tym wypadku testujemy metode GetSum
            int result = sumator.GetSum(value, value2, delimiter);

            //then - Aseracje sprawdzenie poprawnosci dzialania kodu. To sa testy
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void ShouldReturn5WhenNumbersAreNullAnd5()
        {
            //given - wsszytskie rzeczy, ktore potrzebuje by moc przeprowadzic test w fazie given
            var sumator = new Sumator();
            string value = "";
            string value2 = "5";
            int expectedResult = 5;
            string delimiter = ",";

            //when - wywowalnei akcji ktora testujemy w tym wypadku testujemy metode GetSum
            int result = sumator.GetSum(value, value2, delimiter);

            //then - Aseracje sprawdzenie poprawnosci dzialania kodu. To sa testy
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void ShouldReturn8WhenNumbersAre3And5()
        {
            //given - wsszytskie rzeczy, ktore potrzebuje by moc przeprowadzic test w fazie given
            var sumator = new Sumator();
            string value = "3";
            string value2 = "5";
            int expectedResult = 8;
            string delimiter = "null";

            //when - wywowalnei akcji ktora testujemy w tym wypadku testujemy metode GetSum
            int result = sumator.GetSum(value, value2, delimiter);

            //then - Aseracje sprawdzenie poprawnosci dzialania kodu. To sa testy
            Assert.AreEqual(expectedResult, result);
        }
        // //[*][%]\n1*2%3

        [TestMethod]
        public void ShouldReturn6WhenNumbersAre1And2And3MultiDelimiters()
        {
            //given - wsszytskie rzeczy, ktore potrzebuje by moc przeprowadzic test w fazie given
            var sumator = new Sumator();
            string value = "//[*][%]\n1*2%3";
            int expectedResult = 6;
            List<string> delimiter = new List<string> { "*", "%" };

            //when - wywowalnei akcji ktora testujemy w tym wypadku testujemy metode GetSum
            int result = sumator.GetSum(value, delimiter);

            //then - Aseracje sprawdzenie poprawnosci dzialania kodu. To sa testy
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void ShouldReturn1WhenNumbersAre1And2Negatives()
        {
            //given - wsszytskie rzeczy, ktore potrzebuje by moc przeprowadzic test w fazie given
            var sumator = new Sumator();
            string value = "//[*][%]\n1*-2%-3";
            int expectedResult = 1;
            List<string> delimiter = new List<string> { "*", "%" };

            //when - wywowalnei akcji ktora testujemy w tym wypadku testujemy metode GetSum
            int result = sumator.GetSum(value, delimiter);

            //then - Aseracje sprawdzenie poprawnosci dzialania kodu. To sa testy
            Assert.AreEqual(expectedResult, result);
        }
    }
}
