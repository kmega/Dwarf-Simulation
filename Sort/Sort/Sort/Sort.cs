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
        public List<string> GetListNotEvenCharacter(List<string> GetCharacterChainFromList)
        {
            List<string> characterNotEven = new List<string>();
            for (int i = 0; i < GetCharacterChainFromList.Count; i++)
            {
                if (GetCharacterChainFromList[i][0] % 2 == 0)
                {
                    characterNotEven.Add(GetCharacterChainFromList[i]);
                }
            }
            return characterNotEven;
        }

        public List<string> GetListEvenCharacter(List<string> GetCharacterChainFromList)
        {
            List<string> characterEven = new List<string>();
            for (int i = 0; i < GetCharacterChainFromList.Count; i++)
            {
                if (GetCharacterChainFromList[i][0] % 2 == 1)
                {
                    characterEven.Add(GetCharacterChainFromList[i]);
                }
            }
            return characterEven;
        }

        public List<string> GetListnumber(List<string> GetCharacterChainFromList)
        {
            List<string> number = new List<string>();
            for (int i = 0; i < GetCharacterChainFromList.Count; i++)
            {
                if (int.TryParse(GetCharacterChainFromList[i], out int value))
                {
                    number.Add(GetCharacterChainFromList[i]);
                }
            }
            return number;
        }

        public List<string> GetListSpecialCharacters(List<string> GetCharacterChainFromList)
        {
            List<string> specialCharacter = new List<string>();
            for (int i = 0; i < GetCharacterChainFromList.Count; i++)
            {
                if ((GetCharacterChainFromList[i][0]  < 65  && GetCharacterChainFromList[i][0] >95)
                    && (GetCharacterChainFromList[i][0] < 97 && GetCharacterChainFromList[i][0] > 122))
                {
                specialCharacter.Add(GetCharacterChainFromList[i]);
                }
            }
            return specialCharacter;
        }
        // var allProducts = characterEven.Concat(number).Concat(characterNotEven).ToList();
        //   return allProducts;

    }
}
