using System.Collections.Generic;
using System.Text;
using ConsoleApp3;

namespace Example.Assembler
{
    public enum Ingridjentz
    {
        Pepper,
        Salt,
        Milk,
        Eggz
    }
    public class Backpack
    {
        private readonly Dictionary<Ingridjentz, int> _content = new Dictionary<Ingridjentz, int>();
        public void AddPepper(int i)
        {
            _content.Add(Ingridjentz.Pepper, i);
        }
        public void AddSalt(int i)
        {
            _content.Add(Ingridjentz.Salt, i);
        }
        public void AddMilk(int i)
        {
            _content.Add(Ingridjentz.Milk, i);
        }
        public void AddEggz(int i)
        {
            _content.Add(Ingridjentz.Eggz, i);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var row in _content)
            {
                sb.AppendFormat("{0} - {1}", row.Key, row.Value);
            }

            return sb.ToString();
        }
    }
}