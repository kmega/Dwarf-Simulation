using System;
using System.Collections.Generic;

namespace BetterBattleships
{
    public class AvailableShips
    {
        private readonly List<ShipTypes> ShipList = new List<ShipTypes>
        {
            //ShipTypes.Carrier,
            //ShipTypes.Battleship,
            //ShipTypes.Battleship,
            //ShipTypes.Cruiser,
            //ShipTypes.Cruiser,
            //ShipTypes.Cruiser,
            //ShipTypes.Subarine,
            //ShipTypes.Subarine,
            ShipTypes.Subarine,
            ShipTypes.Subarine
        };

        public List<ShipTypes> GetShipList()
        {
            return ShipList;
        }
    }
}