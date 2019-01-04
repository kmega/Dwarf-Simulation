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


            (List<string[]> alphaSortedOrigin, List<string[]> nonSortedOrigin) = new FileOps().
                                                                                    GetArrayFromList(origin);
            bool expected = true;

            bool result = new FileOps().IsSorted(alphaSortedOrigin);

        }
    }
}
