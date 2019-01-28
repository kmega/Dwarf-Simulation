using System;

namespace IntroduceAnimal
{
    class Program
    {
        static void Main(string[] args)
        {
            AnimalFactory factory = new AnimalFactory();
            AnimalTypes bear = AnimalTypes.Bear;
            AnimalTypes pelican = AnimalTypes.Pelican;
            AnimalTypes vegetarian = AnimalTypes.Vegetarian;
            AnimalTypes killerWahle = AnimalTypes.KillerWhale;

            var newBear = factory.CreateAnimal(bear);
            

            newBear.IntroduceAnimal();
            Console.ReadKey();
        }
    }
}
