using System;
using System.Collections.Generic;
using System.Text;

namespace ThorinsCompany
{
    public static class IDCreator
    {
        private static int UniqueID = 0;
        public static int GetUniqueID()
        {
            UniqueID++;
            return UniqueID;
        }
    }
}

