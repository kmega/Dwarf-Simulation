using System;
using System.Collections.Generic;
using System.Text;

namespace RecruitmentTasksTests
{
    class AllFileStringInList
    {
        public List<string> teasStr = new List<string>();
        public List<string> teasStrRev = new List<string>();

        public AllFileStringInList()
        {
            teasStr.Add("# Nazwa herbaty, typ herbaty, temperatura parzenia, czas parzenia, specjalne własności");
            teasStr.Add("");
            teasStr.Add("Gunpowder Czarny, czarna, 90, 3, ");
            teasStr.Add("Gunpowder Zielony, zielona, 70, 3, ");
            teasStr.Add("Lapacho, napar, 96, 10,");
            teasStr.Add("Mięta, napar, 96, 5,");
            teasStr.Add("Sen o smoku, czarna, 96, 3, ostra: z pieprzem i imbirem");
            teasStr.Add("Uśmiech Ananasa, owocowa, 96, 5,");
            teasStr.Add("Zielone Marzenie, zielona, 70, 3, ");

            teasStrRev.Add("Zielone Marzenie, zielona, 70, 3, ");
            teasStrRev.Add("Uśmiech Ananasa, owocowa, 96, 5,");
            teasStrRev.Add("Sen o smoku, czarna, 96, 3, ostra: z pieprzem i imbirem");
            teasStrRev.Add("Mięta, napar, 96, 5,");
            teasStrRev.Add("Lapacho, napar, 96, 10,");
            teasStrRev.Add("Gunpowder Zielony, zielona, 70, 3, ");
            teasStrRev.Add("Gunpowder Czarny, czarna, 90, 3, ");
            teasStrRev.Add("");
            teasStrRev.Add("# Nazwa herbaty, typ herbaty, temperatura parzenia, czas parzenia, specjalne własności");

        }
    }
}
