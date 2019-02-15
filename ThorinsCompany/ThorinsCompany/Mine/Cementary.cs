using System;
using System.Collections.Generic;

namespace ThorinsCompany
{
    public class Cementary
    {
        public static int _deadDwarves = 0;
        public static void ReceiveDeadWorkers(WorkingGroup deadGroup)
        {
            _deadDwarves += deadGroup.Workers.Length;
            deadGroup.Clear();
        }


    }
}