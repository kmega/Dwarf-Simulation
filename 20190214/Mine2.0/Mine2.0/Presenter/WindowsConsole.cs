using System;

namespace Mine2._0
{
    public class WindowsConsole : IOutputWriter
    {
        public void WriteLine(string information)
        {
            Console.WriteLine(information);
        }
    }
}