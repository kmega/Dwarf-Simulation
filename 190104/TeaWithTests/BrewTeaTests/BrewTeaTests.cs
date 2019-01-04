using Microsoft.VisualStudio.TestTools.UnitTesting;
using BrewTea;

namespace BrewTeaTests
{
    [TestClass]
    public class BrewTeaTests
    {
        private readonly Task0ne _task01;
        private TaskOneContent _taskOne;

        public BrewTeaTests()
        {
            _task01 = new Task0ne();
        }

        [TestMethod]
        public void TestIsReadedContentHasReverseOrder()
        {
            _taskOne = new TaskOneContent();
            Assert.AreEqual(_task01.Run(), _taskOne.ResultList);
        }
    }
}
