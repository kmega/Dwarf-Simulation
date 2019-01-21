using System;
using System.Collections.Generic;
using System.IO;

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
            //ShipTypes.Subarine,
            ShipTypes.Subarine
        };

        public List<ShipTypes> GetShipList()
        {
            return ShipList;
        }

        public List<ShipTypes> GetShipsFromConfigFile()
        {
            List<ShipTypes> ShipListFromFile = new List<ShipTypes>();

            var openedFile = File.ReadLines(@"/Users/piotr/Desktop/Git/primary/20190116/BetterBattleships/BetterBattleships/ShipsList.txt");

            foreach (var item in openedFile)
            {
                if (item == ShipTypes.Carrier.ToString())
                    ShipListFromFile.Add(ShipTypes.Carrier);
                else if (item == ShipTypes.Battleship.ToString())
                    ShipListFromFile.Add(ShipTypes.Battleship);
                else if (item == ShipTypes.Subarine.ToString())
                    ShipListFromFile.Add(ShipTypes.Subarine);
                else if (item == ShipTypes.Cruiser.ToString())
                    ShipListFromFile.Add(ShipTypes.Cruiser);
            }



            return ShipListFromFile;

        }
    }
}