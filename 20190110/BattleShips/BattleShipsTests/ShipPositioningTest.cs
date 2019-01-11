using BattleShips;
using NUnit.Framework;
using System;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ShouldPlaceVerticallyCarrierShipWithDirectionDown()
        {
            //given:
            string type = "c";
            string startPosition = "B5";
            string direction = "d";
            Player player = new Player()
            {
                PlayerName = "Marcin"
            };
            //when
            ShipFactory actual = new ShipFactory();
            actual.PlaceSingleShip(type, startPosition, direction, player);
            //then
            Assert.IsTrue(player.PlayerName == "Marcin");
            Assert.IsTrue(player.FieldWithShips.Contains("B9"));
        }
        [Test]
        public void ShouldPlaceVerticallyBattleShipWithDirectionUp()
        {
            //given:
            string type = "B";
            string startPosition = "G9";
            string direction = "u";
            Player player = new Player()
            {
                PlayerName = "Marcin"
            };
            //when
            ShipFactory actual = new ShipFactory();
            actual.PlaceSingleShip(type, startPosition, direction, player);
            //then
            Assert.IsTrue(player.PlayerName == "Marcin");
            Assert.IsTrue(player.FieldWithShips.Contains("G6"));
        }
        [Test]
        public void ShouldPlaceHorizontalCarrierWithDirectionRight()
        {
            //given:
            string type = "C";
            string startPosition = "B5";
            string direction = "r";
            Player player = new Player()
            {
                PlayerName = "Marcin"
            };
            //when
            ShipFactory actual = new ShipFactory();
            actual.PlaceSingleShip(type, startPosition, direction, player);
            //then
            Assert.IsTrue(player.PlayerName == "Marcin");
            Assert.IsTrue(player.FieldWithShips.Contains("F5"));
        }
        [Test]
        public void ShouldPlaceHorizontalCarrierWithDirectionLeft()
        {
            //given:
            string type = "C";
            string startPosition = "H5";
            string direction = "l";
            Player player = new Player()
            {
                PlayerName = "Marcin"
            };
            //when
            ShipFactory actual = new ShipFactory();
            actual.PlaceSingleShip(type, startPosition, direction, player);
            //then
            Assert.IsTrue(player.PlayerName == "Marcin");
            Assert.IsTrue(player.FieldWithShips.Contains("D5"));
        }
        [Test]
        public void ShouldReturnArgumentExceptionWhenTryingToAddVerticalPositionBeyondBoard()
        {
            //given;
            ShipFactory actual = new ShipFactory();

            Assert.Throws<ArgumentException>(
                () => actual.CheckVerticalPosition(0),
                "Ship placed inproperly, try again: ");
            Assert.Throws<ArgumentException>(
                () => actual.CheckVerticalPosition(11),
                "Ship placed inproperly, try again: ");
        }
        [Test]
        public void ShouldReturnArgumentExceptionWhenTryingToAddHorizontalPositionBeyondBoard()
        {
            //given;
            ShipFactory actual = new ShipFactory();
            char K = 'K';
            char at = '@';
            Assert.Throws<ArgumentException>(
                () => actual.CheckHorizontalPosition(K),
                "Ship placed inproperly, try again: ");
            Assert.Throws<ArgumentException>(
                () => actual.CheckHorizontalPosition(at),
                "Ship placed inproperly, try again: ");
        }
    }
}