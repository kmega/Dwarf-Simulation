﻿using System;
using System.Collections;
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

            List<Line> FirstTreeObj = new LineManager().CreateAllLineObjects(FirstTree);
            List<Line> SecondTreeObj = new LineManager().CreateAllLineObjects(SecondTree);

            List<Line> temp12 = FirstTreeObj.Concat(SecondTreeObj).ToList();

            var distinctItems = temp12.GroupBy(x => x.Name).Select(y => y.First());


            foreach (var item in distinctItems)
            {
                Console.WriteLine(item.Name);
            }
        }

        class MethodComparer : IEqualityComparer<Line>
        {
            public bool Equals(Line x, Line y)
            {
                if (Object.ReferenceEquals(x, y)) return true;

                if (Object.ReferenceEquals(x, null) ||
                    Object.ReferenceEquals(y, null))
                    return false;

                return x.Name == y.Name && x.ParentList.SequenceEqual(y.ParentList);
            }

            public int GetHashCode(Line line)
            {
                if (Object.ReferenceEquals(line, null)) return 0;

                int hashID = line.Name == null
                    ? 0 : line.Name.GetHashCode();

                int hashName = line.ParentList.GetHashCode();

                return hashID ^ hashName;
            }
        }

        private class LineManager
        {
            List<Line> ListOfLines = new List<Line>();
            LineCreator lineCreator = new LineCreator();
            List<Parent> ListOfParents = new List<Parent>();

            public List<Line> CreateAllLineObjects(List<string> tList)
            {
                int topDepth;

                for (int i = 0; i < tList.Count; i++)
                {
                    var TemporaryLine = lineCreator.CreateSingleLine(tList[i]);

                    if (ListOfLines.Any())
                        topDepth = ListOfLines.Max(x => x.SpaceCout);
                    else topDepth = 0;

                    if(TemporaryLine.SpaceCout > topDepth)
                    {
                        ListOfParents.Add(TemporaryLine.Parent);
                        TemporaryLine.ParentList = new List<Parent>(ListOfParents);
                        TemporaryLine.ParentList.Reverse();
                        TemporaryLine.ParentList.RemoveAt(0);

                    }

                    if (TemporaryLine.SpaceCout < topDepth || TemporaryLine.SpaceCout == topDepth)
                    {
                        var tempParentList = new List<Parent>(ListOfParents);
                        var correctParrentList = tempParentList.Where(x => 
                                                                        x.spaceCout < topDepth && 
                                                                        x.spaceCout != topDepth-1)
                                                                        .ToList();
                        TemporaryLine.ParentList = new List<Parent>(correctParrentList);
                        TemporaryLine.ParentList.Reverse();
                        if(TemporaryLine.ParentList.Count > 1)
                            TemporaryLine.ParentList.RemoveAt(0);
                    }


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




