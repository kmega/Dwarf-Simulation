using Moq;
using NUnit.Framework;
using ShopForLearnMock;
using System;

namespace Tests
{
    public class Tests
    {
        
        Mock<IDataBase> database = new Mock<IDataBase>();
        Mock<ICalendarDiscountCalculator> calendardiscount = new Mock<ICalendarDiscountCalculator>();
        Mock<IDiscountCalculator> discountcalc = new Mock<IDiscountCalculator>();




        [SetUp]
        public void Setup()
        {


        }

        [Test]
        public void Return10ForClothes()
        {
            //given
            Product product = new Product();
            product.Type = ProductType.Clothes;

            database.Setup(i => i.Price(product)).Returns(10);

            //when
            double result = database.Object.Price(product);

            //then

            Assert.AreEqual(10, result);
        }


        [Test]
        public void Return7ForClothesWorth10()
        {
            //given
            Product product = new Product();
            var datatime = new DateTime(1914,06,28);
            product.Type = ProductType.Clothes;
            database.Setup(i => i.Price(product)).Returns(10);
            discountcalc.Setup(i => i.CalcDiscount(product)).Returns(0.3);
            ProductCalc pricecalculator = new ProductCalc(calendardiscount.Object, discountcalc.Object, database.Object);

            //when;
            double result = pricecalculator.Calculate(datatime, product);


            //then

            Assert.AreEqual(7, result);
        }

        [Test]
        public void Return18ForTortoiseWorth15()
        {
            //given
            Product product = new Product();
            var datatime = new DateTime(1914, 06, 28);
            product.Type = ProductType.TortoiseShoes;
            database.Setup(i => i.Price(product)).Returns(15);
            discountcalc.Setup(i => i.CalcDiscount(product)).Returns(-0.2);
            ProductCalc pricecalculator = new ProductCalc(calendardiscount.Object, discountcalc.Object, database.Object);

            //when;
            double result = pricecalculator.Calculate(datatime, product);


            //then

            Assert.AreEqual(18, result);



        }

        [Test]
        public void Return5ForClotheseAtChrismtas()
        {
            //given
            DateTime data = new DateTime(2019, 12, 20);
            Product product = new Product();
            product.Type = ProductType.Clothes;
            database.Setup(i => i.Price(product)).Returns(10);
            discountcalc.Setup(i => i.CalcDiscount(product)).Returns(0.3);
            calendardiscount.Setup(i => i.CalcDiscountDate(data)).Returns(0.2);

            ProductCalc pricecalculator = new ProductCalc(calendardiscount.Object, discountcalc.Object, database.Object);

            //when;
            double result = pricecalculator.Calculate(data, product);


            //then

            Assert.AreEqual(5, result);



        }
        [Test]
        public void WithImplementationReturn5ForClotheseAtChrismtas()
        {
            //given
            DateTime data = new DateTime(2019, 12, 20);
            Product product = new Product();
            product.Type = ProductType.Clothes;
            database.Setup(i => i.Price(product)).Returns(10);
            ProductCalc pricecalculator = new ProductCalc(new CalendarDiscount(), new DiscountCalc(), database.Object);



            //when;
            double result = pricecalculator.Calculate(data, product);


            //then

            Assert.AreEqual(5, result);

        }
        [Test]
        public void ReturnZeroForDiscountinNovember()
        {
            //given
            DateTime data = new DateTime(2019, 11, 20);

         


            //when;
            double result = new CalendarDiscount().CalcDiscountDate(data);


            //then

            Assert.AreEqual(0, result);


        }

        [Test]
        public void Return0dot5ForBlackFridayDiscout()
        {
            //given
            DateTime data = new DateTime(2019, 11, 29);


   
            //when;
            double result = new CalendarDiscount().CalcDiscountDate(data);


            //then

            Assert.AreEqual(0.5, result);


        }
        [Test]
        public void ShouldReturn2OnBlacFridayForClothes()
        {
            //given
            Product product = new Product();
            DateTime data = new DateTime(2019, 11, 29);
            product.Type = ProductType.Clothes;
            database.Setup(i => i.Price(product)).Returns(10);
            ProductCalc pc = new ProductCalc(new CalendarDiscount(), new DiscountCalc(), database.Object);


            //when;

            double result = pc.Calculate(data, product);

            //then

            Assert.AreEqual(2, result);

        }

        [Test]
        public void ShouldReturn18ForTortoise()
        {
            Product product = new Product();
            DateTime data = new DateTime(2019, 11, 27);
            product.Type = ProductType.TortoiseShoes;
            database.Setup(i => i.Price(product)).Returns(15);
            ProductCalc pc = new ProductCalc(new CalendarDiscount(), new DiscountCalc(), database.Object);


            //when;

            double result = pc.Calculate(data, product);

            //then

            Assert.AreEqual(18, result);

        }



    }
}