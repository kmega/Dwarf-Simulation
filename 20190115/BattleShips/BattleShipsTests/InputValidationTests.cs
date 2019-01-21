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
            Assert.AreEqual("Wprowadzono nieprawidłowy typ okrętu! Spróbuj ponownie!", message);
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
            Assert.AreEqual("Wprowadzono nieprawidłowy kierunek! Spróbuj ponownie!", message);
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
            Assert.AreEqual("Wprowadzono nieprawidłową pozycję! Spróbuj ponownie!", message);
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
        [Test]
        [TestCase("d")]
        public void T07_ShouldReturnFalseWhenChoosenShipDoesNotYetExist(string input)
        {
            //given
            Player player = new Player();
            //Then
            Assert.IsFalse(InputValidator.CheckIfChoosenShipAlreadyExists(input, player));
        }
        [Test]
        public void T08_ShouldReturnTrueWhenYouTryAttackThePlaceWhichExist()
        {
            bool expected = true;
            string attackedfield = "A1";
            bool result = InputValidator.CheckPosition(attackedfield);
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void T09_ShouldReturnTrueWhenYouAttackPlaceWhichYouAttackBefore()
        {
            bool expected = true;
            string attackedfield = "A1";
            List<string> OccupiedFields = new List<string> { "A1","A2" };
            bool result = OccupiedFields.Contains(attackedfield);
                Assert.AreEqual(expected, result);
        }
        
    }
}
