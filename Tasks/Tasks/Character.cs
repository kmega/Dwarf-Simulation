﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks
{
    class Character
    {
        public string Title { get; set; }
        public string Time { get; set; }

        public override string ToString()
        {
            return $"{Title} {Time}";
           
        }
    }
}
