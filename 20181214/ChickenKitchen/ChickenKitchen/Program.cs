using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChickenKitchen
{
    partial class Program
    {
        static void Main(string[] args)
        {
            // 1. napisać działającą aplikację dla jednego klienta, 
            // bez alergii, tylko ze składników bazowych
            // 2. stworzyć listę klientów
            // 3. stworzyć listę składników bazowych
            // 4. stworzyć listę dań

            //1. Pobierz urzytkownika
            //2. Pobierz zamówione danie
            //3. 
            string fries = "Fries";
            string name = "Adam";

            Console.WriteLine("podaj nazwę użytkownika: ");
            string Client = Console.ReadLine();
            Console.WriteLine("podaj zamówienie: ");
            string Order = Console.ReadLine();

            if(Order == fries && Client == name)
            {
                Console.WriteLine("Brawo " + Client + " zjedał frytki!, kosztowało mnie to " + Order.Count() + " ziemniaków" );
            }

           // Clients Adam = new Clients("Adam Smith", Werehouse.Potatoes);


            Console.ReadLine();

        }
    }
}
