using NUnit.Framework;
using System.Collections.Generic;
using DwarfLife.LifeCycles;
using DwarfLife.Dwarfs;
using DwarfLife.Buildings.Hospital;
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
            Assert.AreEqual(lifeCycle.MaxDays(), maxDays);
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
            var hospital = new Hospital();
            List<IDwarf> dwarfes = hospital.BornDwarfes(10);
            var lifeCycle = new LifeCycle(dwarfes, expetedDaysToPass);

            // when
            lifeCycle.Begin();

            // then
            int givenDaysPassed = lifeCycle.LifeCycleState.DaysPassed;
            Assert.AreEqual(givenDaysPassed, expetedDaysToPass);
        }
    }
}