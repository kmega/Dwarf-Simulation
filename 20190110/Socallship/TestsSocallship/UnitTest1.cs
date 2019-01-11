using Microsoft.VisualStudio.TestTools.UnitTesting;
using Socallship;
using System.Linq;

namespace TestsSocallship
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CreatesOnePlayerWithBoardGame()
        {
            //given
            string name = "XYZ";
            //when
            PlayerCreator player1 = new PlayerCreator(name);
            //then
            Assert.AreEqual(name, player1.GetName());
        }
    }
}
