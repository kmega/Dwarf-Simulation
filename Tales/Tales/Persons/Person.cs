using System;
using System.Collections.Generic;
using System.Text;

namespace Tales.Persons
{
    class Person : IPerson
    {
        public int CreationTime { get; set; }
        public string Name { get; set; }
    }
}
