using System.Collections.Generic;
using Mine2._0;
using NUnit.Framework;

namespace MIne2._0Tests
{
    [TestFixture]
    public class T_TeamSplitter
    {
        [Test]
        public void splits3()
        {
            //given
            var splitter = new TeamSplitter();

            List<IWork> workers = new List<IWork>(new Hospital().CreateInitialState(3));

            var result = new TeamSplitter().SplitWorkersIntoTeam(workers);
            //when

            //then
            Assert.IsTrue(workers.Count == 0);
            Assert.IsTrue(result.Count == 3);
        }

        [Test]
        public void splits7()
        {
            //given
            var splitter = new TeamSplitter();

            List<IWork> workers = new List<IWork>(new Hospital().CreateInitialState(7));

            var result = new TeamSplitter().SplitWorkersIntoTeam(workers);
            //when

            //then
            Assert.IsTrue(workers.Count == 2);
            Assert.IsTrue(result.Count == 5);
        }
    }
}
