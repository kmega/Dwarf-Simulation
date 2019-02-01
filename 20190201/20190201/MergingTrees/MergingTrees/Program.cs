using System;
using System.Collections.Generic;
using System.Linq;

namespace MergingTrees
{

    partial class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var FirstTree = "1. Świat\n    1. Primus\n        1. Astoria\n            1. Szczeliniec\n                1. Powiat Pustogorski\n                    1. Pustogor\n                        1. Gabinet Pięknotki\n                    1. Zaczęstwo\n                        1. Cyberszkoła\n                        1. Osiedle Ptasie\n                    1. Trzęsawisko Zjawosztup\n                        1. Głodna Ziemia".Split("\n").ToList();
            var SecondTree = "1. Świat\n    1. Primus\n        1. Astoria, Asteroidy".Split("\n").ToList();
            var ThirdTree = "1. Świat\n    1. Primus\n        1. Astoria\n            1. Szczeliniec\n                1. Powiat Pustogorski\n                    1. Zaczęstwo\n                        1. Kasyno Marzeń\n                        1. Szkoła Magów".Split("\n").ToList();


            List<string> ListOfParents = new List<string>();

            List<Line> FirstTreeObj = new LineManager().CreateAllLineObjects(FirstTree, ListOfParents);

            List<Line> SecondTreeObj = new LineManager().CreateAllLineObjects(SecondTree, ListOfParents);

            List<Line> ThirdTreeObj = new LineManager().CreateAllLineObjects(ThirdTree, ListOfParents);

            var temp2 = FirstTreeObj.Union(ThirdTreeObj).ToList();
            var final = temp2.GroupBy(x => x.ParentList).Select(x => x.First()).ToList();
            var final2 = final.GroupBy(x => x.Name).Select(x => x.First()).ToList();

            foreach (var item in final2)
            {
                Console.WriteLine(item.Name);
            }
        }

        private class LineManager
        {
            List<Line> ListOfLines = new List<Line>();
            LineCreator lineCreator = new LineCreator();

            public List<Line> CreateAllLineObjects(List<string> tList, List<string> ListOfParents)
            {
                foreach (var item in tList)
                {
                    var TemporaryLine = lineCreator.CreateSingleLine(item);
                    int size = ListOfParents.Count - 1;

                    if (TemporaryLine.SpaceCout != ListOfParents.Count-1)
                    {
                        ListOfParents.Add(TemporaryLine.Parent);
                    }

                    TemporaryLine.ParentList = new List<string>(ListOfParents);
                    TemporaryLine.ParentList.RemoveAt(TemporaryLine.ParentList.Count - 1);
                    TemporaryLine.ParentList.Reverse();
                    ListOfLines.Add(TemporaryLine);
                }

                return ListOfLines;
            }
        }

        public static class StringParser
        {
            public static int ParseSpaceCount(string line)
            {
                return line.IndexOf('1') / 4;
            }

            public static string ParsePath(string line)
            {
                return line.Replace("1.", "").Trim();
            }
        }
    }
}
