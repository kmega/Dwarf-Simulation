using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShips.Models
{
    public interface IPlayer
    {
        List<IShip> Ships { get; set; }
    }
}
