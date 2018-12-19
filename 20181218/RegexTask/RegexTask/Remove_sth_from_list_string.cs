using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegexTask
{
    class Remove_sth_from_list_string
    {
        public List<string> remover(List<string> old_list)
        {
            List<string> new_list = new List<string>();
            
            foreach (var item in old_list)
            {
                if (!item.Contains("template.md"))
                {
                    new_list.Add(item);
                }
            }


            return new_list;
        }
    }
}
