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
            Console.WriteLine("how many fathers born: " + Raport.FatherBorn);
            Console.WriteLine("how many single born: " + Raport.SingleBorn);
            Console.WriteLine("how many lazy born: " + Raport.LazyBorn);
            Console.WriteLine("how many suicider born: " + Raport.SuiciderBorn);
            Console.WriteLine("Total born: " + Raport.TotalBorn);
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
