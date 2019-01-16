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
            switch(validationInfo)
            {
                case "c":
                case "d":
                case "b":
                case "s":
                case "p":
                    return true;
                default:
                    throw new Exception("Incorrect ship type inserted. Please try again!");
            }
        }

        public static bool CheckPosition(string message)
        {
            string validationInfo = message.ToUpper();
            
            return false;
        }
        public static bool CheckDirection(string message)
        {
            string validationInfo = message.ToLower();
            switch(validationInfo)
            {
                case "u":
                case "r":
                case "l":
                case "d":
                    return true;
                default:
                    throw new Exception("Incorrect direction inserted, please try again!");
            }
        }
    }
}
