using System;
using BattleshipsWar;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BattleshipWarTest
{
    [TestClass]
    public class InputParserTest
    {
        [TestMethod]
        public void ShouldReturn1and5WhenInputIsB6()
        {
            //Given 
            string coords = "B6";
            int[] expected = new int[] { 1, 5 };

            //When
            InputParser parser = new InputParser();
            int[] result = parser.ChangeCordsToIndexes(coords);

            //Then
            Assert.AreEqual(expected[0], result[0]);
            Assert.AreEqual(expected[1], result[1]);
        }
        [TestMethod]
        public void ShouldReturn9and7WhenInputIsJ8()
        {
            //Given 
            string coords = "J8";
            int[] expected = new int[] { 9, 7 };

            //When
            InputParser parser = new InputParser();
            int[] result = parser.ChangeCordsToIndexes(coords);

            //Then
            Assert.AreEqual(expected[0], result[0]);
            Assert.AreEqual(expected[1], result[1]);
        }
        [TestMethod]
        public void ShouldReturn9and9WhenInputIsJ10()
        {
            //Given 
            string coords = "J10";
            int[] expected = new int[] { 9, 9 };

            //When
            InputParser parser = new InputParser();
            int[] result = parser.ChangeCordsToIndexes(coords);

            //Then
            Assert.AreEqual(expected[0], result[0]);
            Assert.AreEqual(expected[1], result[1]);
        }
        //[ExpectedException(typeof(NotImplementedException))]
        //[TestMethod]
        //public void ShouldThrowExceptionWhenStringIsLongerThan3()
        //{
        //    //Given 
        //    string coords = "JB10";           
        //    //When
        //    InputParser parser = new InputParser();
        //    int[] result = parser.ChangeCordsToIndexes(coords);
        //}
        //[ExpectedException(typeof(NotImplementedException))]
        //[TestMethod]
        //public void ShouldThrowExceptionWhenStringIsEmpty()
        //{
        //    //Given 
        //    string coords = "";
        //    //When
        //    InputParser parser = new InputParser();
        //    int[] result = parser.ChangeCordsToIndexes(coords);
        //}
    }
}
