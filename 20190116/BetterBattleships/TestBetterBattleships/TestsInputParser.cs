using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BetterBattleships;

namespace TestBetterBattleships
{
    [TestClass]
    public class TestsInputParser
    {
        [TestMethod]
        public void ReturnCorrectIntArrayWithStringUppercaseInputFromGetCoordinatesToSetShip()
        {
            //given
            IInput inputParser = new InputParser();

            //when
            int[] resultArray = inputParser.ParseCorrectnessOfInputCoordsFromKeyboard(true, "B6");

            //then
            Assert.AreEqual(1, resultArray[0]);
            Assert.AreEqual(5, resultArray[1]);
        }

        [TestMethod]
        public void ReturnCorrectIntArrayWithStringLowercaseInputFromGetCoordinatesToSetShip()
        {
            //given
            IInput inputParser = new InputParser();

            //when
            int[] resultArray = inputParser.ParseCorrectnessOfInputCoordsFromKeyboard(true, "a6");

            //then
            Assert.AreEqual(0, resultArray[0]);
            Assert.AreEqual(5, resultArray[1]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ThrowsNewExceptionWhenInputStringIsInIncorrect()
        {
            //given
            IInput inputParser = new InputParser();

            //when
            int[] resultArray = inputParser.ParseCorrectnessOfInputCoordsFromKeyboard(true, "m6");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ThrowsNewExceptionWhenInputStringIsInIncorrectNumberPartOfString()
        {
            //given
            IInput inputParser = new InputParser();

            //when
            int[] resultArray = inputParser.ParseCorrectnessOfInputCoordsFromKeyboard(true, "b11");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ThrowsNewExceptionWhenInputStringIsInIncorrectBothValuesAreLetters()
        {
            //given
            IInput inputParser = new InputParser();

            //when
            int[] resultArray = inputParser.ParseCorrectnessOfInputCoordsFromKeyboard(true, "bb");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ThrowsNewExceptionWhenInputStringIsInIncorrectBothValuesAreNumbers()
        {
            //given
            IInput inputParser = new InputParser();

            //when
            int[] resultArray = inputParser.ParseCorrectnessOfInputCoordsFromKeyboard(true, "33");
        }
    }
}
