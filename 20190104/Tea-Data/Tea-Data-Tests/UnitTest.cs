using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tea_Data;

namespace Tea_Data_Tests
{
    [TestClass]
    public class UnitTest
    {
        private string[] GetTeaData()
        {
            FileIO read = new FileIO();
            string[] teaData = read.TeaData();
            return teaData;
        }

        private string[] SplitToArray(string modifiedRecords)
        {
            return modifiedRecords.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
        }

        [TestMethod]
        public void ShouldCheckForNumbers123456()
        {
            UserInput input = new UserInput();
            int number = 1;
            for (int i = 1; i == 6; i++, number++)
            {
                Assert.AreEqual(number, input.CheckInput(i.ToString(), ""));
            }
        }

        [TestMethod]
        public void ShouldReverseRecords()
        {
            string[] teaData = GetTeaData();
            ExecuteTask execute = new ExecuteTask();
            string modifiedRecords = execute.ReverseRecords(teaData);


            string[] reverseRecords = SplitToArray(modifiedRecords);
            int j = reverseRecords.Length - 2;


            for (int i = 0; i < teaData.Length; i++, j--)
            {
                Assert.AreEqual(teaData[i], reverseRecords[j]);
            }
        }

        [TestMethod]
        public void ShouldSortRecords()
        {
            string[] teaData = GetTeaData();
            ExecuteTask execute = new ExecuteTask();
            string modifiedRecords = execute.SortRecords(teaData);


            string[] sortedRecords = SplitToArray(modifiedRecords);


            Assert.Fail();
        }
    }
}
