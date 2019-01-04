using System.Collections.Generic;
using System;

namespace BrewTeaTests
{
    public class TaskOneContent
    {
        public string ContentString { get; set; }
        public List<string> ContentList { get; set; }
        public string ResultString { get; set;}
        public List<string> ResultList { get; set; }
        
        public TaskOneContent()
        {
            ContentString = @"# Nazwa herbaty, typ herbaty, temperatura parzenia, czas parzenia, specjalne własności

            Gunpowder Czarny, czarna, 90, 3, 
            Gunpowder Zielony, zielona, 70, 3, 
            Lapacho, napar, 96, 10, 
            Mięta, napar, 96, 5, 
            Sen o smoku, czarna, 96, 3, ostra: z pieprzem i imbirem
            Uśmiech Ananasa, owocowa, 96, 5, 
            Zielone Marzenie, zielona, 70, 3, ";

            ContentList = new List<string>(
                ContentString.Split(new string[] { "\r\n" },
                StringSplitOptions.None));

            ResultString = @"Zielone Marzenie, zielona, 70, 3, 
            Uśmiech Ananasa, owocowa, 96, 5, 
            Sen o smoku, czarna, 96, 3, ostra: z pieprzem i imbirem
            Mięta, napar, 96, 5, 
            Lapacho, napar, 96, 10, 
            Gunpowder Zielony, zielona, 70, 3, 
            Gunpowder Czarny, czarna, 90, 3, 

            # Nazwa herbaty, typ herbaty, temperatura parzenia, czas parzenia, specjalne własności";

            ResultList = new List<string>(
                ResultString.Split(new string[] { "\r\n" },
                StringSplitOptions.None));
        }
    }
}