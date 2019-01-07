using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    class Sort
    {
        InformationList information = new InformationList();
        public List<string> GetListNotEvenCharacter()
        {
            var listSort = information.InformationTest();
            List<string> characterNotEven = new List<string>();
            for (int i = 0; i < listSort.Count; i++)
            {
                if (listSort[i][0] % 2 == 0)
                {
                    characterNotEven.Add(listSort[i]);
                }
            }
            return characterNotEven;
        }

        public List<string> GetListEvenCharacter()
        {
            var listSort = information.InformationTest();
            List<string> characterEven = new List<string>();
            for (int i = 0; i < listSort.Count; i++)
            {
                if (listSort[i][0] % 2 == 1)
                {
                    characterEven.Add(listSort[i]);
                }
            }
            return characterEven;
        }

        public List<string> GetListnumber()
        {
            var listSort = information.InformationTest();
            List<string> number = new List<string>();
            for (int i = 0; i < listSort.Count; i++)
            {
                if (int.TryParse(listSort[i], out int value))
                {
                    number.Add(listSort[i]);
                }
            }
            return number;
        }

        public List<string> GetListSpecialCharacters()
        {
            var listSort = information.InformationTest();
            List<string> specialCharacter = new List<string>();
            for (int i = 0; i < listSort.Count; i++)
            {
                if ((listSort[i][0]  < 65  && listSort[i][0] >95)
                    && (listSort[i][0] < 97 && listSort[i][0] > 122))
                {
                specialCharacter.Add(listSort[i]);
                }
            }
            return specialCharacter;
        }
        // var allProducts = characterEven.Concat(number).Concat(characterNotEven).ToList();
        //   return allProducts;

    }
}
