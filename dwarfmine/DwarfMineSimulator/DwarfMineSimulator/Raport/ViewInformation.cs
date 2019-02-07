using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfMineSimulator
{
    class ViewInformation
    {
        public void ViewBirthInformation()
        {
            Console.WriteLine("## Born dwarfs ##");
            Console.WriteLine("how many fathers born: " + Simulation.FatherBorn);
            Console.WriteLine("how many single born: " + Simulation.SingleBorn);
            Console.WriteLine("how many lazy born: " + Simulation.LazyBorn);
            Console.WriteLine("how many suicider born: " + Simulation.SuiciderBorn);
            Console.WriteLine("Total born: " + Simulation.TotalBorn);
            Console.WriteLine("");
        }

        public void ViewMoneyAndTaxFromGuild(decimal sumMoney, decimal sumTax)
        {
            Console.WriteLine("");
            Console.WriteLine("## Money and taxed from guild ##");
            Console.WriteLine("Total money earned:" + sumMoney);
            Console.WriteLine("Total money from tax guild" + sumTax);
        }
    }
}
