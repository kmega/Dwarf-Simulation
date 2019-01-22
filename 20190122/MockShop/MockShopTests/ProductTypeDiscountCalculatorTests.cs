using MockShop;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MockShopTests
{
    class ProductTypeDiscountCalculatorTests
    {
        private ProductTypeDiscountCalculator productTypeCalculator;
        [SetUp]
        public void Setup()
        {
            productTypeCalculator = new ProductTypeDiscountCalculator();
        }

        [Test]
        public void T01_ShouldReturn0WhenProductTypeNone()
        {
            //when
            var result = productTypeCalculator.Calculate(ProductType.None);
            //then
            Assert.AreEqual(0, result);
        }
        [Test]
        public void T02_ShouldReturn0dot2WhenProductTypeCloth()
        {
            //when
            var result = productTypeCalculator.Calculate(ProductType.Clothes);
            //then
            Assert.AreEqual(0.2, result);
        }
        [Test]
        public void T03_ShouldReturnMinus0dot2WhenProductTypeTrutleShoes()
        {
            //when
            var result = productTypeCalculator.Calculate(ProductType.TurtleOrthopedicShoes);
            //then
            Assert.AreEqual(-0.2, result);
        }
    }
}
