using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Task5
{
    class Extractor
    {
        public List<int> Extract(string configCommands)
        {
            string[] tempString = configCommands.Split(',');
            List<string> tempList = tempString.ToList();
            List<int> returnList = new List<int>();
            TextParser textParser = new TextParser();

            foreach (string value in tempList)
            {
                //string temp = textParser.ExtractIntCommand(value);
                //Tortoise... why your regex doesnt want to work :(
                //string temp = Regex.Match(value, @"\d+ -> ""(\d+)"" -> groups[1].Value").Value;
                string temp = Regex.Match(value, @"\d+").Value;

                if (temp != String.Empty)
                {
                    returnList.Add(Convert.ToInt32(temp));
                }
            }
            return returnList;
        }
    }
}
