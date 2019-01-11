using BattleShips;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace BattleShipsTests
{
    public class GameTests
    {
        [Test]
        public void ShoudMarkNextPlayerAsActiveWhenIsFieldHitIsFalse()
        {
            //given
            string field = "A1";
            List<Player> players = new List<Player>();
            //when
            bool result = Game.IsFieldHit(players[0]);
            result = false;
            //then
            Assert.IsTrue(players[1].IsActive);
        }

        [Test]
        public void ShouldMoveFieldFromListToAnotherListWhenIsFieldOnListIsTrue()
        {
            //given
            string field = "A1";
            List<string> fieldList = new List<string>();
            List<string> resultList = new List<string>();
            //when
            Game.MoveFieldFromOneListToAnother(fieldList, resultList);
            //then
            Assert.AreEqual(resultList.Where(p => p.Equals(field)), fieldList.Where(p => p.Equals(field)));
        }

        [Test]
        public void ShouldReturnTrueWhenFieldIsOnFieldList()
        {
            //given
            Player player = new Player();
            //when
            bool result = Game.IsFieldOnList(player);
            //then
            Assert.IsTrue(result);
        }
    }
}