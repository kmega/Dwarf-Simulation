using System.Linq;
using Mine2._0;
using Moq;
using NUnit.Framework;

namespace MIne2._0Tests
{
    [TestFixture]
    public class T_SimulationEngine
    {
        private Mock<ITryBirth> birthMock;
        private Mock<IDwarfTypeRandomizer> typeMock;
        private Mock<IRandomizer> mineMock;
        private Mock<IGuildRandomizer> guildMock;
        private Mock<IOutputWriter> mockPresenter;
        [SetUp]
        public void Setup()
        {
            birthMock = new Mock<ITryBirth>();
            typeMock = new Mock<IDwarfTypeRandomizer>();
            mineMock = new Mock<IRandomizer>();
            guildMock = new Mock<IGuildRandomizer>();
            mockPresenter = new Mock<IOutputWriter>();
        }

        [Test]
        public void T01_CreatesNewIntitalStateWithOnly10Fathers()
        {
            //given
            typeMock.Setup(x => x.GetRandomDwarfType()).Returns(E_DwarfType.Father);


            //when
            var se = new SimulationEngine(1, typeMock.Object, new DwarthIsBrithRandomizer());
            se.Start();

            //then
            Assert.IsTrue(se.simulationState._allDwarves.All(x => x._dwarfType == E_DwarfType.Father));
            Assert.IsTrue(se.simulationState._allDwarves.Count() == 10);

        }

        [Test]
        public void T02_CreatesNewIntitalStateWithBase10FathersAndTwoExtraAreBorn()
        {
            //given
            typeMock.Setup(x => x.GetRandomDwarfType()).Returns(E_DwarfType.Father);
            birthMock.Setup(x => x.TryBirth()).Returns(true);

            //when
            var se = new SimulationEngine(3, typeMock.Object, birthMock.Object);
            se.Start();

            //then
            Assert.IsTrue(se.simulationState._allDwarves.All(x => x._dwarfType == E_DwarfType.Father));
            Assert.IsTrue(se.simulationState._allDwarves.All(x => x._workStrategy is NormalWorkingStrategy));
            Assert.IsTrue(se.simulationState._allDwarves.Count() == 12);
        }

        [Test]
        public void T03_CreatesNewIntitalStateWithBase10FathersAndOneSabouterIsAddedAndPerformsHisKaboomAction()
        {
            //given
            typeMock.Setup(x => x.GetRandomDwarfType()).Returns(E_DwarfType.Father);
            mineMock.Setup(x => x.RandomWorkIteration()).Returns(1);
            mineMock.Setup(x => x.GenerateRadnomFromRange()).Returns(1);

            //when
            var se = new SimulationEngine(1, typeMock.Object, birthMock.Object, mineMock.Object);
            se.simulationState._allDwarves.Add(DwarfFactory.CreateSingleDwarf(E_DwarfType.Sabouter));
            se.Start();

            //then
            Assert.IsTrue(se.simulationState._allDwarves.Count() == 6);
            Assert.IsTrue(se.simulationState._numberOfDeadDwarves == 5);
            Assert.IsTrue(se.simulationState._allExtractedMinerals.Count == 6);
            Assert.IsTrue(se.simulationState._allExtractedMinerals.All(x => x == E_Minerals.Mithril));
        }

        [Test]
        public void T04_CreatesIntitalStateWith10FathersWhoPerfromWorkAndExchangeMaterialsInGuildCommisionAndTaxIsCollectedAndContainedInTaxAccount()
        {
            //given
            typeMock.Setup(x => x.GetRandomDwarfType()).Returns(E_DwarfType.Father);
            mineMock.Setup(x => x.RandomWorkIteration()).Returns(1);
            mineMock.Setup(x => x.GenerateRadnomFromRange()).Returns(1);
            guildMock.Setup(x => x.SetMithrilValue()).Returns(20);

            //when
            var se = new SimulationEngine(1, typeMock.Object, birthMock.Object, mineMock.Object, guildMock.Object, mockPresenter.Object);
            se.Start();

            //then
            Assert.IsTrue(se.simulationState._allDwarves.Count() == 10);
            Assert.IsTrue(se.simulationState._allExtractedMinerals.Count == 10);
            Assert.IsTrue(se.simulationState._allExtractedMinerals.All(x => x == E_Minerals.Mithril));
            Assert.IsTrue(se.simulationState._guildBankAccount == 50m);
            Assert.IsTrue(se.simulationState._allDwarves.All(x => x._backpack.Count == 0));
            Assert.IsTrue(se.simulationState._servedFoodRations == 10);
            Assert.IsTrue(se.simulationState._allDwarves.All(x => x._bankAccount._overallIncome == 5.77m));
            Assert.IsTrue(se.simulationState._taxBankAccount == 34.5m);
        }

