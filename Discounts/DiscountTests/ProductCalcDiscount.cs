using Discounts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DiscountTests
{
    [TestClass]
    public class ProductCalcDiscount
    {
        [TestMethod]
        public void ShouldReturn0WhenTypeIsEmpty()
        {
            //Given
            Mock<IDataBaseProducts> DataBase = new Mock<IDataBaseProducts>();

            ProductCalc productCalc =
                new ProductCalc(DataBase.Object);

            DataBase.Setup(x => x.DoesProductExist("")).Returns(false);

            decimal expected = 0.00m;

            //When   
            decimal result = productCalc.CalculatePrice("");

            //Then
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ShouldReturn7WhenPriceIs10AndProductIsUbranie()
        {
            //Given
            Mock<IDataBaseProducts> DataBase = new Mock<IDataBaseProducts>();
            Mock<IDiscountCalc> Discount = new Mock<IDiscountCalc>();

            ProductCalc productCalc =
                new ProductCalc(Discount.Object,DataBase.Object);

            DataBase.Setup(x => x.GivePrice("Ubranie")).Returns(10m);
            Discount.Setup(x => x.GiveMeDiscount("Ubranie")).Returns(0.3m);

            decimal expected = 7m;

            //When   
            decimal result = productCalc.CalculatePrice("Ubranie");

            //Then
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void ShouldReturn12WhenPriceIs10AndProductIsButyZolwia()
        {
            //Given
            Mock<IDataBaseProducts> DataBase = new Mock<IDataBaseProducts>();
            Mock<IDiscountCalc> Discount = new Mock<IDiscountCalc>();

            ProductCalc productCalc =
                new ProductCalc(Discount.Object, DataBase.Object);

            DataBase.Setup(x => x.GivePrice("Buty Zolwia")).Returns(10m);
            Discount.Setup(x => x.GiveMeDiscount("Buty Zolwia")).Returns(0.2m);

            decimal expected = 12m;

            //When   
            decimal result = productCalc.CalculatePrice("Buty Zolwia");

            //Then
            Assert.AreEqual(expected, result);
        }
    }
}
