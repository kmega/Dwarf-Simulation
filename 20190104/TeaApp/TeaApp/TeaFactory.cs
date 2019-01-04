using System;
using System.Collections.Generic;
using System.Linq;

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
        public static string CheckTeaQuality(List<Tea> goodTeas, string name, int temp, int time)
        {
            Tea preparedTea = goodTeas.Where(x => x.Name.Equals(name)).First();
            if(temp > preparedTea.Temperature*1.1 || time > preparedTea.TimeOfCooking*60*1.1)
            {
                return "yucky";
            }
            else if(temp < preparedTea.Temperature*0.9 || time < preparedTea.TimeOfCooking*60*0.9)
            {
                return "weak";
            }
            return "perfect";

        }

    }
}