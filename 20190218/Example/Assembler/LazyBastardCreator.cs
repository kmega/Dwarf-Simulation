namespace Example.Assembler
{
    public class LazyBastardCreator
    {
        private int _age;
        private string _type;
        private readonly Backpack _backpack = new Backpack();
        public LazyBastardCreator AddPepper(int i)
        {
            _backpack.AddPepper(i);
            return this;
        }
        public LazyBastardCreator AddSalt(int i)
        {
            _backpack.AddSalt(i);
            return this;
        }
        public LazyBastardCreator AddMilk(int i)
        {
            _backpack.AddMilk(i);
            return this;
        }
        public LazyBastardCreator AddEggz(int i)
        {
            _backpack.AddEggz(i);
            return this;
        }

        public LazyBastardCreator WithType(string type)
        {
            _type = type;
            return this;
        }
        public LazyBastardCreator WithAge(int age)
        {
            _age = age;
            return this;
        }

        public LazyBastard Build()
        {
            return new LazyBastard(_backpack, _type, _age);
        }
    }
}