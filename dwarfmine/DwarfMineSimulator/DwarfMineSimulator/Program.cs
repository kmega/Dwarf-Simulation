using System;
using DwarfMineSimulator.Simulation;

namespace DwarfMineSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            SimulationDirector simulation = 
                new SimulationDirector(new CorealateSimulation());

            simulation.ConfigureSimulation();
        }
    }
}

//30 dni lub brak krasnoludów -> symulacja konczy się raportem
//1 dzień rodzi się 10 krasnoludów zdatnych do pracy, każdy następny dzień 1/2 na jedno dziecko

//sztygar majster(po za symulacją) dysponuje gdzie krasnoludy trafiają - szyby kopalni(max 5 na szyb)
//sabotazysta zabija wszystkich w szybie
//odbudowa szybu - na natępny dzień
//1,2 lub ruchy w kopalni(wykop)

//jezeli liczba racji spadnie ponize 10 domawianych jest 30