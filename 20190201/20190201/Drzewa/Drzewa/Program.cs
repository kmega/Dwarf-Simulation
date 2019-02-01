using System;
using System.Collections.Generic;

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
                "   Szczeliniec|" +
                "    Powiat Pustogórski|" +
                "     Pustogor|" +
                "      Gabinet Pięknotki|" +
                "     Zaczęstwo|" +
                "      Cyberszkoła|" +
                "      Osiedle Ptasie|" +
                "     Trzęsawisko Zjawosztup|" +
                "      Głodna Ziemia";
            string test2 = "Świat| Estrinus";
           string  test3 = "Świat| Estrinus";



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
                      
                        if (!(lista.Exists(k => k.name == temp.name)))
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
                      
                        if (!(lista.Exists(k => k.name == temp.name)))
                        {
                            lista.Add(temp);
                        }


                    }
                

            parse = test3.Split('|');
            for (int i = 0; i < parse.Length; i++)
            {
                Location temp = new Location(parse[i],parse, i);

                
                    for (int j = 0; j < lista.Count; j++)

                        if (!(lista.Exists(k => k.name == temp.name)))
                        {
                            lista.Add(temp);
                        }
                
            }

            
           foreach (var item in lista)
            {
                Console.WriteLine(item.depth + " " + item.name + "     " + item.path);
                    
            }


            Console.ReadKey();
        }
    }
}
