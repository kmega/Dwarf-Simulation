using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenKitchen
{
    class Program
    {
        static void Main(string[] args)
        {
            //0.) Stworzenie Klienta ( Przedstawienie klienta i podanie swoich alergii)
            Client Adam_Smith = new  Client();
            //1.) Przyjęcie zamówienia
            Meal order = new Meal(Enums.Meal.Fries);
            //2.) Sprawdzenie czy osoba zamawiająca nie jest uczulona na składnik jej potrawy
            bool result = CheckingAllergens(Adam_Smith, Enums.AllergicBase.Potatoes);
            //3.) Jeśli osoba uczulona na składnik podanie komunikatu, że nie może zjeść tego posiłku
            //3.) Jeśli osoba nie jest uczulona na żaden składnik, podanie dania
        }

        private static bool CheckingAllergens(Client person, Enums.AllergicBase baseOfAllergy)
        {
            return true;
        }
    }
}
