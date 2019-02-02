using System;
using System.Collections.Generic;
using System.Linq;

namespace Drzewa
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Location> lista = new List<Location>();

            string test = "Świat|" +
                " Primus|" +
                "  Astoria|" +
                "   Szczeliniec|"+
            "    Powiat Pustogórski|" +
            "     Pustogor|" +
            "      Gabinet Pięknotki|" +
            "     Zaczęstwo|" +
            "      Cyberszkoła|" +
            "      Osiedle Ptasie|" +
            "     Trzęsawisko Zjawosztup|" +
            "      Głodna Ziemia";
            string test2 = "Świat| Primus|  Astoria, Asteroidy";
            string test3 = "Świat|" +
                 " Primus|" +
                 "  Astoria|" +
            "   Szczeliniec|" +
            "    Powiat Pustogórski|" +
            "     Zaczęstwo|" +
            "      Kasyno Marzeń|" +
            "      Szkoła Magów";
            string test4 = "Świat|" +
                " Esuriit|" +
                "  Astoria|" +
                "   Szczeliniec";



            string[] parse = test.Split('|');
            for (int i = 0; i < parse.Length; i++)
            {
                Location temp = new Location(parse[i],parse, i);
                if (lista.Count == 0)
                {
                    lista.Add(temp);


                }
                else
                {
                    for (int j=0;j<lista.Count;j++)
                      
                        if (!(lista.Exists(k => (k.name == temp.name)&&(k.path==temp.path))))
                        {
                            lista.Add(temp);
                        }


                    }
                }
            

         parse = test2.Split('|');
            for (int i = 0; i<parse.Length; i++)
            {
                Location temp = new Location(parse[i], parse, i);

                    for (int j=0;j<lista.Count;j++)

                    if (!(lista.Exists(k => (k.name == temp.name) && (k.path == temp.path))))
                    {
                            lista.Add(temp);
                        }


                    }
                

            parse = test3.Split('|');
            for (int i = 0; i < parse.Length; i++)
            {
                Location temp = new Location(parse[i],parse, i);

                
                    for (int j = 0; j < lista.Count; j++)

                    if (!(lista.Exists(k => (k.name == temp.name) && (k.path == temp.path))))
                    {
                            lista.Add(temp);
                        }
                
            }


            parse = test4.Split('|');
            for (int i = 0; i < parse.Length; i++)
            {
                Location temp = new Location(parse[i], parse, i);


                for (int j = 0; j < lista.Count; j++)

                    if (!(lista.Exists(k => (k.name == temp.name) && (k.path == temp.path))))
                    {
                        lista.Add(temp);
                    }

            }

            lista = lista.OrderBy(i => i.path).ToList();
            foreach (var item in lista)
            {
                Console.WriteLine(item.ToString());
                    
            }


            Console.ReadKey();
        }
    }
}
