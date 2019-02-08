using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfMineSimulator
{
    class ViewInformation
    {
        public void ViewBirthInformation(int dailyRaportBornFather, int dailyRaportBornLazy,
            int dailyRaportBornSingle, int dailyRaportBornSuicider)
        {
            Console.WriteLine("## HOSPITAL ##\n");

            Console.WriteLine("how many fathers born: " + dailyRaportBornFather);
            Console.WriteLine("how many single born: " + dailyRaportBornSingle);
            Console.WriteLine("how many lazy born: " + dailyRaportBornLazy);
            Console.WriteLine("how many suicider born: " + dailyRaportBornSuicider);
            Console.WriteLine("Total born: " + (dailyRaportBornSuicider+ dailyRaportBornLazy
                + dailyRaportBornSingle+ dailyRaportBornFather));
            Console.WriteLine("");
        }

        public void ViewMoneyAndTaxFromGuild(decimal sumMoney, decimal sumTax)
        {
            Console.WriteLine("\n## GUILD ##\n");
            Console.WriteLine("Total money earned:" + sumMoney);
            Console.WriteLine("Total money from tax guild" + sumTax);
        }
    }
}
