using DwarfLifeSimulation.Dwarves;
using DwarfLifeSimulation.Dwarves.Interfaces;
using DwarfLifeSimulation.Dwarves.WorkStrategies;
using DwarfLifeSimulation.Enums;
using DwarfLifeSimulation.Locations.Mines;
using DwarfLifeSimulation.Randomizer.HitsRandomizer;
using DwarfLifeSimulation.Randomizer.MineralTypeRandomizer;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace DwarfLifeSimulationsTests.MineTests
{
    internal class MineTests
    {
        Mine mine;
        List<Shaft> shafts;
        private Mock<IHitsRandomizer> hitRandomizer;
        private Mock<IMineralTypeRandomizer> mineralRandomizer;
        [SetUp]
        public void Setup()
        {
            mine = new Mine();
            shafts = new List<Shaft>();
            hitRandomizer = new Mock<IHitsRandomizer>();
            mineralRandomizer = new Mock<IMineralTypeRandomizer>();
        }

        [Test]
        public void T100_ShouldCreate2ShiftGroupsWith5MembersEachWhen10WorkersWentToMine()
        {
            //given
            List<IWork> workers = new FakeWorkersFactory().Create(10);
            //when
            var shiftGroups = mine.DivideIntoGroups(workers);
            //then   
            foreach(var group in shiftGroups)
            {
                Assert.IsTrue(group.Members.Count == 5);
            }
            Assert.IsTrue(!workers.Any());
        }
        [Test]
        public void T101_ShouldCreate3ShiftGroupsWithWhen13WorkersWentToMine()
        {
            //given
            List<IWork> workers = new FakeWorkersFactory().Create(13);
            //when
            var shiftGroups = mine.DivideIntoGroups(workers);
            //then   
            for(int i = 0; i< shiftGroups.Count - 1; i++)
            {
                Assert.IsTrue(shiftGroups[i].Members.Count == 5);
            }
            Assert.IsTrue(shiftGroups.Last().Members.Count == 3);
            Assert.IsTrue(!workers.Any());
        }
        [Test]
        public void T102_ShouldReturnEmptyShaftWhenThereIsAny()
        {
            //given
            shafts.Add(new Shaft());
            shafts.Add(new Shaft());
            //when
            var emptyShaft = mine.FindEmptyShaft(shafts);
            //then   
            Assert.IsTrue(emptyShaft.IsOccupied == false);
            Assert.IsTrue(emptyShaft.ShaftStatus == ShaftStatus.Working);
        }
        [Test]
        public void T103_ShouldReturnNullWhenNoWorkingAndEmptyShaft()
        {
            //given
            shafts.Add(new Shaft());
            shafts.Add(new Shaft());
            shafts[0].ShaftStatus = ShaftStatus.Destroyed;
            shafts[1].ShaftStatus = ShaftStatus.Destroyed;
            //when
            var emptyShaft = mine.FindEmptyShaft(shafts);
            //then   
            Assert.IsTrue(emptyShaft == null);
        }
        [Test]
        public void T104_SingleWorkerShouldDigInShaftAndGet2Gold()
        {
            //given
            mineralRandomizer.Setup(m => m.WhatHaveBeenDig()).Returns(MineralType.Gold);
            List<Shaft> shafts = new List<Shaft>()
            {
                new Shaft(mineralRandomizer.Object)
            };
            mine = new Mine(shafts);
            hitRandomizer.Setup(h => h.HowManyHits()).Returns(2);
            var dwarf = new Dwarf("", DwarfType.Father, 
                new StandardWorkStrategy(hitRandomizer.Object), null);
            var workers = new List<IWork>()
            {
                dwarf
            };
            //when
            mine.Work(workers);
            //then   
            Assert.IsTrue(dwarf._hasWorked == true);
            var backpack = dwarf.EmptyBackpackContent();
            Assert.IsTrue(backpack[MineralType.Gold] == 2);
        }
    }
}
