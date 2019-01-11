using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShip
{
    public class UIvalidation
    {
        public UIvalidation()
        {
            //TypeOfShipValidation();
        }
        public string TypeOfShipValidation(string x)
        {
            // A,B,D,S,P
            string[] chooseLetter = new string[5] {"A", "B"};
            return x;

        } 
        public string StartPointValidation(string x)
        {
            return x;
        }
        public string DirectionValidation(string x)
        {
            return x;
        }

        
    }
}