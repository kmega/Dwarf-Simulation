using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RecruitmentTasksRetakeTests
{
    public class FileOps
    {
        public List<string> GetFile()
        {
            string path = @"/Users/piotr/Desktop/Git/primary/20190104/RecruitmentTaskRetake/RecruitmentTaskRetake/tea-data.txt"; //mac
            return File.ReadAllLines(path).ToList();
        }

        public List<string[]> GetSortedList(List<string> origin)
        {
            //string tempLine1 = origin[0];
            //string tempLine2 = origin[1];

            origin.RemoveRange(0, 2);
            List<string[]> arrayList = new List<string[]>();

            foreach (string line in origin)
            {
                arrayList.Add(line.Split(","));
            }

            List<string[]> sortedArrayList = arrayList.OrderBy(x => x[1]).ToList(); 

            return sortedArrayList
        }

        public bool IsSorted(List<string[]> alphaSortedOrigin)
        {
           

        }
    }
}