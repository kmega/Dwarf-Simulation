using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeaTask
{
    class Program
    {

        static void Main(string[] args)
        {
            List<DowloadTeaInformation> dict = new List<DowloadTeaInformation>();
            DowloadInformationTea(dict);
            int caseSwitch = 1;
            do
            {
                Console.WriteLine("select command 1 - reversing the records");
                Console.WriteLine("select command 2 - sorting the teas");
                Console.WriteLine("select command 4 - Make a tea");
                Console.WriteLine("select command 5 - Make several teas with document txt");
                Console.WriteLine("select command 6 - Make a Touareg tea with document txt");
                Console.WriteLine("Select command 10 if you want finish");
                caseSwitch = int.Parse(Console.ReadLine());
                switch (caseSwitch)
                {
                    case 1:
                        ReverseDataAndSaveIt(dict);
                        break;
                    case 2:
                        SortTeaAndSaveIt(dict);
                        break;
                    case 4:
                        MakeATea(dict);
                        break;
                    case 5:

                        List<DowloadTeaInformationToMakeIt> TeaFromTxt 
                            = new List<DowloadTeaInformationToMakeIt>();
                        Encoding enc = Encoding.GetEncoding("Windows-1250");
                        StreamReader file2 = new StreamReader(@"C:\Users\Ula\Desktop\Programowanie\TeaTask\input-file.txt", enc, true);
                        
                        string line;
                        string saveContent = "";
                        while ((line = file2.ReadLine()) != null)
                        {
                            string[] words = line.Split(new Char[] { ',' });
                            if (words.Length == 3)
                                TeaFromTxt.Add(new DowloadTeaInformationToMakeIt
                                {
                                    TeaName = words[0].Trim(' '),
                                    Boilingpoint = words[1].Trim(' '),
                                    BoilingTime = words[2].Trim(' ')
                                });
                        }
                        int whereRecordIs = 0;
                        for (int i = 0; i < TeaFromTxt.Count; i++)
                        {
                            for (int j = 0; j < dict.Count; j++)
                            {
                                if (TeaFromTxt[i].TeaName == dict[j].TeaName)
                                {
                                    whereRecordIs = j;
                                    j = dict.Count;
                                }
                            }
                            if ((int.Parse(dict[whereRecordIs].Boilingpoint) * 1.1 > int.Parse(TeaFromTxt[i].Boilingpoint)
             && int.Parse(dict[whereRecordIs].Boilingpoint) * 0.9 < int.Parse(TeaFromTxt[i].Boilingpoint))
             && (int.Parse(dict[whereRecordIs].BoilingTime) * 60) * 1.1 > int.Parse(TeaFromTxt[i].BoilingTime)
             && (int.Parse(dict[whereRecordIs].BoilingTime) * 60) * 0.9 < int.Parse(TeaFromTxt[i].BoilingTime))
                            {
                                saveContent += TeaFromTxt[i].TeaName + ", perfect";
                            }
                            else if (int.Parse(dict[whereRecordIs].Boilingpoint) * 0.9 > int.Parse(TeaFromTxt[i].BoilingTime))
                            {
                                saveContent += TeaFromTxt[i].TeaName + ", weak ";
                            }
                            else
                            {
                                saveContent += "yucky";
                            }
                        }
                        break;
                    case 6:
                        break;
                }
                Console.Clear();
            } while (caseSwitch != 10);
        }

        private static string MakeATea(List<DowloadTeaInformation> dict)
        {
            Console.WriteLine("Name of the tea");
            string nameOfTea = Console.ReadLine();
            Console.WriteLine("Temperature of water you want to use");
            int tempWater = int.Parse(Console.ReadLine());
            Console.WriteLine("Amount of time you want to spend brewing that tea (in seconds)");
            int timeInSecond = int.Parse(Console.ReadLine());
            int whereIsteaRecord = 0;
            for (int i = 2; i < dict.Count; i++)
            {
                if (dict[i].TeaName == nameOfTea)
                {
                    whereIsteaRecord = i;
                    i = dict.Count;
                }
            }
            string saveContent = "";


            double test = int.Parse(dict[whereIsteaRecord].BoilingTime) * 60 * 1.1;
            if (int.Parse(dict[whereIsteaRecord].Boilingpoint) == tempWater
                && int.Parse(dict[whereIsteaRecord].BoilingTime) * 60 == timeInSecond)
            {
                saveContent += "Exactly like in tea-data.txt";
            }
            else if (int.Parse(dict[whereIsteaRecord].BoilingTime) * 60 * 1.1 < timeInSecond
                || int.Parse(dict[whereIsteaRecord].BoilingTime) * 60 * 0.9 > timeInSecond)
            {
                saveContent += "Yucky. Too little temperature and too much time.";
            }
            else if (int.Parse(dict[whereIsteaRecord].Boilingpoint) * 1.1 < tempWater)
            {
                saveContent += "Yucky. Too high temperature (how did we get THAT temperature, " +
                    "by the way? Shouldn’t we have steam at that point ?)";
            }
            else if ((int.Parse(dict[whereIsteaRecord].Boilingpoint) * 1.1 > tempWater
                && int.Parse(dict[whereIsteaRecord].Boilingpoint) * 0.9 < tempWater)
                && (int.Parse(dict[whereIsteaRecord].BoilingTime) * 60) * 1.1 > timeInSecond
                && (int.Parse(dict[whereIsteaRecord].BoilingTime) * 60) * 0.9 < timeInSecond)
            {
                saveContent += "Perfect. A bit too little temperature, but in 10% deviation" +
                    "(10 % of " + dict[whereIsteaRecord].Boilingpoint + " is "
                    + int.Parse(dict[whereIsteaRecord].Boilingpoint) * 0.1 +
                    ", so: " + int.Parse(dict[whereIsteaRecord].Boilingpoint) * 0.9 +
                    " - " + int.Parse(dict[whereIsteaRecord].Boilingpoint) * 1.1 +
                    "). Same with the time - " + timeInSecond + " seconds is in "
                    + "10% deviation (" +
                    int.Parse(dict[whereIsteaRecord].BoilingTime) * 0.9 + "-" +
                    int.Parse(dict[whereIsteaRecord].BoilingTime) * 1.1 +
                    " are acceptable)";
            }
            else if (int.Parse(dict[whereIsteaRecord].Boilingpoint) * 0.9 > tempWater)
            {
                saveContent += "Weak " + "Too little temperature";
            }

            return saveContent;
        }

        private static void SortTeaAndSaveIt(List<DowloadTeaInformation> dict)
        {
            string saveContent = "";
            int[] RemberRecords = new int[2];
            var newList = dict.OrderBy(x => x.TypeTea).ToList();
            for (int i = 0; i < newList.Count; i++)
            {
                if (newList[i].TeaName == "# Nazwa herbaty")
                {
                    saveContent += newList[i].TeaName + ", " + newList[i].TypeTea + ", " + newList[i].Boilingpoint
                    + ", " + newList[i].BoilingTime + ", " + newList[i].SpecialAtribute + "\n";
                    RemberRecords[0] = i;
                    i = newList.Count;
                    saveContent += newList[0].TeaName + "\n";
                    RemberRecords[1] = 1;
                }
            }
            for (int i = 0; i < newList.Count; i++)
            {
                if (i != RemberRecords[0] && i != RemberRecords[1])
                {
                    saveContent += newList[i].TeaName + ", " + newList[i].TypeTea + ", " + newList[i].Boilingpoint
                    + ", " + newList[i].BoilingTime + ", " + newList[i].SpecialAtribute + "\n";
                }
            }
        }

        private static string ReverseDataAndSaveIt(List<DowloadTeaInformation> dict)
        {
            string saveContent = "";
            string PathFileToSave = @"D:\Tea txt\Task01";

            for (int i = dict.Count - 1; i >= 0; i--)
            {
                saveContent += dict[i].TeaName + ", " + dict[i].TypeTea + ", " + dict[i].Boilingpoint
                    + ", " + dict[i].BoilingTime + ", " + dict[i].SpecialAtribute + "\n";
            }

            SaveFile(PathFileToSave, saveContent);
            return saveContent;
        }

        private static void DowloadInformationTea(List<DowloadTeaInformation> dict)
        {
            StreamReader file2 = new StreamReader(@"C:\Users\Ula\Desktop\Programowanie\TeaTask\tea-data.txt");
            string line;
            while ((line = file2.ReadLine()) != null)
            {
                string[] words = line.Split(new Char[] { ',' });
                if (words.Length == 4)
                    dict.Add(new DowloadTeaInformation
                    {
                        TeaName = words[0].Trim(' '),
                        TypeTea = words[1].Trim(' '),
                        Boilingpoint = words[2].Trim(' '),
                        BoilingTime = words[3].Trim(' '),
                        SpecialAtribute = null
                    });
                else if (words.Length == 5)
                    dict.Add(new DowloadTeaInformation
                    {
                        TeaName = words[0].Trim(' '),
                        TypeTea = words[1].Trim(' '),
                        Boilingpoint = words[2].Trim(' '),
                        BoilingTime = words[3].Trim(' '),
                        SpecialAtribute = words[4].Trim(' ')
                    });
                else if (words.Length == 1)
                    dict.Add(new DowloadTeaInformation
                    {
                        TeaName = words[0]
                    });
            }
        }

        public static void SaveFile(string whereSave, string saveContent)
        {
            StreamWriter SW = File.AppendText(whereSave);
            SW.WriteLine(saveContent);
            SW.Close();
        }

    }
}
