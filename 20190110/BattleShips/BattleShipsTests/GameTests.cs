using BattleShips;
using NUnit.Framework;

namespace BattleShipsTests
{
    public class GameTests
    {
        [Test]
        public void ShouldReturnFalseWhenFieldHasNoShip()
        {
            //given
            string field = "";

            //when
            bool result = Game.IsFieldEmpty(field);

            //then
            Assert.IsFalse(result);
        }

        [Test]
        public void ShouldReturnTrueWhenFieldHasShip()
        {
            //given
            string field = "";

            //when
            bool result = Game.IsFieldEmpty(field);

            //then
            Assert.IsTrue(result);
        }

       
    }
}