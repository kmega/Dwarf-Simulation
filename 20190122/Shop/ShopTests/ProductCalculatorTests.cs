using Moq;
using NUnit.Framework;
using Shop;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopTests
{
    class ProductCalculatorTests
    {
        [SetUp]
        public void Init()
        {

        }

        [Test]
        public void ShouldReturnCorrectPriceWhenProductIsClothAndDateIs24_12_2018()
        {
            //given
            var discountByType = new Mock<IDiscountCalculator>();
            var discountByDate = new Mock<ICalendarDiscountCalculator>();
            var price = new Mock<IPrice>();

            discountByType.Setup(p => p.Calculate(ProductType.CLOTH)).Returns(0.7);
            discountByDate.Setup(p => p.Calculate(new DateTime(2018, 12, 24))).Returns(0.8);
            price.Setup(p => p.ReturnPrice()).Returns(10);

            Product product = new Product(ProductType.CLOTH, "Czapka");

            ProductCalculator pr = new ProductCalculator(discountByDate.Object, discountByType.Object, price.Object);
            //when
            double result = pr.Calculate(product, new DateTime(2018,12,24));
            //then
            Assert.AreEqual(result, 5.6);
        }

        [Test]
        public void ShouldReturnCorrectPriceWhenProductIsShoesAndDateIs29_12_2018()
        {
            //given
            var discountByType = new Mock<IDiscountCalculator>();
            var discountByDate = new Mock<ICalendarDiscountCalculator>();
            var price = new Mock<IPrice>();

            discountByType.Setup(p => p.Calculate(ProductType.TURTLE_ORTHOPEDIC_SHOES)).Returns(1.2);
            discountByDate.Setup(p => p.Calculate(new DateTime(2018, 12, 29))).Returns(0.5);
            price.Setup(p => p.ReturnPrice()).Returns(15);

            Product product = new Product(ProductType.TURTLE_ORTHOPEDIC_SHOES, "Shoes");

            ProductCalculator pr = new ProductCalculator(discountByDate.Object, discountByType.Object, price.Object);
            //when
            double result = pr.Calculate(product, new DateTime(2018, 12, 29));
            //then
            Assert.AreEqual(result, 9);
        }
    }
}
