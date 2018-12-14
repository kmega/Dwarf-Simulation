using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen
{
    class Program
    {
        static void Main(string[] args)
        {


            //Użytkownik -> nazwisko, zamowienie
            Klient klient = new Klient();
            klient.First_Name = name_client.Adam.ToString();
            klient.Second_Name = second_name_client.Smith.ToString();

            //nazwisko -> alergie[]

            string alergia = Alergic.List_Bad_Indigriends(Klient.Adam_Smith.ToString());

            Console.WriteLine(alergia);
           
            //zamowienie -> składniki[]

            string food = Food_Indigriends.List_Indigriends(Food.Emperor_Chicken.ToString());
            Console.WriteLine(food);

            //porownaniee aleri i składników

            CompareList.Result(food, alergia);
            Console.ReadKey();
            //wyświetlenie rezultatu


        }
    }
}
