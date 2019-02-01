using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drzewa
{
    class Program
    {
        static void Main(string[] args)
        {

            Drzewo drzewo1 = new Drzewo();
            drzewo1 = CreateData(DataFile1());

            Drzewo drzewo2 = new Drzewo();
            drzewo2 = CreateData(DataFile2());

            Drzewo drzewo3 = new Drzewo();
            drzewo3 = CreateData(DataFile3());

            Drzewo drzewo4 = new Drzewo();
            drzewo4 = CreateData(DataFile4());

            Drzewo result = new Drzewo();

            result.rekords = AddRekords(drzewo1, drzewo2);
            result.rekords = AddRekords(drzewo1, drzewo3);
            result.rekords = AddRekords(drzewo1, drzewo4);

           


            Console.ReadKey();
        }


        static List<string> DataFile1()
        {
            List<string> drzewo1 = new List<string>()
            {
                "1. Świat",
                "    1. Primus",
                "        1. Astoria",
                "            1. Szczeliniec",
                "                1. Powiat Pustogorski",
                "                    1. Pustogor",
                "                        1. Gabinet Pięknotki",
                "                    1. Zaczęstwo",
                "                        1. Cyberszkoła",
                "                        1. Osiedle Ptasie",
                "                    1. Trzęsawisko Zjawosztup",
                "                        1. Głodna Ziemia"
            };

            return drzewo1;
        }

        static List<string> DataFile2()
        {
            List<string> drzewo2 = new List<string>()
            {
                "1. Świat",
                "    1. Primus",
                "        1. Astoria, Asteroidy"
            };

            return drzewo2;
        }

        static List<string> DataFile3()
        {
            List<string> drzewo3 = new List<string>()
            {
                "1. Świat",
                "    1. Primus",
                "        1. Astoria",
                "            1. Szczeliniec",
                "                1. Powiat Pustogorski",
                "                    1. Zaczęstwo",
                "                        1. Kasyno Marzeń",
                "                        1. Szkoła Magów"
            };

            return drzewo3;
        }

        static List<string> DataFile4()
        {
            List<string> drzewo4 = new List<string>()
            {
                "1. Świat",
                "    1. Esuriit",
                "        1. Astoria",
                "            1. Szczeliniec"
            };

            return drzewo4;
        }

        static Drzewo CreateData(List<string> list)
        {
            Drzewo drzewo = new Drzewo();
            for (int i = 0; i < list.Count; i++)
            {
                if (i != 0)
                {
                    int depth = list[i].IndexOf('1');
                    string name = list[i].Substring(depth + 3);
                    string path = "";
                    for (int j = drzewo.rekords.Count; j > 0; j--)
                    {
                        if (depth > drzewo.rekords[j - 1]._depth)
                        {
                            path += drzewo.rekords[j - 1]._path + drzewo.rekords[j - 1]._name + "|";
                            break;
                        }
                    }
                    drzewo.rekords.Add(new Rekord(name, path, depth));
                }
                else
                {
                    int depth = list[i].IndexOf('1');
                    string name = list[i].Substring(depth + 3);
                    drzewo.rekords.Add(new Rekord(name, "", depth));

                }
            }

            return drzewo;
        }

        static List<Rekord>  AddRekords(Drzewo drzewo1, Drzewo drzewo2)
        {
            bool flag = true;
            foreach (var rekord2 in drzewo2.rekords)
            {
                for (int i = 0; i < drzewo1.rekords.Count; i++)
                {
                    if (rekord2._name == drzewo1.rekords[i]._name && rekord2._path == drzewo1.rekords[i]._path)
                    {
                        flag = false;
                    }
                }

                if (flag)
                {
                    drzewo1.rekords.Add(rekord2);
                }
                flag = true;
            }

            List<Rekord> rekords = new List<Rekord>();
            List <Rekord> SortedList = drzewo1.rekords.OrderBy(o => o._path).ToList();
            return SortedList;
        }


    }
}
