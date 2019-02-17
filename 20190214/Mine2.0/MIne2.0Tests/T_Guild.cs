using System.Collections.Generic;
using System.Linq;
using Mine2._0;
using Moq;
using NUnit.Framework;

namespace MIne2._0Tests
{
    [TestFixture]
    public class T_Guild
    {
        private Mock<ITryBirth> birthMock;
        private Mock<IDwarfTypeRandomizer> typeMock;
        private Mock<IRandomizer> mineMock;
        private Mock<IGuildRandomizer> guildMock;
        private Mock<IOutputWriter> mockWriter;
        [SetUp]
        public void Setup()
        {
            birthMock = new Mock<ITryBirth>();
            typeMock = new Mock<IDwarfTypeRandomizer>();
            mineMock = new Mock<IRandomizer>();
            guildMock = new Mock<IGuildRandomizer>();
            mockWriter = new Mock<IOutputWriter>();
        }

        [Test]
        public void ExchangesMineralsAndTakesProvisionAndWorkersHaveEmptyBackpacksAndNotZeroDaily()
        {
            //given
            guildMock.Setup(x => x.SetMithrilValue()).Returns(20);
            typeMock.Setup(x => x.GetRandomDwarfType()).Returns(E_DwarfType.Father);
            birthMock.Setup(x => x.TryBirth()).Returns(false);
            mineMock.Setup(x => x.RandomWorkIteration()).Returns(1);
            mineMock.Setup(x => x.GenerateRadnomFromRange()).Returns(1);

            var guild = new Guild(guildMock.Object);
            List<Dwarf> worker = new Hospital(typeMock.Object, birthMock.Object).CreateInitialState(10);

            new Mine(mineMock.Object).PerformMining(new List<IWork>(worker), mockWriter.Object);
            List<IMoneyOperator> mWorkers = new List<IMoneyOperator>(worker);

            //when
            guild.ExchangeOutputToMoney(mWorkers, new Bank(), mockWriter.Object);

            //then
            Assert.IsTrue(worker.All(x => x._dwarfType == E_DwarfType.Father));
            Assert.IsTrue(worker.All(x => x.ShowBackpack().Count == 0));
            Assert.IsTrue(worker.All(x => x._bankAccount._dailyIncome == 11.55m));
            Assert.IsTrue(worker.Count() == 10);
            Assert.IsTrue(guild._account._overallIncome == 50);
        }

        [Test]
        public void ExchangesMineralsAndTakesProvisionFrom6WorkersAndHaveEmptyBackpacksAndNotZeroDaily()
        {
            //given
            guildMock.Setup(x => x.SetMithrilValue()).Returns(20);
            typeMock.Setup(x => x.GetRandomDwarfType()).Returns(E_DwarfType.Father);
            birthMock.Setup(x => x.TryBirth()).Returns(false);
            mineMock.Setup(x => x.RandomWorkIteration()).Returns(1);
            mineMock.Setup(x => x.GenerateRadnomFromRange()).Returns(1);

            var guild = new Guild(guildMock.Object);
            List<Dwarf> worker = new Hospital(typeMock.Object, birthMock.Object).CreateInitialState(10);
            worker.Insert(2, DwarfFactory.CreateSingleDwarf(E_DwarfType.Sabouter));

            var mine = new Mine(mineMock.Object);
            mine.PerformMining(new List<IWork>(worker), mockWriter.Object);

            List<IMoneyOperator> mWorkers = new List<IMoneyOperator>(worker);
            //when
            guild.ExchangeOutputToMoney(mWorkers, new Bank(), mockWriter.Object);

            //then
            Assert.IsTrue(worker.Count(x => x._dwarfType == E_DwarfType.Father) == 10);
            Assert.IsTrue(worker.Count(x => x._isAlive == true) == 6);
            Assert.IsTrue(worker.Count() == 11);
            Assert.IsTrue(guild._account._overallIncome == 30);
            Assert.IsTrue(mine._schafts.Any(x => x.SchaftStatus == E_SchaftStatus.Broken));
            Assert.IsTrue(mine.Stats.Count == 6);
            Assert.IsTrue(mine.Stats.All(x => x == E_Minerals.Mithril));
        }
    }
}
