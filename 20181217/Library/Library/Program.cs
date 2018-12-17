using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{


    class Program
    {

        public static void readBook(List<string> booksfromonetype, List<string> bookreaded)
        {


            foreach (var item in booksfromonetype)
            {
                
                    if (!(bookreaded.Equals(item)))
                    {
                        Console.WriteLine("Przeczytano {0}", item);
                        bookreaded.Add(item);
                        break;
                    }
                
            }
        }


        static void Main(string[] args)
        {

            List<List<string>> biblioteka = new List<List<string>>();

            List <string> ksiazkiFantasy = new List<string>()
            {
                "Lód",
                "Czarne oceany"
            } ;
            List<string> ksiazkiHorror = new List<string>
            {
                "Frankenstein",
                "Koszmar z Ulicy Wiązów"

            };

            biblioteka.Add(ksiazkiFantasy);
            biblioteka.Add(ksiazkiHorror);

            List<string> ksiazkiPrzeczytane = new List<string>() {

                "Pan Lodowego Ogrodu"
            };


            readBook(ksiazkiFantasy, ksiazkiPrzeczytane);

            Console.ReadKey();
            

        }

       
    }
}
