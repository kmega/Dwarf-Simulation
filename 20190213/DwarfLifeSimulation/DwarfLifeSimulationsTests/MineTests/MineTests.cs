using DwarfLifeSimulation.ApplicationLogic;
using DwarfLifeSimulation.Dwarves.BuyStrategies;
using DwarfLifeSimulation.Dwarves.Interfaces;
using DwarfLifeSimulation.Dwarves.WorkStrategies;
using DwarfLifeSimulation.Enums;
using DwarfLifeSimulation.Locations.Hospitals;
using DwarfLifeSimulation.Locations.Mines;
using DwarfLifeSimulation.Randomizer.DwarfNameRandomizer;
using DwarfLifeSimulation.Randomizer.DwarfTypeRandomizer;
using DwarfLifeSimulation.Randomizer.IsDwarfBornRandomizer;
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
        [SetUp]
        public void Setup()
        {
            mine = new Mine();
            shafts = new List<Shaft>();
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
        public void T104_SingleWorkerShouldDigInShaft()
        {
            //given
            var workers = new FakeWorkersFactory().Create(1);
            //when
            mine.Work(workers);
            //then   
            Assert.IsTrue(workers[0]._hasWorked == true);
        }

    }
}
