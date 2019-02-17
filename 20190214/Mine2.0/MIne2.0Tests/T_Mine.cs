using System.Collections.Generic;
using System.Linq;
using Mine2._0;
using Moq;
using NUnit.Framework;

namespace MIne2._0Tests
{
    [TestFixture]
    public class T_Mine
    {
        private Mock<IRandomizer> mockIrandomizer;
        private Mock<IDwarfTypeRandomizer> mockDwarfRandomzier;
        private Mock<IDwarfTypeRandomizer> mockDwarfSabouter;
        private Mock<IOutputWriter> mockOutput;

        [SetUp]
        public void Setup()
        {
            mockIrandomizer = new Mock<IRandomizer>();
            mockDwarfRandomzier = new Mock<IDwarfTypeRandomizer>();
            mockDwarfSabouter = new Mock<IDwarfTypeRandomizer>();
            mockOutput = new Mock<IOutputWriter>();
        }

        [Test]
        public void PerformMiningAndEveryWorkerGets2MithrilsIntoBackpack()
        {
            //given
            mockIrandomizer.Setup(x => x.GenerateRadnomFromRange()).Returns(2);
            mockIrandomizer.Setup(x => x.RandomWorkIteration()).Returns(2);
            var mine = new Mine(mockIrandomizer.Object);

            //List<IWork> workers = new List<IWork>(new Hospital().CreateInitialState(7));
            List<IWork> workers = new List<IWork>
            {
                {DwarfFactory.CreateSingleDwarf(E_DwarfType.Father)},
                {DwarfFactory.CreateSingleDwarf(E_DwarfType.Father)},
                {DwarfFactory.CreateSingleDwarf(E_DwarfType.Father)},
                {DwarfFactory.CreateSingleDwarf(E_DwarfType.Father)},
                {DwarfFactory.CreateSingleDwarf(E_DwarfType.Father)},
                {DwarfFactory.CreateSingleDwarf(E_DwarfType.Father)},
                {DwarfFactory.CreateSingleDwarf(E_DwarfType.Father)},
            };

            mine.PerformMining(workers, mockOutput.Object);
            //when

            //then
            Assert.IsTrue(workers.Count == 7);
            Assert.IsTrue(mine._schafts[0].SchaftWorkers.Count == 0);
            Assert.IsTrue(mine._schafts[1].SchaftWorkers.Count == 0);
            Assert.IsTrue(workers.All(x => x.GetBackpackQunatity() == 2));
            Assert.IsTrue(workers.All(x => x.ShowBackpack().Count(z => z == E_Minerals.Mithril) == 2));
        }

        [Test]
        public void withMock()
        {
            //given
            mockIrandomizer.Setup(x => x.RandomWorkIteration()).Returns(1);
            mockIrandomizer.Setup(x => x.GenerateRadnomFromRange()).Returns(1);

            mockDwarfRandomzier.Setup(x => x.GetRandomDwarfType()).Returns(E_DwarfType.Father);

            var dwarfs = new Hospital(mockDwarfRandomzier.Object, new DwarthIsBrithRandomizer()).CreateInitialState(8);
            var mine = new Mine(mockIrandomizer.Object);

            var workers = new List<IWork>(dwarfs);

            //when
            mine.PerformMining(workers, mockOutput.Object);

            //then
            Assert.IsTrue(dwarfs.All(x => x._dwarfType == E_DwarfType.Father));
            Assert.IsTrue(dwarfs.All(x => x._backpack.Count == 1));
            Assert.IsTrue(dwarfs.All(x => x._backpack.Contains(E_Minerals.Mithril)));
        }

        [Test]
        public void PerformMiningWithOneSabouterAndKillsHisCooworkers()
        {
            //given
            mockIrandomizer.Setup(x => x.RandomWorkIteration()).Returns(1);
            mockIrandomizer.Setup(x => x.GenerateRadnomFromRange()).Returns(1);

            mockDwarfRandomzier.Setup(x => x.GetRandomDwarfType()).Returns(E_DwarfType.Father);

            mockDwarfSabouter.Setup(x => x.GetRandomDwarfType()).Returns(E_DwarfType.Sabouter);

            List<Dwarf> dwarfs = new List<Dwarf>();

            for (int i = 0; i < 8; i++)
            {
                if (i == 2)
                    dwarfs.Add(new Hospital(mockDwarfSabouter.Object, new DwarthIsBrithRandomizer()).CreateSingleRandomDwarf());
                else dwarfs.Add(new Hospital(mockDwarfRandomzier.Object, new DwarthIsBrithRandomizer()).CreateSingleRandomDwarf());
            }

            var mine = new Mine(mockIrandomizer.Object);
            var workers = new List<IWork>(dwarfs);

            //when
            mine.PerformMining(workers, mockOutput.Object);

            //then
            Assert.IsTrue(mine._schafts[0].SchaftStatus == E_SchaftStatus.Broken);
            Assert.IsTrue(dwarfs.Count(x => x._dwarfType== E_DwarfType.Father) == 7);
            Assert.IsTrue(dwarfs.Count(x => x._dwarfType == E_DwarfType.Father) == 7);
            Assert.IsTrue(dwarfs.Count(x => x._isAlive == false) == 5);
            Assert.IsTrue(dwarfs.Count(x => x._isAlive == true && x.ShowBackpack().Count(z => z == E_Minerals.Mithril) == 1) == 3);
            Assert.IsTrue(mine.Stats.Count == 3);
            Assert.IsTrue(mine.Stats.All(x => x == E_Minerals.Mithril));
        }
    }
}
