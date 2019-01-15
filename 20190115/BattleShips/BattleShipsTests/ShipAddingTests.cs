using BattleShips.Models;
using BattleShipsTests;
using NUnit.Framework;
using System;

namespace Tests
{
    public class Tests
    {
        [Test]
        [TestCase("u")]
        [TestCase("d")]
        [TestCase("r")]
        [TestCase("l")]
        public void T01_ShouldBuildDestroyerAndPlaceItOnBoard(string direction)
        {
            //given Tested all possible directions
            string type = "d";
            string position = "G6";
            var expected = new FakeDestroyer(direction);
            //When
            IShip result = new Shipfactory().Create(type, position, direction, new Player());
            //then
            Assert.AreEqual(expected.Type, result.Type);
            foreach(var pos in expected.OccupiedPositions)
            {
                Assert.IsTrue(result.OccupiedPositions.Contains(pos));
            }
        }
        [Test]
        [TestCase("u")]
        [TestCase("d")]
        [TestCase("r")]
        [TestCase("l")]
        public void T02_ShouldBuildOneDestroyerAndBlockNeighbourhood(string direction)
        {
            //given Tested all possible directions
            string type = "d";
            string position = "G6";
            var expected = new FakeDestroyer(direction);
            //when
            var result = new Shipfactory().Create(type, position, direction, new Player());
            //then
            foreach(var pos in result.OccupiedPositions)
            {
                Assert.IsTrue(expected.OccupiedPositions.Contains(pos));
            }
            foreach(var blockPos in result.BlockedNeighbourhood)
            {
                Assert.IsTrue(expected.BlockedNeighbourhood.Contains(blockPos));
            }
        }

        [Test]
        [TestCase(-1, 2)]
        [TestCase(10, 2)]
        [TestCase(2, -1)]
        [TestCase(2, 10)]
        public void T03_ShouldGetExceptionAboutWrongPositioningOutsideBoard(int x, int y)
        {
            Assert.Throws<ArgumentException>(
                () => new Shipfactory().BuildPosition(x,y),
                "Incorrect input, ship cannot be outside the board!");
        }

        [Test]
        [TestCase("d","l")]
        public void T04_ShouldThrowExceptionWhenAddingSecondShipTooClose(string direction, string direction2)
        {
            //given Tested all possible directions
            string type = "c";
            string position = "C2";
            string type2 = "d";
            string position2 = "E4";
            Shipfactory shipfactory = new Shipfactory();
            Player player = new Player();
            //when
            player.Ships.Add(shipfactory.Create(type, position, direction, player));
            var message = Assert.Throws<Exception>(() => shipfactory.Create(type2, position2, direction2, player)).Message;
            Assert.AreEqual("Error! You cannot place ship so close to others!", message);
        }
    }
}