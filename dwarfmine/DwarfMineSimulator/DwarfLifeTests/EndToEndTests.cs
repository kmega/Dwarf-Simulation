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
        [Test]
        public void EndToEndSimulation()
        {
            // given
            var lifeCycle = new LifeCycle();
            lifeCycle.LifeCycleState.Hospital.BornDwarfes(10, 
            DwarfTypes.Father | DwarfTypes.Single | DwarfTypes.Sluggard);
            var bornedDwarfs = lifeCycle.LifeCycleState.Hospital.BornedDwarfs.ToArray();
            var initialyBornedDwarfs = lifeCycle.LifeCycleState.Dwarfs.Count;

            // then
            lifeCycle.Begin();

            // then
            Assert.AreEqual(initialyBornedDwarfs, 10);
            Assert.IsFalse(bornedDwarfs.Any(dwarf => dwarf.DwarfType.Equals(DwarfTypes.Saboteur)));
            Assert.IsTrue(lifeCycle.LifeCycleState.Dwarfs.Count >= 10);

        }
    }
}