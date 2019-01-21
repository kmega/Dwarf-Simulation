using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShips.Models
{
    public static class InputValidator
    {
        public static bool CheckShipType(string message)
        {
            string validationInfo = message.ToLower();
            switch (validationInfo)
            {
                case "c":
                case "d":
                case "b":
                case "s":
                case "p":
                    return true;
                default:
                    throw new Exception("Wprowadzono nieprawidłowy typ okrętu! Spróbuj ponownie!");
            }
        }

        public static bool CheckPosition(string message)
        {
            string validationInfo = message.ToUpper();
            int x = -2, y = -2;
            if (message.Length == 3 || message.Length == 2)
            {
                TextParser.ParseFieldToInt(validationInfo, out x, out y);                
            }
            if (x >= 0 && x <= 9 && y >= 0 && y <= 9)
            {
                return true;
            }
            throw new Exception("Wprowadzono nieprawidłową pozycję! Spróbuj ponownie!");
        }

        public static bool CheckDirection(string message)
        {
            string validationInfo = message.ToLower();
            switch (validationInfo)
            {
                case "u":
                case "r":
                case "l":
                case "d":
                    return true;
                default:
                    throw new Exception("Wprowadzono nieprawidłowy kierunek! Spróbuj ponownie!");
            }
        }

        public static bool CheckIfChoosenShipAlreadyExists(string message, Player player)
        {
            int l;
            var shipType = new Shipfactory().GetShipType(message, out l);
            foreach(var ship in player.Ships)
            {
                if(ship.Type == shipType)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
