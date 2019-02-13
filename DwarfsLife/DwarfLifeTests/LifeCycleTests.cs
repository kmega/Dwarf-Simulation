using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using DwarfLife.LifeCycles;
using DwarfLife.Enums;
using System;

namespace DwarfLife.Tests
{
    [TestFixture()]
    public class LifeCycleTests
    {
        [TestCase(1)]
        [TestCase(15)]
        [TestCase(30)]
        [TestCase(60)]
        [TestCase(90)]
        [TestCase(120)]
        [TestCase(240)]
        [TestCase(365)]
        public void ShouldMaxDaysEqualsTo(int maxDays)
        {
            // given
            var lifeCycle = new LifeCycle(maxDays);

            // then
            Assert.AreEqual(lifeCycle.LifeCycleState.MaxDays, maxDays);
        }

        [TestCase(1)]
        [TestCase(15)]
        [TestCase(30)]
        [TestCase(60)]
        [TestCase(90)]
        [TestCase(120)]
        [TestCase(240)]
        [TestCase(365)]
        public void ShouldEndAfter(int expetedDaysToPass)
        {
            // given
            //var hospital = new Hospital();
            //List<IDwarf> dwarfes = hospital.BornDwarfes(10);
            var lifeCycle = new LifeCycle(expetedDaysToPass);

            // when
            lifeCycle.LifeCycleState.Hospital.BornDwarfes(10);
            lifeCycle.Begin(true);

            // then
            int givenDaysPassed = lifeCycle.LifeCycleState.DaysPassed;
            Assert.AreEqual(givenDaysPassed, expetedDaysToPass);
        }

        [Test]
        public void ShouldEndBecauseThereIsNoDwarfs()
        {
            // given
            var lifeCycle = new LifeCycle();

            // when
            lifeCycle.LifeCycleState.Hospital.BornDwarfes(10);
            lifeCycle.LifeCycleState.Dwarfs.Clear();
            lifeCycle.Begin();

            // then
            int givenDaysPassed = lifeCycle.LifeCycleState.DaysPassed;
            Assert.IsTrue(lifeCycle.LifeCycleState.Dwarfs.Count.Equals(0));
        }
    }
}