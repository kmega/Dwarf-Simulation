using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RecruitmentTasksRetakeTests
{
    [TestClass]
    public class Step1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var origin = new FileOps().GetFile();
            var reversed = new Task1().ReverseArray(new FileOps().GetFile());

            bool expected = true;

            bool result = new Task1().IsReversed(origin, reversed);

            Assert.AreEqual(expected, result);
        }
    }

    [TestClass]
    public class Step2
    {
        [TestMethod]
        public void TestMethod1()
        {
            List<string> origin = new FileOps().GetFile();


            List<string[]> alphaSortedOrigin = new FileOps().GetSortedList(origin);
            bool expected = true;

            bool result = new FileOps().IsSorted(alphaSortedOrigin);
            //zobaczyc czy 2 pierwsze linjki na sztywno sa true sorted
        }
    }
}
