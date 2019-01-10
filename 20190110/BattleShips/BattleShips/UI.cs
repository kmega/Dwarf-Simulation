using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShips
{
    public class UI
    {
        public int boardsize = 10;
        public UI()
        {
            GameRules();
            Console.WriteLine();
            ChooseTypeOfShip();
            Console.WriteLine();
            BoardGenerate();
            Console.ReadKey();
        }


        //zasady gry 
        public void GameRules()
        {
            Console.WriteLine("ZASADY GRY \nKażdy z graczy posiada po dwie plansze o wielkości 10x10 pól.\n" +
                "Kolumny są oznaczone poprzez współrzędne literami od A do J i liczbami 1 do 10. \n" +
                "Na jednym z kwadratów gracz zaznacza swoje statki, których położenie będzie odgadywał przeciwnik. \n" +
                "Na drugim zaznacza trafione statki przeciwnika i oddane przez siebie strzały. \n" +
                "Statki ustawiane są w pionie lub poziomie, w taki sposób, aby nie stykały się one ze sobą ani bokami, ani rogami.\n" + 
                "Trafienie okrętu przeciwnika polega na strzale, który jest odgadnięciem położenia jakiegoś statku.\n" +
                "Strzały oddawane są naprzemiennie, poprzez podanie współrzędnych pola(np.B5).\n" +
                "W przypadku strzału trafionego, gracz kontynuuje strzelanie(czyli swój ruch) aż do momentu chybienia.\n" +
                "Zatopienie statku ma miejsce wówczas, gdy gracz odgadnie położenie całego statku.\n" +
                "O chybieniu interfejs informuje użytkownika słowem „Pudło”, o trafieniu „Trafiony” lub „(Trafiony)Zatopiony”.\n" +
                "Wygrywa ten, kto pierwszy zatopi wszystkie statki przeciwnika.");
         
        }


        //jak wprowadzac statek

        public void ChooseTypeOfShip()
        {
            Console.WriteLine("Wybierz rodzaj statku, który chcesz zamieścić na planszy: (Wpisz odpowiednią literę\n" +
                "A- CARRIER (pięciomasztowiec o wielkości 5 pól)\n" +
                "B- BATTLESHIP (czteromasztowiec o wielkości 5 pól) \n" +
                "D- DESTROYER (trzymasztowiec o wielkości 3 pól)\n" +
                "S- SUBMARINE (trzymasztowiec o wielkości 3 pól)\n" +
                "P- PATROL BOAT (dwumasztowiec o wielkości 2 pól)");
        }

        // pusta plansza

        public void BoardGenerate()
        {
            List<int> Numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
       
            Console.Write(" _________________________________________");
            Console.WriteLine();
            Console.Write(" | A | B | C | D | E | F | G | H | I | J |");
            Console.WriteLine();
            for (int i = 0; i < 2*boardsize; i++)
            {
                Console.Write(" |");
               
               
                    for (int j = 0; j < boardsize  ; j++)
                    {
                    if ( i % 2 != 0)
                    {


                        Console.Write(" *" + " |");
                    }
                    else
                    { Console.Write("----"); }
                    }
                    Console.WriteLine();                         
            }
            Console.Write(" _________________________________________");
            //DODAC LICZBY !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        }
        // wybierz statek / prawo lewo pole
        //czy wybrales dobre pole - wybierz jeszcze raz
        //nie mozesz wybrac statku w polu obok
        //pokaż plansze/ twoja/przeciwnika
        // strzal
        //zmien strzal na symbol
        //jezeli pole sie powtorzy juz tam strzelales
        //koncza sie statki - wygrales/przegrales endgame

    }
}

