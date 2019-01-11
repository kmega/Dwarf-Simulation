using BattleShips;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace BattleShipsTests
{
    public class GameTests
    {
        [Test]
        public void ShouldReturnTrueWhenPlayerHasAShip()
        {
            //given
            Game game = new Game();
            var players = FakeData.CreateFakeData();
            //when
            bool result = game.CheckIfPlayersHasShips(players);
            //then
            Assert.IsTrue(result);
        }

        
       
    }
}