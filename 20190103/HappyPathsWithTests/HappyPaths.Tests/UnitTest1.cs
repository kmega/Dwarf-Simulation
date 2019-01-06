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
<<<<<<< HEAD
            string path = @"C:\Users\Piotr\Desktop\GitLab\primary\20190103\HappyPathsWithTests\cybermagic\karty-postaci\1807-fryderyk-komciur.md";
=======
            var Task = new Task1();
            string path = @"..\cybermagic\karty-postaci\1807-fryderyk-komciur.md";
            string path = @"/Users/piotr/Desktop/Git/primary/20190103/HappyPathsWithTests/cybermagic/karty-postaci/1807-fryderyk-komciur.md"; //mac
>>>>>>> de7c10059fcf880b4bc9adacb47518ea68f1f376
            int expectedTime = 23;
            string expectedName = "Fryderyk Komciur";

            //when
            int resultTime = new Methods().GetTime(path);
            string resultName = new Methods().GetName(path);

            //then
            Assert.AreEqual(expectedTime, resultTime);
            //Assert.AreEqual(expectedName, resultName);
        }
    }

<<<<<<< HEAD
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
=======
        //[TestMethod]
        //public void TestTask2()
        //{
        //    //given
        //    var Task = new Task2();
        //    string path = @"C:..\cybermagic\karty-postaci";
        //    int expectedTime = 542;

        //    //when
        //    int resultTime = Task.GetTime(path);
        //    string resultName = Task.GetName(path);

        //    //then
        //    Assert.AreEqual(expectedTime, resultTime);
        //    Assert.AreEqual(expectedName, resultName);
        //}
>>>>>>> de7c10059fcf880b4bc9adacb47518ea68f1f376
    }

}
