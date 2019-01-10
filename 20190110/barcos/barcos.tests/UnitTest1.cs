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

        [Test]
        public void BoardHas100EmptyFields1()
        {
            //Given
            //Board testedBoard = new Board();
            //int boardLength = testedBoard.Fields.Length;
            //int boardFieldCounter = 0;



            //Assert.IsTrue(testedBoard.Fields[56] == FieldsStatus.empty);

            //while (boardFieldCounter < boardLength)
            //{
            //    Assert.AreEqual(
            //        testedBoard.Fields[boardFieldCounter], 
            //        FieldsStatus.empty);
            //    boardFieldCounter++;
            //}
        }
    }
}