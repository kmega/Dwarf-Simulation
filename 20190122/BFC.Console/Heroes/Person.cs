using System.Collections.Generic;
using BFC.Console.Animals;

namespace BFC.Console.Heroes
{
    public interface Person
    {
        void RescuAnimals(IList<Animal> branch);
    }
}
