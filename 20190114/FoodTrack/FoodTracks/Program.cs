using System;
using FoodTracks.Model;

namespace FoodTracks
{
    class Program
    {
        static void Main(string[] args)
        {
            var cook = new Cook();
            var burger = cook.Create(null);
            var cashRegister = new CashRegister(new DiscountCalculator());
            // When
            var price = cashRegister.HowMuch(burger);
            // Then
            Console.WriteLine("Hello World!");
        }
    }
}
