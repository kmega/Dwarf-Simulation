using System;
using System.Text;

namespace Example.Assembler
{
    public class LazyBastard
    {
        private Backpack _backpack;
        private string _type;
        private int _age;
        public LazyBastard(Backpack backpack, string type, int age)
        {
            _backpack = backpack;
            _type = type;
            _age = age;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Name: {0} - Age: {1} ", _type, _age);
            sb.Append(_backpack.ToString());
            return sb.ToString();
        }
    }
}