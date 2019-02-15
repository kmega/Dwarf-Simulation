﻿using DwarfLifeSimulation.Dwarves;
using DwarfLifeSimulation.Dwarves.Interfaces;
using DwarfLifeSimulation.Dwarves.WorkStrategies;
using DwarfLifeSimulation.Enums;
using DwarfLifeSimulation.Locations.Guilds;
using DwarfLifeSimulation.Locations.Mines;
using DwarfLifeSimulation.Randomizer.HitsRandomizer;
using DwarfLifeSimulation.Randomizer.MineralTypeRandomizer;
using DwarfLifeSimulation.Randomizer.MineralValueRandomizer;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace DwarfLifeSimulationsTests.GuildTests
{
    internal class GuildTests
    {
        private Guild guild;
        private Mock<IMineralValueRandomizer> mineralValueMock;
        [SetUp]
        public void Setup()
        {
            mineralValueMock = new Mock<IMineralValueRandomizer>();
            mineralValueMock.Setup(m => m.ExchangeMineralToValue(MineralType.Gold)).Returns(15);            
        }
        
        [Test]
        public void T100_ShouldReturn45When3GoldInBackpack()
        {
            //given
            guild = new Guild(null, mineralValueMock.Object);
            Dictionary<MineralType, int> backpack = new Dictionary<MineralType, int>();
            backpack.Add(MineralType.Gold, 3);
            //when
            var actual = guild.GetMineralOverallValue(backpack);
            //then
            Assert.IsTrue(actual == 45.0m);
        }
    }
}
