using BattleShips.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShipsTests
{
    public class InputValidationTests
    {
        [Test]
        [TestCase("C")]
        [TestCase("c")]
        [TestCase("d")]
        [TestCase("D")]
        [TestCase("c")]
        public void T01_ShouldReturnTrueWhenCorrectInputForShipType(string input)
        {
            //Then
            Assert.IsTrue(InputValidator.CheckShipType(input));
        }
        [Test]
        [TestCase("Cd")]
        public void T02_ShouldThrowExceptionWhenIncorrectInputForShipType(string input)
        {
            //Then
            string message = Assert.Throws<Exception>(
                () => InputValidator.CheckShipType(input)).Message;
            Assert.AreEqual("Incorrect ship type inserted. Please try again!", message);
        }
    }
}
