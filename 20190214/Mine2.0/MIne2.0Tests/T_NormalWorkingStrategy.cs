using System;
using System.Linq;
using Mine2._0;
using Moq;
using NUnit.Framework;

namespace MIne2._0Tests
{
    [TestFixture]
    public class T_NormalWorkingStrategy
    {
        private Mock<IRandomizer> randomizer;
        [SetUp]
        public void Setup()
        {
            randomizer = new Mock<IRandomizer>();
        }

        [Test]
        public void GetsOneMithrilWithOneWorkIteration()
        {
            //given
            randomizer.Setup(x => x.RandomWorkIteration()).Returns(1);
            randomizer.Setup(x => x.GenerateRadnomFromRange()).Returns(1);

            //when
            var worker = DwarfFactory.CreateSingleDwarf(E_DwarfType.Father);
            worker.Work(new Schaft(), randomizer.Object);

            //then
            Assert.IsTrue(worker._backpack.Count == 1);
            Assert.IsTrue(worker._backpack.All(x => x == E_Minerals.Mithril));

        }

        [Test]
        public void GetsTwoSilverslWithTwoWorkIteration()
        {
            //given
            randomizer.Setup(x => x.RandomWorkIteration()).Returns(2);
            randomizer.Setup(x => x.GenerateRadnomFromRange()).Returns(50);
            var work = new NormalWorkingStrategy();

            //when
            var worker = DwarfFactory.CreateSingleDwarf(E_DwarfType.Father);
            worker.Work(new Schaft(), randomizer.Object);

            //then
            Assert.IsTrue(worker._backpack.Count == 2);
            Assert.IsTrue(worker._backpack.All(x => x == E_Minerals.Silver));
        }

        [Test]
        public void GetsThreeSilverslWithTwoWorkIteration()
        {
            //given
            randomizer.Setup(x => x.RandomWorkIteration()).Returns(3);
            randomizer.Setup(x => x.GenerateRadnomFromRange()).Returns(50);
            var work = new NormalWorkingStrategy();

            //when
            var worker = DwarfFactory.CreateSingleDwarf(E_DwarfType.Father);
            worker.Work(new Schaft(), randomizer.Object);

            //then
            Assert.IsTrue(worker._backpack.Count == 3);
            Assert.IsTrue(worker._backpack.All(x => x == E_Minerals.Silver));
        }
    }
}
