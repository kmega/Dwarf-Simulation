using System;
using System.Collections.Generic;

namespace BetterBattleships
{
    public class AvailableShips
    {
        private List<ShipTypes> ShipList = new List<ShipTypes>
        {
            ShipTypes.Carrier,
            ShipTypes.Subarine
        };

        public List<ShipTypes> GetShipList()
        {
            return ShipList;
        }
    }
}