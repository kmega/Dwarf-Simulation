using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecondStringCalculator;

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

            //when - wywowalnei akcji ktora testujemy w tym wypadku testujemy metode GetSum
            int result = sumator.GetSum(value);

            //then - Aseracje sprawdzenie poprawnosci dzialania kodu. To sa testy
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void ShouldReturn6WhenNumberIs1enetr2przecinek3()
        {
            //given - wsszytskie rzeczy, ktore potrzebuje by moc przeprowadzic test w fazie given
            var sumator = new Sumator();
            string value = "1\n2,3";
            int expectedResult = 6;

            //when - wywowalnei akcji ktora testujemy w tym wypadku testujemy metode GetSum
            int result = sumator.GetSum(value);

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

            //when - wywowalnei akcji ktora testujemy w tym wypadku testujemy metode GetSum
            int result = sumator.GetSum(value);

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

            //when - wywowalnei akcji ktora testujemy w tym wypadku testujemy metode GetSum
            int result = sumator.GetSum(value, value2);

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

            //when - wywowalnei akcji ktora testujemy w tym wypadku testujemy metode GetSum
            int result = sumator.GetSum(value, value2);

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

            //when - wywowalnei akcji ktora testujemy w tym wypadku testujemy metode GetSum
            int result = sumator.GetSum(value, value2);

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

            //when - wywowalnei akcji ktora testujemy w tym wypadku testujemy metode GetSum
            int result = sumator.GetSum(value, value2);

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

            //when - wywowalnei akcji ktora testujemy w tym wypadku testujemy metode GetSum
            int result = sumator.GetSum(value, value2);

            //then - Aseracje sprawdzenie poprawnosci dzialania kodu. To sa testy
            Assert.AreEqual(expectedResult, result);
        }
    }
}
