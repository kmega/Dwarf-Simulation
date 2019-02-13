using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using DwarfLife.LifeCycles;
using DwarfLife.Enums;
using System;
using DwarfLife.Dwarfs;

namespace DwarfLife.Tests
{
    [TestFixture()]
    public class EndToEndTests
    {
        LifeCycle lifeCycle;

        [SetUp]
        public void Init()
        {
            lifeCycle = new LifeCycle();
            lifeCycle.LifeCycleState.Hospital.BornDwarfes(10,
            DwarfTypes.Father | DwarfTypes.Single | DwarfTypes.Sluggard);
        }

        [Test]
        public void InitialiseLifeCycleWith10NonSaboteurDwarf()
        {
            // given
            var bornedDwarfs = lifeCycle.LifeCycleState.Hospital.Dwarfs.ToArray();
            var initialyBornedDwarfs = lifeCycle.LifeCycleState.Dwarfs.Count;

            // then
            lifeCycle.Begin(false);

            // then
            Assert.AreEqual(initialyBornedDwarfs, 10);
            Assert.IsFalse(bornedDwarfs.Any(dwarf => dwarf.DwarfType.Equals(DwarfTypes.Saboteur)));
            Assert.IsTrue(lifeCycle.LifeCycleState.Hospital.BornedDwarfs >= 10);
        }

        [Test]
        public void ThereWereDeadDwarfAndGraveyardCollectedBodies()
        {
            // given

            // then
            lifeCycle.Begin();

            // then
            Assert.IsTrue(lifeCycle.LifeCycleState.Graveyard.DeadDwarfs
                  .Any(dwarf => dwarf.DwarfType.Equals(DwarfTypes.Saboteur)));
            Assert.IsTrue(lifeCycle.LifeCycleState.Graveyard.DeadDwarfs.Count > 0);
        }

        [Test]
        public void GuildShouldCollectTaxes()
        {
            // given

            // then
            lifeCycle.Begin();

            // then
            Assert.IsTrue(lifeCycle.LifeCycleState.Guild.CollectedTaxes > 0);
        }

        [Test]
        public void CanteenShouldFeedDwarfs()
        {
            // given

            // then
            lifeCycle.Begin();

            // then
            Assert.IsTrue(lifeCycle.LifeCycleState.Canteen.RationsEaten > 0);
        }
    }
}