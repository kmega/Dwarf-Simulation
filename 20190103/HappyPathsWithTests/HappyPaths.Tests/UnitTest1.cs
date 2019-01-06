using Microsoft.VisualStudio.TestTools.UnitTesting;
using HappyPathsWithTests;

namespace HappyPaths.Tests
{
    [TestClass]
    public class UnitTestsForTask1
    {
        [TestMethod]
        public void TestTask1()
        {
            //given
            string path = @"C:\Users\Piotr\Desktop\GitLab\primary\20190103\HappyPathsWithTests\cybermagic\karty-postaci\1807-fryderyk-komciur.md";
            int expectedTime = 23;
            string expectedName = "Fryderyk Komciur";

            //when
            int resultTime = new Methods().GetTime(path);
            string resultName = new Methods().GetName(path);

            //then
            Assert.AreEqual(expectedTime, resultTime);
            Assert.AreEqual(expectedName, resultName);
        }
    }

    [TestClass]
    public class UnitTestsForTask2
    {
        [TestMethod]
        public void TestTask2()
        {
            //given
            string path = @"C:\Users\Piotr\Desktop\GitLab\primary\20190103\HappyPathsWithTests\cybermagic\karty-postaci";
            int expectedTime = 542;

            //when
            int resultTime = new Methods().GetSummaryTime(path);

            //then
            Assert.AreEqual(expectedTime, resultTime);
        }
    }

}
