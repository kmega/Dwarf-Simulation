namespace BFC.Console.Animals
{
    public sealed class Animal
    {
        private string _name;
        public bool shouldIBeSaved { get; set; }
        

        public Animal(string name, AnimalTypes animalType, bool ShouldIBeSaved = true)
        {
            _name = name;
            AnimalType = animalType;
            shouldIBeSaved = ShouldIBeSaved;
        }

        public AnimalTypes AnimalType { get; private set; }

        public override string ToString()
        {
            return _name;
        }

    }
}