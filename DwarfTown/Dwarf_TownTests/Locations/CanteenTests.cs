using Dwarf_Town;
using Dwarf_Town.Locations;
using NUnit.Framework;
using System.Collections.Generic;

namespace Dwarf_TownTests.Locations
{
    [TestFixture]
    public class CanteenTests
    {
        [Test]
        public void ShouldSpendFoodRationsWhenDwarvesListGiven()
        {
            //given
            Canteen canteen = new Canteen(100);
            var dwarves = new List<Dwarf>();
        }
    }
}