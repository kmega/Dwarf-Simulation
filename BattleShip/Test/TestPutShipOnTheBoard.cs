using System;
using BattleShip;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class TestPutShipOnTheBoard
    {
        [TestMethod]
        public void ParserCoordinateMethodShouldReturn1And2WhenA1()
        {
            //Given
            PutShipOnTheBoard putship = new PutShipOnTheBoard();
            string coordinates = "a2";
            //Then
            int[] result = putship.CoordinatesParser(coordinates);

            Assert.AreEqual(result[0], 1);
            Assert.AreEqual(result[1], 2);
        }

        [TestMethod]
        public void ParserCoordinateMethodShouldReturn2And10WhenA1()
        {
            //Given
            PutShipOnTheBoard putship = new PutShipOnTheBoard();
            string coordinates = "B10";
            //Then
            int[] result = putship.CoordinatesParser(coordinates);

            Assert.AreEqual(result[0], 2);
            Assert.AreEqual(result[1], 10);
        }

        [TestMethod]
        public void ParserCoordinateMethodShouldReturn4And5WhenA1()
        {
            //Given
            PutShipOnTheBoard putship = new PutShipOnTheBoard();
            string coordinates = "D5";
            //Then
            int[] result = putship.CoordinatesParser(coordinates);

            Assert.AreEqual(result[0], 4);
            Assert.AreEqual(result[1], 5);
        }

        [TestMethod]
        public void ShoudChangeFieldB2ToS()
        {
            //Given
            Player player = new Player(1);
            PutShipOnTheBoard put = new PutShipOnTheBoard();
            string coordinates = "A1";
            bool horizontal = true;
            int id_ship = 1;

            Assert.AreEqual(player.Player_Board.Fields[0,0], Field.O);
            //When
            put.PutShip(player, coordinates, horizontal, id_ship);
            //Then

            Assert.AreEqual(player.Player_Board.Fields[0, 0], Field.S);
        }

        [TestMethod]
        public void ShoudChangeFieldB2AndB3ToS()
        {
            //Given
            Player player = new Player(1);
            PutShipOnTheBoard put = new PutShipOnTheBoard();
            string coordinates = "B2";
            bool horizontal = true;
            int id_ship = 2;

            Assert.AreEqual(player.Player_Board.Fields[1, 1], Field.O);
            Assert.AreEqual(player.Player_Board.Fields[2, 1], Field.O);
            //When
            put.PutShip(player, coordinates, horizontal, id_ship);
            //Then

            Assert.AreEqual(player.Player_Board.Fields[1, 1], Field.S);
            Assert.AreEqual(player.Player_Board.Fields[2, 1], Field.S);
        }

        [TestMethod]
        public void ShoudChangeFieldA2AndB2AndC2ToS()
        {
            //Given
            Player player = new Player(1);
            PutShipOnTheBoard put = new PutShipOnTheBoard();
            string coordinates = "A2";
            bool horizontal = false;
            int id_ship = 3;

            Assert.AreEqual(player.Player_Board.Fields[0, 1], Field.O);
            Assert.AreEqual(player.Player_Board.Fields[0, 2], Field.O);
            Assert.AreEqual(player.Player_Board.Fields[0, 3], Field.O);
            //When
            put.PutShip(player, coordinates, horizontal, id_ship);
            //Then

            Assert.AreEqual(player.Player_Board.Fields[0, 1], Field.S);
            Assert.AreEqual(player.Player_Board.Fields[0, 2], Field.S);
            Assert.AreEqual(player.Player_Board.Fields[0, 3], Field.S);
        }

    }
}