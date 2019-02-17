using System.Collections.Generic;
using System.Linq;
using Mine2._0;
using Moq;
using NUnit.Framework;

namespace MIne2._0Tests
{
    [TestFixture]
    public class T_KaboomWorkingStrategy
    {
        private Mock<IRandomizer> randomizer;
        [SetUp]
        public void Setup()
        {
            randomizer = new Mock<IRandomizer>();
        }

        [Test]
        public void DestroysSchaftAndKillEverybodyAndZeroesTheirsBackpacks()
        {
            //given
            randomizer.Setup(x => x.RandomWorkIteration()).Returns(1);
            randomizer.Setup(x => x.GenerateRadnomFromRange()).Returns(1);

            var schaft = new Schaft();
            var workers = new List<IWork>()
            {
                new Dwarf(E_DwarfType.Father, new NormalWorkingStrategy(), null),
                new Dwarf(E_DwarfType.Father, new KaboomWorkingStrategy(), null),
                new Dwarf(E_DwarfType.Father, new NormalWorkingStrategy(), null)
            };

            schaft.SchaftWorkers = workers;

            //when
            foreach (var worker in schaft.SchaftWorkers)
            {
                worker.Work(schaft, randomizer.Object);
            }

            //then
            Assert.IsTrue(schaft.SchaftStatus == E_SchaftStatus.Broken);
            Assert.IsTrue(workers.All(x => x.GetIsAliveStatus() == false));
            Assert.IsTrue(workers.All(x => x.GetBackpackQunatity() == 0));
            Assert.IsTrue(schaft.SchaftStats.Count == 0);
        }
    }
}
