using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sortowanie
{
    public class SortingMachine
    {
        public string[] Sort(string[] StringArray)
        {
            string[] resultarray = new string[] { };
            string[] given = new string[] { "a", "b", "1", "7", "4", "c", "9", "d", "14", "k", "a", "1", "2" };
            List <int> numbers = new List <int> { };
            List<char> letters = new List<char> { };
            List <char> evenletters = new List <char>{ };
            List <char> oddletters = new List <char> { };
            int number;
            for (int i = 0; i < given.Length; i++)
            {
                bool success = int.TryParse(given[i], out number);
                if (success == false)
                {
                    letters.Add(char.Parse(given[i]));
              
                }
                else
                {
                    numbers.Add(int.Parse(given[i]));
                }
                
            }
            for (int i = 0; i < letters.Count; i++)
            {
                    if (letters[i] % 2 == 1)
                    {
                        evenletters.Add(letters[i]);                        
                    }
                    else
                    {
                        oddletters.Add(letters[i]);
                    }
            
            }
           
            
            //Console.WriteLine(evenletters);
            //Console.WriteLine(oddletters);
            //Console.WriteLine(numbers);
            
            
            return resultarray;
        }
    }
}
