using NUnit.Framework;
using System;
using barcos;
using barcos.Enums;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void BoardHas100Fields()
        {
            //Given
            Board testedBoard = new Board();
            int boardLength = testedBoard.Fields.Length;

            Assert.AreEqual(boardLength, 100);
        }
    }
}