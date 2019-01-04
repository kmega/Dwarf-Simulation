using System;
using System.Collections.Generic;

namespace RecruitmentTasksRetakeTests
{
    public class Task1
    {
        public List<string> ReverseArray(List<string> list)
        {
            list.Reverse();
            return list;
        }

        internal bool IsReversed(List<string> origin, List<string> reversed)
        {
            return CheckReverseStatus(origin, reversed);
        }

        private static bool CheckReverseStatus(List<string> origin, List<string> reversed)
        {
            int iterator = reversed.Count - 1;
            bool flag = false;

            foreach (string line in origin)
            {
                if (line == reversed[iterator])
                    flag = true;
                else flag = false;
                iterator--;
            }

            return flag;
        }
    }
}