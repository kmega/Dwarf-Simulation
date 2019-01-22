﻿using BattleShips;
using BattleShips.Models;
using NUnit.Framework;
using System.Collections.Generic;

namespace BattleShipsTests
{
    public class GameTests
    {
        [Test]
        public void ShouldReturnFalseWhenInactivePlayersHasNoShip()
        {
            //given
            Player player = new Player();
            player.Ships.Add(new FakeDestroyedCarrier());
            List<Player> players = new List<Player>() { player };
            //when
            bool result = Game.WhetherInactivePlayersHasShips(players);
            //then
            Assert.IsFalse(result);
        }
        [Test]
        public void ShouldReturnTrueWhenInactivePlayerHasAtleastOneActiveShip()
        {
            //given
            Player player = new Player();
            player.Ships.Add(new FakeDestroyedCarrier());
            player.Ships.Add(new FakeCarrier());
            List<Player> players = new List<Player>() { player };
            //when
            bool result = Game.WhetherInactivePlayersHasShips(players);
            //then
            Assert.IsTrue(result);
        }

        [Test]
        public void ShouldChangeActivePlayers()
        {
            //given
            Player player1 = new Player() { IsActive = false };
            Player player2 = new Player() { IsActive = true };
            List<Player> players = new List<Player>();
            players.Add(player1);
            players.Add(player2);
            Game game = new Game();
            //when
            game.ChangeActivePlayer(players);
            //then
            Assert.IsTrue(player1.IsActive);
            Assert.IsFalse(player2.IsActive);
        }

        [Test]
        public void ShouldReturnTrueIfPlayersShipIsHit()
        {
            //given
            string field = "C2";
            Player player = new Player();
            player.Ships.Add(new FakeCarrier());
            List<Player> players = new List<Player>();
            players.Add(player);
            Game game = new Game();
            //when
            bool result = game.CheckIfShipIsHit(field, players);
            //then
            Assert.IsTrue(result);
        }
    }
}