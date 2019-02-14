using System;
using System.Collections.Generic;
using System.Text;

namespace ThorinsCompany.Bank
{
    public static class IDCreator
    {
        private static int UniqeID = 0;
        public static int GetUniqeID()
        {
            UniqeID++;
            return UniqeID;
        }
    }
}
