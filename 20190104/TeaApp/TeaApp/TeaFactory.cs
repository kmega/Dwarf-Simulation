using System;
using System.Collections.Generic;

namespace TeaApp
{
    public class TeaFactory
    {
        public static List<Tea> BuildFromFile(List<string> textLines)
        {
            List<Tea> teas = new List<Tea>();
            foreach(var line in textLines)
            {
                //SeperateLine()textline[i] -> string[] teaReciepe
                string[] teaReciepe = FileManager.SeperateLine(line);
                //BuildSingleTea(teaReciepe)
                teas.Add(BuildSingleTea(teaReciepe));
            }
            return teas;
        }

        public static Tea BuildSingleTea(string[] teaReciepe)
        {
            return new Tea(
                teaReciepe[0],
                teaReciepe[1],
                Int32.Parse(teaReciepe[2]),
                Int32.Parse(teaReciepe[3]));
        }
    }
}