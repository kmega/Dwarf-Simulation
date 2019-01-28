namespace IntroduceAnimal
{
    public class Animal : IDisplayAnimalInfo
    {
        private string _name;
        private string _eatingStyle;
        private string _movementStyle;

        public void SetName(string name)
        {
            _name = name;
        }
        public void SetEatingStyle(string eatingStyle)
        {
            _eatingStyle = eatingStyle;
        }
        public void SetMovementStyle(string movementStyle)
        {
            _movementStyle = movementStyle;
        }

        public void IntroduceAnimal()
        {
            System.Console.WriteLine("I am {0}, I am {1} and I am {2}", _name,_eatingStyle,_movementStyle);
        }

        public string GetName()
        {
            return _name;
        }
        public string GetEatingStyle()
        {
            return _eatingStyle;
        }
        public string GetMovementStyle()
        {
            return _movementStyle;
        }
    }
}