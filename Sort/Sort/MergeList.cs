using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    class MergeList
    {
        public List<string> MergeList1()
        {
            Sort getSort = new Sort();
            InformationList information = new InformationList();
            var notEvenCharacters = getSort.GetListNotEvenCharacter(information.InformationTest());
            var evenCharacters = getSort.GetListEvenCharacter(information.InformationTest());
            var number = getSort.GetListnumber(information.InformationTest());
            var finalList = evenCharacters.Concat(number).Concat(notEvenCharacters).ToList();
            return finalList;
        }

        public List<string> MergeListTask2()
        {
            Sort getSort = new Sort();
            InformationList information = new InformationList();
            var notEvenCharacters = getSort.GetListNotEvenCharacter(information.InformationTest());
            var evenCharacters = getSort.GetListEvenCharacter(information.InformationTest());
            var number = getSort.GetListnumber(information.InformationTest());
            var specialCharacteres = getSort.GetListSpecialCharacters(information.InformationTest());
            var finalList = evenCharacters.ToList();
            finalList = evenCharacters.ToList();
            //
            //finalList.AddRange(notEvenCharacters);
            //zapytac się jak to zrobić w lepszy sposob niz forami 
            return finalList;
        }
    }
}
