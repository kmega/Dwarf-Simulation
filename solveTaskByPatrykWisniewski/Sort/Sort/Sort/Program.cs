using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            MergeList mergeList = new MergeList();
            var list = mergeList.MergeList1();

            Sort getSort = new Sort();
            InformationList information = new InformationList();
            var list1 = getSort.GetListSpecialCharacters(information.InformationTest());
            Console.ReadKey();
        }
    }
}
