using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace happy_path_creation_training
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] result = FileOperations.ReturnStringArrayFromFile("1807-fryderyk-komciur.md");

            string result2 = FileOperations.ReturnProfileNameAndBuildTime(result);

        }
    }

        
}
