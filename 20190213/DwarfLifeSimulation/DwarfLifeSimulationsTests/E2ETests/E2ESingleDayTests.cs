using NUnit.Framework;
using Moq;
using DwarfLifeSimulation.Randomizer.DwarfNameRandomizer;
using DwarfLifeSimulation.Randomizer.DwarfTypeRandomizer;
using DwarfLifeSimulation.Enums;
using DwarfLifeSimulation.Locations.Hospitals;
using DwarfLifeSimulation.Randomizer.IsDwarfBornRandomizer;
using DwarfLifeSimulation.Locations.Mines;
using DwarfLifeSimulation.Locations.Guilds;
using DwarfLifeSimulation.Locations.Canteens;
using DwarfLifeSimulation.Locations.Shops;
using DwarfLifeSimulation.Locations.Graveyards;
using DwarfLifeSimulation.ApplicationLogic;
using DwarfLifeSimulation.Randomizer.HitsRandomizer;
using DwarfLifeSimulation.Randomizer.MineralTypeRandomizer;
using DwarfLifeSimulation.Randomizer.MineralValueRandomizer;
using System.Collections.Generic;
using DwarfLifeSimulationsTests.E2ETests;
using DwarfLifeSimulation.Locations.Banks;

namespace DwarfLifeSimulationsTests
{
    internal class E2ESingleDayTests
    {
        public class BankMock : Bank
        {
            public static void ResetInstance()
            {
                instance = null;
            }
        }
        #region Mocks
        private Mock<IIsDwarfBornRandomizer> isBornMock;
        private Mock<IDwarfTypeRandomizer> dwarfTypeMock;
        private Mock<IHitsRandomizer> timesToDigMock;
        private Mock<IMineralTypeRandomizer> mineralTypeMock;
        private Mock<IMineralValueRandomizer> mineralValueMock;
        #endregion
        #region Locations
        private Hospital hospital;
        private Mine mine;
        private Guild guild;
        private Canteen canteen;
        private Shop shop;
        private Graveyard graveyard;
        #endregion
        private SimulationState simulationState;
        [SetUp]
        public void Setup()
        {
            graveyard = new Graveyard();
            canteen = new Canteen();
            isBornMock = new Mock<IIsDwarfBornRandomizer>();
            dwarfTypeMock = new Mock<IDwarfTypeRandomizer>();
            timesToDigMock = new Mock<IHitsRandomizer>();
            mineralTypeMock = new Mock<IMineralTypeRandomizer>();
            mineralValueMock = new Mock<IMineralValueRandomizer>();
            simulationState = new SimulationState();
        }

        private void LocationsSetup()
        {
            isBornMock.Setup(h => h.IsDwarfBorn(100)).Returns(false);
            dwarfTypeMock.Setup(t => t.GiveMeDwarfType(false)).Returns(DwarfType.Father);
            hospital = new Hospital(isBornMock.Object, dwarfTypeMock.Object);

            timesToDigMock.Setup(t => t.HowManyHits()).Returns(2);
            simulationState.turn = 2;
           

            mineralTypeMock.Setup(m => m.WhatHaveBeenDig()).Returns(MineralType.Silver);
            List<Shaft> shafts = new List<Shaft>()
            {
                new Shaft(mineralTypeMock.Object),
                new Shaft(mineralTypeMock.Object)
            };
            mine = new Mine(shafts);

            mineralValueMock.Setup(v => v.ExchangeMineralToValue(MineralType.Silver)).Returns(10);
            guild = new Guild(mineralValueMock.Object);

            shop = new Shop();
        }
        private void SetDwarves(int count, DwarfType dwarfType)
        {
            simulationState.dwarves.AddRange(
               new FakeDwarves().CreateDwarves(count,dwarfType, timesToDigMock.Object));
        }

        [Test]
        public void T100_SingleDaySimulationWithoutSuicideDwarvesAndNoNewBirths()
        {
            BankMock.ResetInstance();
            //given            
            //all dwarves are Fathers
            SetDwarves(10, DwarfType.Father);
            //all dig twice 
            //all dig silver worth 10 each
            LocationsSetup();
            SimulationEngine simulationEngine = new SimulationEngine(simulationState);
            //when
            simulationEngine.SimulateDay(hospital, mine, guild, canteen, shop, graveyard);
            //then
            foreach(var dwarf in simulationState.dwarves)
            {
                int i = 1;
                Assert.IsTrue(dwarf._hasWorked == true);
                Assert.AreEqual(Bank.Instance.GetOverallAccountMoney(i),8.0m);
                i++;
            }
            Assert.AreEqual(shop._shopState[ProductType.Food], 80);
            Assert.AreEqual(guild.GetSummary(MineralType.Silver), "We sold 20 in value of 200");
            Assert.AreEqual(graveyard.DeadDwarvesAmount, 0);
            Assert.AreEqual(canteen.GetAmountOfRations(), 190);
        }
        [Test]
        public void T101_SingleDaySimulationWith1SuicideDwarfAndNoNewBirths()
        {
            BankMock.ResetInstance();
            //given            
            //9 dwarves fathers, one suicide
            SetDwarves(9, DwarfType.Father);
            SetDwarves(1, DwarfType.Suicide);
            //all dig twice 
            //all dig silver worth 10 each
            LocationsSetup();
            SimulationEngine simulationEngine = new SimulationEngine(simulationState);
            //when
            simulationEngine.SimulateDay(hospital, mine, guild, canteen, shop, graveyard);
            //then
            foreach (var dwarf in simulationState.dwarves)
            {
                int i = 1;
                Assert.IsTrue(dwarf._hasWorked == true);
                Assert.AreEqual(Bank.Instance.GetOverallAccountMoney(i), 8.0m);
                i++;
            }
            Assert.AreEqual(shop._shopState[ProductType.Food], 40);
            Assert.AreEqual(guild.GetSummary(MineralType.Silver), "We sold 10 in value of 100");
            Assert.AreEqual(graveyard.DeadDwarvesAmount, 5);
            Assert.AreEqual(canteen.GetAmountOfRations(), 195);
        }
    }
}
