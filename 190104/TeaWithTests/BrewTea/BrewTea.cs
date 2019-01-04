using System;
using System.Collections.Generic;

namespace BrewTea
{
    public class Task0ne
    {
        // given
        // read from file

        // then
        // reverse content

        // expected
        // file with reverse order
        string content = @"# Nazwa herbaty, typ herbaty, temperatura parzenia, czas parzenia, specjalne własności

            Gunpowder Czarny, czarna, 90, 3, 
            Gunpowder Zielony, zielona, 70, 3, 
            Lapacho, napar, 96, 10, 
            Mięta, napar, 96, 5, 
            Sen o smoku, czarna, 96, 3, ostra: z pieprzem i imbirem
            Uśmiech Ananasa, owocowa, 96, 5, 
            Zielone Marzenie, zielona, 70, 3, 
            ";

        List<string> teas;

        public Task0ne()
        {
            teas = new List<string>(
                content.Split(new string[] { "\r\n" },
                StringSplitOptions.None));
        }

        public List<string> Run()
        {
            teas.Reverse();
            return teas;
        }
    }

    class BrewTea
    {
        static void Main(string[] args)
        {
            Task0ne taskone = new Task0ne();
            taskone.Run();
        }
    }
}
