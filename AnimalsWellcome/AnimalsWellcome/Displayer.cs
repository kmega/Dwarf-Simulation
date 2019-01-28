namespace AnimalsWellcome
{
    internal class Displayer : IAnimalDisplayer
    {
        public void Display(Animal animal)
        {
            System.Console.WriteLine($"I am {animal.Type}, i eat {animal.Meal} and i can {animal.Attribute}");
        }
    }
}