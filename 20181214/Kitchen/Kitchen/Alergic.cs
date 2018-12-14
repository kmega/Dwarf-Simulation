using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen
{
    class Alergic
    {
        public static Dictionary<Klient, List<string>> Alergia;

        Dictionary<Klient, List<Ingridents>> = new Dictionary<Klient, List<Ingridents>>()
            {
                {new Klient}
            }

        public static string List_Bad_Indigriends(string client)
        { 
            Alergia = new Dictionary<Klient, List<Ingridents>();
            Alergia.Add(Klient.Adam_Smith.ToString(), Ingridents.Chicken.ToString());



            return Alergia[client].ToString();
        }
    }
}
