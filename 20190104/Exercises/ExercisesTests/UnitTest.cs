using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercises
{
    [TestClass]
    public class UnitTest
    {
        public string[] linesOfText = File.ReadAllLines(@".../.../.../.../tea-data.txt");
        StartTasks start = new StartTasks();

        [TestMethod]
        public void ShouldReverseRecords()
        {
            start.ReverseRecords(linesOfText);
            string[] reversedRecord = File.ReadAllLines(@".../.../.../.../result-1.txt");
            for (int i = 0; i < linesOfText.Length; i++)
            {
                Assert.AreNotEqual(reversedRecord[i], linesOfText[i]);
            }
        }
    }
}