        [Test]
        public void T05_CreatesIntitalStateWith10SinglesWhoPerfromWorkAndExchangeMaterialsInGuildCommisionAndTaxIsCollectedAndContainedInTaxAccountAndTheyBuyItemsFromShop()
        {
            //given
            typeMock.Setup(x => x.GetRandomDwarfType()).Returns(E_DwarfType.Single);
            mineMock.Setup(x => x.RandomWorkIteration()).Returns(1);
            mineMock.Setup(x => x.GenerateRadnomFromRange()).Returns(1);
            guildMock.Setup(x => x.SetMithrilValue()).Returns(20);

            //when
            var se = new SimulationEngine(1, typeMock.Object, birthMock.Object, mineMock.Object, guildMock.Object, mockPresenter.Object);

            se.Start();

            //then
            Assert.IsTrue(se.simulationState._allDwarves.Count() == 10);
            Assert.IsTrue(se.simulationState._allExtractedMinerals.Count == 10);
            Assert.IsTrue(se.simulationState._allExtractedMinerals.All(x => x == E_Minerals.Mithril));
            Assert.IsTrue(se.simulationState._guildBankAccount == 50m);
            Assert.IsTrue(se.simulationState._allDwarves.All(x => x._backpack.Count == 0));
            Assert.IsTrue(se.simulationState._servedFoodRations == 10);
            Assert.IsTrue(se.simulationState._allDwarves.All(x => x._bankAccount._overallIncome == 5.77m));
            Assert.IsTrue(se.simulationState._taxBankAccount == 34.5m);
            Assert.AreEqual(57.7m, se.simulationState._boughtProducts[E_MarketPlace_Products.Alcohol]);
            Assert.AreEqual(57.7m, se.simulationState._marketAccount);
        }

        [Test]
        public void T06E2ETestWithNotEnoughFoodAndSimulationsBreaks()
        {
            //given
            typeMock.Setup(x => x.GetRandomDwarfType()).Returns(E_DwarfType.Single);
            birthMock.Setup(x => x.TryBirth()).Returns(false);
            mineMock.Setup(x => x.RandomWorkIteration()).Returns(1);
            mineMock.Setup(x => x.GenerateRadnomFromRange()).Returns(1);
            guildMock.Setup(x => x.SetMithrilValue()).Returns(20);

            //when
            var se = new SimulationEngine(30, typeMock.Object, birthMock.Object, mineMock.Object, guildMock.Object, mockPresenter.Object);

            se.simulationState._allDwarves.Add(DwarfFactory.CreateSingleDwarf(E_DwarfType.Father));
            se.Start();

            //then
            mockPresenter.Verify(x => x.WriteLine($"Simulation failed due to breaking conditions"));
            Assert.IsTrue(se.simulationState._currentDay == 20);
            Assert.IsTrue(se.simulationState._allDwarves.Count() == 11);
            Assert.IsTrue(se.simulationState._allExtractedMinerals.Count == 231);
            Assert.IsTrue(se.simulationState._allExtractedMinerals.All(x => x == E_Minerals.Mithril));
            Assert.IsTrue(se.simulationState._guildBankAccount == 1155m);
            Assert.IsTrue(se.simulationState._allDwarves.All(x => x._backpack.Count == 0));
            Assert.IsTrue(se.simulationState._servedFoodRations == 220);
            Assert.IsTrue(se.simulationState._allDwarves.All(x => x._bankAccount._overallIncome == 115.4m));
            Assert.IsTrue(se.simulationState._taxBankAccount == 796.95m);
            Assert.AreEqual(1154m, se.simulationState._boughtProducts[E_MarketPlace_Products.Alcohol]);
            Assert.AreEqual(57.6m, se.simulationState._boughtProducts[E_MarketPlace_Products.Food]);
            Assert.AreEqual(1269.4m, se.simulationState._marketAccount);
        }

