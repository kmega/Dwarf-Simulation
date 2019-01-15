using BattleShips.Enums;
using BattleShips.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShipsTests
{
    class FakePlayer : IPlayer
    {
        public FakePlayer()
        {
            
        }
        public List<IShip> Ships { get; set; }
    }
}
