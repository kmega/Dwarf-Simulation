using BattleShips;
using NUnit.Framework;
using System.Collections.Generic;

namespace BattleShipsTests
{
    public class GameTests
    {
        [Test]
        public void ShouldReturnFalseWhenFieldHasNoShip()
        {
            //given
            List<string> strings = new List<string>() { "A1", "A2" };
            Player player = new Player();
            Ship ship = new Ship(BattleShips.Enums.ShipType.PatrolBoat, strings, player);

            //when
            bool result = Game.IsFieldEmpty(ship);

            //then
            Assert.IsFalse(result);
        }

        [Test]
        public void ShouldReturnTrueWhenFieldHasShip()
        {
            //given
            List<string> strings = new List<string>() { "A1", "A2" };
            Player player = new Player();
            Ship ship = new Ship(BattleShips.Enums.ShipType.PatrolBoat, strings, player);

            //when
            bool result = Game.IsFieldEmpty(ship);

            //then
            Assert.IsTrue(result);
        }
    }
}