using Moq;
using NUnit.Framework;
using ShopForLearnMock;
using System;

namespace Tests
{
    public class Tests
    {
        Product product = new Product();
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
            var datatime = DateTime.Today;
            product.Type = ProductType.Clothes;
            database.Setup(i => i.Price(product)).Returns(10);
            discountcalc.Setup(i => i.CalcDiscount(product)).Returns(3);
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
            var datatime = DateTime.Today;
            product.Type = ProductType.TortoiseShoes;
            database.Setup(i => i.Price(product)).Returns(15);
            discountcalc.Setup(i => i.CalcDiscount(product)).Returns(-3);
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
          
            product.Type = ProductType.Clothes;
            database.Setup(i => i.Price(product)).Returns(10);
            discountcalc.Setup(i => i.CalcDiscount(product)).Returns(3);
            calendardiscount.Setup(i => i.CalcDiscountDate(data)).Returns(2);
          
            ProductCalc pricecalculator = new ProductCalc(calendardiscount.Object, discountcalc.Object, database.Object);

            //when;
            double result = pricecalculator.Calculate(data, product);


            //then

            Assert.AreEqual(5, result);



        }



    }
}