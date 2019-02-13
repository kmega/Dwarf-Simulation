using System;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("DwarfSimulationTests")]

namespace DwarfSimulation
{
    class Program
    {
        static void Main(string[] args)
        {
            // PrepareSimulation.CreateDwarfs => List<dwarfs> dwarfs
            // PrepareSimulation.PrepareShafts => List<Shaft> shafts
            // PrepareSimulation.CreateRaport -> raportObject
            // Simulation(shafty, dwarfy,raportObject) => Start

            // Hospital(lista krasnali, raportObject) -> //     ## 1 dzień ## zwraca 0 dwarfów    ## kolejne born kransnala 1% => RETURN list of DwarVes
            // Mines(shafty,krasnale,raportObject) -> updated list of dwarfs, updated backpacks       => RETURN list of DwarVes
            // Guild(backpack,wallet,raportObject) -> update backpacks - zerowanie + wallets update   => RETURN list of DwarVes
            // Graveyard(krasnale,raportObject) -> update dwarfs                                      => RETURN list of DwarVes
            // diningRoom(krasnale,raportObject) -> count foodEaten                                   
            // shop(buystrategy,raportObject) -> update products + wallet update                      => RETURN list of DwarVes
            // bank? (lista krasnali,wallet) => update konta,zerowanie wallet                         => RETURN list of DwarVes





            Console.ReadKey();
        }

        //static void BetterMain()
        //{
        //    Report r = new Report();

        //    PrepareSimulation();

        //    City1(r)
        //        Building2(r)
        //}
    }
}
