﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ThorinsCompany
{
    public class WorkingGroup
    {
        public Dwarf[] Workers = new Dwarf[5];
        public WorkingGroup(Dwarf[] workers)
        {
            this.Workers = workers;
        }

        ~WorkingGroup()
        {
            //place for a logger;
        }
    }
}
