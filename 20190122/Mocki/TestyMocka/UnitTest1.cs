using NUnit.Framework;
using Mocki;
using Moq;


namespace Tests
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
			
		}

		[Test]
		public void WhenTypeISClothesShouldReturn30percDiscount()
		{
			//given
			var idc = new Mock<IDiscountCalculator>();
			var icdc = new Mock<ICalendarDiscountCalculator>();
			ProductCalculator pc = new ProductCalculator(idc.Object, icdc.Object);
			idc.Setup(i => i.Calculate(10.0m, "Clothes")).Returns(0.3m);
			icdc.Setup(i => i.Calculate()).Returns(0.0m);
			decimal expected = 7.0m;

			//when
			decimal actual = pc.CalculatePrice(10.0m, "Clothes");

			//then
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void TestIfTurtleShoesCost20percentageMore()
		{
			//given
			var idc = new Mock<IDiscountCalculator>();
			var icdc = new Mock<ICalendarDiscountCalculator>();
			var TurtShoes = "TurtleShoes";
			ProductCalculator pc = new ProductCalculator(idc.Object, icdc.Object);
			idc.Setup(i => i.Calculate(15.0m, TurtShoes)).Returns(1.2m);
			icdc.Setup(i => i.Calculate()).Returns(0.0m);
			decimal expected = 18.0m;

			//when
			decimal actual = pc.CalculatePrice(15.0m, TurtShoes);

			//then
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void WhenIsBlackFridayProducktShouldCostHalfOfPrice()
		{
			//given
			var idc = new Mock<IDiscountCalculator>();
			var icdc = new Mock<ICalendarDiscountCalculator>();
			var Other = "Other";
			ProductCalculator pc = new ProductCalculator(idc.Object, icdc.Object);
			idc.Setup(i => i.Calculate(10.0m, Other)).Returns(0.0m);
			icdc.Setup(i => i.Calculate()).Returns(0.5m);
			decimal expected = 5.0m;

			//when
			decimal actual = pc.CalculatePrice(10.0m, Other);

			//then
			Assert.AreEqual(expected, actual);
		}
	}
}