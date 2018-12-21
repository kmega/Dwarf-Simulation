using System;
using System.Collections.Generic;

namespace Task4
{
    public class RegexOperator
    {
        public List<string> MagdaTitleExtractor(List<string> ListWithContent)
        {
            List<string> tempList = new List<string>();
            TextParser textParser = new TextParser();

            foreach (string element in ListWithContent)
            {
                string tempName = textParser.ExtractStuffWithMagda(element);
                string tempTitle = textParser.ExtractStoryName(element);
                if (tempTitle != String.Empty && tempName != String.Empty)
                {
                    tempList.Add(tempTitle);
                }
            }
            return tempList;
        }

        public string MagdaName(List<string> ListWithContent)
        {
            string name = null;
            TextParser textParser = new TextParser();

            foreach (string content in ListWithContent)
            {
                string tempName = textParser.ExtractStuffWithMagda(content);
                if (tempName != String.Empty)
                {
                    name = tempName;
                    break;
                }
            }
            return name;
        }
    }
}
