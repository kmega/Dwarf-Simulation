using System;
using System.Collections.Generic;
using System.Text;

namespace CorealateTasks
{
    public class TextReverser
    {
        public string[] ReverseInput(string[] teaData)
        {
            List<string> reversedTeaData = new List<string>();

            for (int i = teaData.Length - 1; i > -1; i--)
            {
                reversedTeaData.Add(teaData[i]);
            }

            return reversedTeaData.ToArray();
        }
 
    }
}
