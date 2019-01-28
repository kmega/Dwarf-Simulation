using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalSimulator
{
    class WindowsConsole : IOutputWritter
    {
        public void WriteLine(string information)
        {
            Console.WriteLine(information);
        }
    }
}
