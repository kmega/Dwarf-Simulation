using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TeaApp
{
    public class FileManager
    {
        public static List<string> ReadFile(string filePath)
        {
           return File.ReadAllLines(filePath).ToList();
        }

        public static List<string> ReverseRecords(List<string> textLines)
        {
            textLines.Reverse();
            return textLines;
        }

        public static string[] SeperateLine(string line)
        {
            return line.Split(new string[] { ", " }, StringSplitOptions.None);
        }
    }
}