using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MockInterfaceZnizki;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {
        IDiscount_Calc calculator = new ProductCalc();
        [TestMethod]
        public void ShouldReturnChristmassDiscount()
        {
          
            double ExpectedPrice = 0.8;
            DateTime date = new DateTime(2018,12,23);
            
            double ResultPrice = calculator.Calculate(date);
            Assert.AreEqual(ExpectedPrice, ResultPrice);

        }
        [TestMethod]
        public void ShouldReturnBlackFridayDiscount()
        {
            DateTime date = new DateTime(2018, 11, 29);
            double ExpectedPrice = 0.5;
            double ResultPrice = calculator.Calculate(date);
            Assert.AreEqual(ExpectedPrice, ResultPrice);
        }
        [TestMethod]
        public void ShouldReturnNowDiscount()
        {
            DateTime date = DateTime.Now;
            double ExpectedPrice = 1;
            double ResultPrice = calculator.Calculate(date);
            Assert.AreEqual(ExpectedPrice, ResultPrice);
        }
        [TestMethod]
    
        public void ShouldReturnPriceProductWithoutDIscount()
        {
            double ExpectedPrice = 1;
            double ResultPrice = calculator.Calculate(ProductCalc.Type.Others);
            Assert.AreEqual(ExpectedPrice, ResultPrice);
        }
        [TestMethod]
        public void ShouldReturnClothesPriceWithDiscount()
        {
            double ExpectedPrice = 7;           
            double ResultPrice = calculator.Calculate(ProductCalc.Type.Clothes);
            Assert.AreEqual(ExpectedPrice, ResultPrice);

        }
        [TestMethod]
        public void ShouldReturnTurtleShoesDiscount()
        {
            double ExpectedPrice = 18;
            double ResultPrice = calculator.Calculate(ProductCalc.Type.TurtleShoes);
            Assert.AreEqual(ExpectedPrice, ResultPrice);

        }
        //Discount Calc:
        //Jeśli produkt jest typu Ubrania to dajemy zniżke 30%
        //Jeżeli produkt jest typu Żółwie Buty Ortopedyczne to dajemy zwyżkę 20%

        //Czarny klocek nienawiści:
        //W przypadku obliczania obniżki należy pobrać cene z bazy danych :) Lol przecież tego nie zrobicie bo to jest tylko Interfejs.
        //I zapisana do bazy Turtle Lol ^ 2 :)

        //Przyjmijmy, że cena początkowa dla Ubrań to 10 pesos, a dla butów ort.żółwia 15. 
    }


}
