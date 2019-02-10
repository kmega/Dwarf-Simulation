using NUnit.Framework;
using System;
using System.Collections.Generic;
using DwarfLife.Buildings.Graveyard;
using DwarfLife.Dwarfs;
using DwarfLife.Enums;
using System.Linq;

namespace DwarfLife.Tests
{
    [TestFixture()]
    public class GraveyardTests
    {
        [Test]
        public void ShouldTakeAllDeadDwarfsAndPutThemInGraveyard()
        {
            // given
            var graveyard = new Graveyard();
            var dwarfs = new List<IDwarf>()
                {   new DwarfFather(1),
                    new DwarfSingle(2),
                    new DwarfSluggard(3),
                    new DwarfSluggard(4),
                    new DwarfSaboteur(5)
                };

            // when
            dwarfs.Where(dwarf => dwarf.DwarfType == DwarfTypes.Sluggard)
            .ToList().ForEach(dead => dead.Alive = false);
            graveyard.BurryDeadDwarfs(dwarfs);

            // then
            Assert.IsTrue(dwarfs.All(dwarf => dwarf.Alive == true));
            Assert.IsTrue(graveyard.DeadDwarfs.All(dwarf => dwarf.Alive == false));
        }
    }
}