        [Test]
        public void T07E2ETestWithHappyPathWithoutSuicidersAndNoHunger()
        {
            //given
            typeMock.Setup(x => x.GetRandomDwarfType()).Returns(E_DwarfType.Single);
            mineMock.Setup(x => x.RandomWorkIteration()).Returns(1);
            birthMock.Setup(x => x.TryBirth()).Returns(false);
            mineMock.Setup(x => x.GenerateRadnomFromRange()).Returns(1);
            guildMock.Setup(x => x.SetMithrilValue()).Returns(20);

            //when
            var se = new SimulationEngine(30, typeMock.Object, birthMock.Object, mineMock.Object, guildMock.Object, mockPresenter.Object);
            se.Start();
            var mithrilAmount = se.simulationState._allExtractedMinerals.Count(z => z == E_Minerals.Mithril);
            var dirtGoldAmount = se.simulationState._allExtractedMinerals.Count(z => z == E_Minerals.DritGold);
            var goldAmount = se.simulationState._allExtractedMinerals.Count(z => z == E_Minerals.Gold);
            var silverAmount = se.simulationState._allExtractedMinerals.Count(z => z == E_Minerals.Silver);

            //then
            foreach (var dwarf in se.simulationState._allDwarves)
            {
                mockPresenter.Verify(x => x.WriteLine($"Dwarf: {dwarf.ToString()} was born"));
                foreach (var backpackItem in dwarf._backpack)
                {
                    mockPresenter.Verify(x => x.WriteLine($"{dwarf.ToString()} mined {backpackItem} of value"));
                }
            }

            for (int i = 0; i < se.simulationState._currentDay; i++)
            {
                mockPresenter.Verify(x => x.WriteLine($"Day: {i + 1}"));
            }

            mockPresenter.Verify(x => x.WriteLine($"During simulation {se.simulationState._numberOfBirths} dwarves was born"));
            mockPresenter.Verify(x => x.WriteLine($"During simulation died {se.simulationState._numberOfDeadDwarves} dwarves"));

            mockPresenter.Verify(x => x.WriteLine($"Marketplace statistics:"));
            mockPresenter.Verify(x => x.WriteLine($"{se.simulationState._boughtProducts[E_MarketPlace_Products.Alcohol]} units of alcohol was bought"));
            mockPresenter.Verify(x => x.WriteLine($"{se.simulationState._boughtProducts[E_MarketPlace_Products.Food]} units of food was bought"));

            mockPresenter.Verify(x => x.WriteLine($"Mine statistics:"));

            mockPresenter.Verify(x => x.WriteLine($"{dirtGoldAmount} units of DirtGold was mined"));
            mockPresenter.Verify(x => x.WriteLine($"{goldAmount} units of Gold was mined"));
            mockPresenter.Verify(x => x.WriteLine($"{silverAmount} units of Silver was mined"));
            mockPresenter.Verify(x => x.WriteLine($"{mithrilAmount} units of Mithril was mined"));

            mockPresenter.Verify(x => x.WriteLine($"Guild earned {se.simulationState._guildBankAccount} units of untaxed money"));
            mockPresenter.Verify(x => x.WriteLine($"Bank collected {se.simulationState._taxBankAccount} units of money in taxes"));

            mockPresenter.Verify(x => x.WriteLine($"Canteen served {se.simulationState._servedFoodRations} food rations"));

            Assert.IsTrue(se.simulationState._currentDay == 29);
            Assert.IsTrue(se.simulationState._allDwarves.Count() == 10);
            Assert.IsTrue(se.simulationState._allExtractedMinerals.Count == 300);
            Assert.IsTrue(se.simulationState._allExtractedMinerals.All(x => x == E_Minerals.Mithril));
            Assert.IsTrue(se.simulationState._guildBankAccount == 1500);
            Assert.IsTrue(se.simulationState._allDwarves.All(x => x._backpack.Count == 0));
            Assert.IsTrue(se.simulationState._servedFoodRations == 300);
            Assert.IsTrue(se.simulationState._allDwarves.All(x => x._bankAccount._overallIncome == 173.1m));
            Assert.IsTrue(se.simulationState._taxBankAccount == 1035m);
            Assert.AreEqual(1731m, se.simulationState._boughtProducts[E_MarketPlace_Products.Alcohol]);
        }

