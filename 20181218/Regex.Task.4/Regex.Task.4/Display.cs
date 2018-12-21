using System;
using System.Collections.Generic;

namespace Task4
{
    partial class MainClass
    {
        class Display
        {
            public void PresentOutput(string magdaName, List<string> contentsWithMagdaPatril)
            {
                Console.WriteLine("{0} występowała w następujących Opowieściach:", magdaName);
                Console.WriteLine();
                foreach (string item in contentsWithMagdaPatril)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
