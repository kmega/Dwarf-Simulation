using System;
using static AnimalsWellcome.Enums;

namespace AnimalsWellcome
{
    class Program
    {
        static void Main(string[] args)
        {
            AnimalsFactory Factory = new AnimalsFactory();
            Displayer AnimalDisplayer = new Displayer();

            Animal Bear = Factory.Create("Bear", Meal.All, Attributes.Walk);
            Animal Pelican = Factory.Create("Pelican", Meal.Fish, Attributes.Fly);
            Animal Vegetarian = Factory.Create("Vegetarian", Meal.Vegetables, Attributes.Walk);
            Animal Plowing = Factory.Create("Plowing", Meal.Meat, Attributes.Fly);



            AnimalDisplayer.Display(Bear);
            AnimalDisplayer.Display(Pelican);
            AnimalDisplayer.Display(Vegetarian);
            AnimalDisplayer.Display(Plowing);



            Console.ReadKey();
        }
    }
}
