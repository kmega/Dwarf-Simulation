using System;
using System.Collections.Generic;
using Drzewa;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
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

        [TestMethod]
        public void ReturnFirstRekordFor1Tree()
        {
            //given
            Drzewo drzewo1 = new Drzewo();

            //when
            drzewo1 = CreateData(DataFile1());

            //then

            Assert.AreEqual(drzewo1.rekords[0]._name, "Świat");
            Assert.AreEqual(drzewo1.rekords[0]._depth, 0);
            Assert.AreEqual(drzewo1.rekords[0]._path, "");
        }

        [TestMethod]
        public void ReturnLastRekordFor1Tree()
        {
            //given
            Drzewo drzewo1 = new Drzewo();

            //when
            drzewo1 = CreateData(DataFile1());

            //then

            Assert.AreEqual(drzewo1.rekords[11]._depth, 24);
            Assert.AreEqual(drzewo1.rekords[11]._name, "Głodna Ziemia");
            Assert.AreEqual(drzewo1.rekords[11]._path, "Świat|Primus|Astoria|Szczeliniec|Powiat Pustogorski|Trzęsawisko Zjawosztup|");
        }
    }
}
