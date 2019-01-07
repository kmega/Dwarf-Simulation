using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KomciurTests.TasksToDo;


namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TimeOfCreatingKomciur()
        {
            Tasks task_1 = new Tasks();

            int result = task_1.Task_1();

            Assert.AreEqual(23, result);
        }
    }
}
