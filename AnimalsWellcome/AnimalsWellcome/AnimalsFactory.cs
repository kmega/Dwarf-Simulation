namespace AnimalsWellcome
{
    public class AnimalsFactory : IAnimalsFactory
    {
        public Animal Create(string type, Enums.Meal meal, Enums.Attributes attribute)
        {
            return new Animal(type, meal, attribute);
        }
    }
}