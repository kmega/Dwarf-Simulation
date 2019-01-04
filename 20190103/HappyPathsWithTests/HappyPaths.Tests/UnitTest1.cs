using Microsoft.VisualStudio.TestTools.UnitTesting;
using HappyPathsWithTests;

namespace HappyPaths.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestTask1()
        {
            //given
            var Task = new Task1();
            string path = @"..\cybermagic\karty-postaci\1807-fryderyk-komciur.md";
            int expectedTime = 23;
            string expectedName = "Fryderyk Komciur";

            //when
            int resultTime = Task.GetTime(path);
            string resultName = Task.GetName(path);

            //then
            Assert.AreEqual(expectedTime, resultTime);
            Assert.AreEqual(expectedName, resultName);
        }

        [TestMethod]
        public void TestTask2()
        {
            //given
            var Task = new Task2();
            string path = @"C:..\cybermagic\karty-postaci";
            int expectedTime = 542;

            //when
            int resultTime = Task.GetTime(path);
            string resultName = Task.GetName(path);

            //then
            Assert.AreEqual(expectedTime, resultTime);
            Assert.AreEqual(expectedName, resultName);
        }
    }
}
