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
        [Test]
        [TestCase("u")]
        [TestCase("d")]
        [TestCase("l")]
        [TestCase("r")]
        [TestCase("D")]
        public void T03_ShouldReturnTrueWhenCorrectInputForShipDirection(string input)
        {
            //Then
            Assert.IsTrue(InputValidator.CheckDirection(input));
        }
        [Test]
        [TestCase("UD")]
        public void T04_ShouldThrowExceptionWhenIncorrectInputForShipDirection(string input)
        {
            //Then
            string message = Assert.Throws<Exception>(
                () => InputValidator.CheckDirection(input)).Message;
            Assert.AreEqual("Incorrect direction inserted, please try again!", message);
        }
        [Test]
        [TestCase("B5")]
        [TestCase("A1")]
        [TestCase("J10")]
        [TestCase("H7")]
        [TestCase("D6")]
        public void T05_ShouldReturnTrueWhenCorrectInputForShipStartingPosition(string input)
        {
            //Then
            Assert.IsTrue(InputValidator.CheckPosition(input));
        }
        [Test]
        [TestCase("A11")]
        [TestCase("J0")]
        [TestCase("ziemniaczki")]
        [TestCase("H11")]
        public void T06_ShouldThrowExceptionWhenIncorrectInputForShipDirection(string input)
        {
            //Then
            string message = Assert.Throws<Exception>(
                () => InputValidator.CheckPosition(input)).Message;
            Assert.AreEqual("Wrong position inserted, please try again!", message);
        }
        [Test]
        [TestCase("d")]
        public void T06_ShouldReturnTrueWhenChoosenShipAlreadyExists(string input)
        {
            //given
            Player player = new Player();
            player.Ships.Add(new FakeDestroyer("d"));
            //Then
            Assert.IsTrue(InputValidator.CheckIfChoosenShipAlreadyExists(input, player));
        }
    }
}
