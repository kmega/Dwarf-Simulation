using System.Collections.Generic;
using Mine2._0;
using NUnit.Framework;

namespace MIne2._0Tests
{
    [TestFixture]
    public class T_TeamSplitter
    {
        [Test]
        public void SplitsListOf3IntoOneWorkinglistAndBaselistIsEmpty()
        {
            //given
            List<IWork> workers = new List<IWork>(new Hospital().CreateInitialState(3));

            //when
            var splittedWorkers = new TeamSplitter().SplitWorkersIntoTeam(workers);

            //then
            Assert.IsTrue(workers.Count == 0);
            Assert.IsTrue(splittedWorkers.Count == 3);
        }

        [Test]
        public void SplitsListOf3IntoOneWorkinglistAndBaselistHasTwoAwaitingDwarves()
        {
            //given
            List<IWork> workers = new List<IWork>(new Hospital().CreateInitialState(7));

            //when
            var splittedWorkers = new TeamSplitter().SplitWorkersIntoTeam(workers);

            //then
            Assert.IsTrue(workers.Count == 2);
            Assert.IsTrue(splittedWorkers.Count == 5);
        }
    }
}
