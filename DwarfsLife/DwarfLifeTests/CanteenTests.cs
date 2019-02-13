using NUnit.Framework;
using System;
using System.Collections.Generic;
using DwarfLife.Buildings.Canteen;
using DwarfLife.Dwarfs;
using DwarfLife.Enums;
using System.Linq;

namespace DwarfLife.Tests
{
    [TestFixture()]
    public class CanteenTests
    {
        [TestCase(1)]
        [TestCase(10)]
        [TestCase(100)]
        [TestCase(1000)]
        public void ShouldCreateCanteenWithRationsAmoundOf(int rations)
        {
            // when
            var canteen = new Canteen(rations);

            // then
            Assert.IsTrue(canteen.Rations == rations);
        }
    }
}