using Microsoft.VisualStudio.TestTools.UnitTesting;
using HappyPathsWithTests;

namespace HappyPaths.Tests
{
    [TestClass]
    public class UnitTestsForTask1
    {
        [TestMethod]
        public void TestProperTimeForKomciurInTask1()
        {
            //given
            string path = @"C:\Users\Piotr\Desktop\GitLab\primary\20190103\HappyPathsWithTests\cybermagic\karty-postaci\1807-fryderyk-komciur.md";
            //string path = @"/Users/piotr/Desktop/Git/primary/20190103/HappyPathsWithTests/cybermagic/karty-postaci/1807-fryderyk-komciur.md"; //mac
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
        public void TestProperSummaryTimeForTask2()
        {
            //given
            string path = @"C:\Users\Piotr\Desktop\GitLab\primary\20190103\HappyPathsWithTests\cybermagic\karty-postaci";
            int expectedTime = 542;

            //when
            int resultTime = new Methods().GetSummaryTime(path);

            //then
            Assert.AreEqual(expectedTime, resultTime);
        }

        [TestMethod]
        public void TestProperSaveToFile()
        {
            //given
            string path = @"C:\Users\Piotr\Desktop\GitLab\primary\20190103\HappyPathsWithTests\Results\Result2.txt";
            string properValue = "Wszystkie postacie do tej pory budowane by³y 9 godzin 2 minut";
            bool expectedResult = true;

            //when
            string openedSavedFile = new FileOps().ReadSingleFile(path).Replace("\r\n", "");

            bool resultIdentity = false;
            if (openedSavedFile.Equals(properValue))
                resultIdentity = true;

            //then
            Assert.AreEqual(expectedResult, resultIdentity);
        }
    }

}
