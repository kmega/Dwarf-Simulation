using Dwarf_Town.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dwarf_Town
{
    public class WindowsConsole : IOutputWriter
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
