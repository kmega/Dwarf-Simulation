using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rekrutacja
{
    class Task2
    {
        public void task()
        {
            FileOpp fileopp = new FileOpp();
            string[] filetext = fileopp.FileText("tea-data.txt");

            DisplayResult display = new DisplayResult();
            display.Display(filetext);

            TeaCreator creator = new TeaCreator();
            List<Tea> teas = new List<Tea>();
            teas = creator.Creator(filetext);

            teas.ForEach(Console.WriteLine);
            

        }


    }
}
