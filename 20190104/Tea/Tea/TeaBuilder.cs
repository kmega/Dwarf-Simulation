using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tea
{
    public class TeaBuilder
    {
        public TeaObj AddTea (string tea)
        {
            string [] parts = tea.Split(new string[] { ", " }, StringSplitOptions.None);
            TeaObj newtea = new TeaObj(parts[0], parts[1], Int32.Parse(parts[2]), Int32.Parse(parts[3]));
            return newtea;
        }

    }
}