        [Test]
        public void T09E2ETestWithSuiciderWhoDestroysOneSchaftAt1stDay()
        {
            //given
            typeMock.Setup(x => x.GetRandomDwarfType()).Returns(E_DwarfType.Single);
            mineMock.Setup(x => x.RandomWorkIteration()).Returns(1);
            birthMock.Setup(x => x.TryBirth()).Returns(false);
            mineMock.Setup(x => x.GenerateRadnomFromRange()).Returns(1);
            guildMock.Setup(x => x.SetMithrilValue()).Returns(20);

            //when
            var se = new SimulationEngine(30, typeMock.Object, birthMock.Object, mineMock.Object, guildMock.Object, mockPresenter.Object);
            se.simulationState._allDwarves.Add(DwarfFactory.CreateSingleDwarf(E_DwarfType.Sabouter));
            se.Start();
            var mithrilAmount = se.simulationState._allExtractedMinerals.Count(z => z == E_Minerals.Mithril);
            var dirtGoldAmount = se.simulationState._allExtractedMinerals.Count(z => z == E_Minerals.DritGold);
            var goldAmount = se.simulationState._allExtractedMinerals.Count(z => z == E_Minerals.Gold);
            var silverAmount = se.simulationState._allExtractedMinerals.Count(z => z == E_Minerals.Silver);

            //then
            foreach (var dwarf in se.simulationState._allDwarves)
            {
                mockPresenter.Verify(x => x.WriteLine($"Dwarf: {dwarf.ToString()} was born"));
                foreach (var backpackItem in dwarf._backpack)
                {
                    mockPresenter.Verify(x => x.WriteLine($"{dwarf.ToString()} mined {backpackItem} of value"));
                }
            }

            for (int i = 0; i < se.simulationState._currentDay; i++)
            {
                mockPresenter.Verify(x => x.WriteLine($"Day: {i + 1}"));
            }

            mockPresenter.Verify(x => x.WriteLine($"During simulation {se.simulationState._numberOfBirths} dwarves was born"));
            mockPresenter.Verify(x => x.WriteLine($"During simulation died {se.simulationState._numberOfDeadDwarves} dwarves"));

            mockPresenter.Verify(x => x.WriteLine($"Marketplace statistics:"));
            mockPresenter.Verify(x => x.WriteLine($"{se.simulationState._boughtProducts[E_MarketPlace_Products.Alcohol]} units of alcohol was bought"));
            mockPresenter.Verify(x => x.WriteLine($"{se.simulationState._boughtProducts[E_MarketPlace_Products.Food]} units of food was bought"));

            mockPresenter.Verify(x => x.WriteLine($"Mine statistics:"));

            mockPresenter.Verify(x => x.WriteLine($"{dirtGoldAmount} units of DirtGold was mined"));
            mockPresenter.Verify(x => x.WriteLine($"{goldAmount} units of Gold was mined"));
            mockPresenter.Verify(x => x.WriteLine($"{silverAmount} units of Silver was mined"));
            mockPresenter.Verify(x => x.WriteLine($"{mithrilAmount} units of Mithril was mined"));

            mockPresenter.Verify(x => x.WriteLine($"Guild earned {se.simulationState._guildBankAccount} units of untaxed money"));
            mockPresenter.Verify(x => x.WriteLine($"Bank collected {se.simulationState._taxBankAccount} units of money in taxes"));

            mockPresenter.Verify(x => x.WriteLine($"Canteen served {se.simulationState._servedFoodRations} food rations"));

            Assert.IsTrue(se.simulationState._currentDay == 29);
            Assert.IsTrue(se.simulationState._allDwarves.Count() == 6);
            Assert.IsTrue(se.simulationState._allExtractedMinerals.Count == 180);
            Assert.IsTrue(se.simulationState._allExtractedMinerals.All(x => x == E_Minerals.Mithril));
            Assert.IsTrue(se.simulationState._guildBankAccount == 900);
            Assert.IsTrue(se.simulationState._allDwarves.All(x => x._backpack.Count == 0));
            Assert.IsTrue(se.simulationState._servedFoodRations == 180);
            Assert.IsTrue(se.simulationState._allDwarves.All(x => x._bankAccount._overallIncome == 173.1m));
            Assert.IsTrue(se.simulationState._taxBankAccount == 621m);
            Assert.AreEqual(1038.6m, se.simulationState._boughtProducts[E_MarketPlace_Products.Alcohol]);
        }
    }
}
