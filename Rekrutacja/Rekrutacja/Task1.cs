using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rekrutacja
{
    class Task1
    {
        public void task()
        {
            FileOpp fileopp = new FileOpp();
            string[] filetext = fileopp.FileText("tea-data.txt");

            DisplayResult display = new DisplayResult();
            display.Display(filetext);

            Console.WriteLine();
            Reverse_Records reverse = new Reverse_Records();
            string[] reverse_text = reverse.Reverse(filetext);
            display.Display(reverse_text);

            fileopp.Saver("result-1.txt", reverse_text);
        }
    }
}
