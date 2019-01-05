using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tea
{
   public class TeaBuilder
    {
        public List<TeaObj> CreateListofTeas (List<string> teafile)
        {
            List<TeaObj> listoftea = new List<TeaObj>();
            foreach (var item in teafile)
            {
                if (!(item == "") && !(item.StartsWith("#")))
                {
                    listoftea.Add(AddTea(item));
                }
            }
            return listoftea;
        } 


        public TeaObj AddTea (string tea)
        {
            string[]parts =tea.Split(new string[] { ", " }, StringSplitOptions.None);
            TeaObj newtea = new TeaObj(parts[0], parts[1], Double.Parse(parts[2]), Double.Parse(parts[3]));
            return newtea;
        }
    }
}
