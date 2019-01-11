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
        public string TypeOfShipValidation()
        {
            
            string x = "";
            
            List <string> chooseLetter = new List<string>( new [] {"A", "B", "D", "S", "P", "a", "b,", "d", "s", "p"});
            string choose = "";
            string j = "";
            do
            {
            choose = Console.ReadLine();
            foreach (string i in chooseLetter)
            {
                
                if (choose.Contains(i))
                {
                    x = choose;
                }
                else
                {
                    x = j;
                    Console.WriteLine("Wprowadzono błędną wartość!!!");
                }
            }
            }while (x != j);
            return x;

        } 
        public string StartPointValidation()
        {
            string x = "";
            string choose = "";
            string j = "";
            List <string> coOrdinatesLetter = new List<string>( new [] {"A", "B", "C", "D", "E", "F", "G,",
                                                                         "H", "I", "J"});
            List <string> coOrdinatesNumber = new List<string>( new[] {"1", "2", "3", "4", "5", "6",
                                                                         "7", "8", "9", "10"});
            choose = Console.ReadLine();
            
            return x;
            
            
        }
        public string DirectionValidation()
        {
            string x = "";
            return x;
        }

        
    }
}