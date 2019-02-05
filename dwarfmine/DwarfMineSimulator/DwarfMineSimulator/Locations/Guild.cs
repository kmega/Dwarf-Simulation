using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfMineSimulator
{
    class Guild
    {
        public List<Dwarf> HowMuchDwarfEarnedMoney(List<Dwarf> DwarfsPopulation)
        {
            for (int i = 0; i < DwarfsPopulation.Count; i++)
            {
                Random priceForRawMaterials = new Random();
                int howMuchGold, howMuchMithril, howMuchTrainedGold, howMuchSilver;
                CheckHowMuchDwarfGetMinerals(DwarfsPopulation, i, out howMuchGold, out howMuchMithril, out howMuchTrainedGold, out howMuchSilver);
                
                //mithril 15 - 25j, zoto 10 - 20j, srebro 5 - 15, brudne zoto 2
                int earnedMoney = HowMuchMonetDwarfsGet(priceForRawMaterials, howMuchGold, howMuchMithril, howMuchTrainedGold, howMuchSilver);

                DwarfsPopulation[i].MoneyEarndedThisDay = earnedMoney;
                DwarfsPopulation[i].Money += earnedMoney;

                SetMaterialstozero(DwarfsPopulation, i);
            }
            return DwarfsPopulation;
        }

        private static int HowMuchMonetDwarfsGet(Random priceForRawMaterials, int howMuchGold, int howMuchMithril, int howMuchTrainedGold, int howMuchSilver)
        {
            int priceMithril = priceForRawMaterials.Next(15, 26);
            int priceGold = priceForRawMaterials.Next(10, 21);
            int priceSilver = priceForRawMaterials.Next(5, 16);
            int earnedMoney = (howMuchGold * priceGold) + (howMuchMithril * priceMithril)
                + (howMuchSilver * priceSilver) + (howMuchTrainedGold * 2);
            return earnedMoney;
        }

        private static void CheckHowMuchDwarfGetMinerals(List<Dwarf> DwarfsPopulation, int i, out int howMuchGold, out int howMuchMithril, out int howMuchTrainedGold, out int howMuchSilver)
        {
            howMuchGold = DwarfsPopulation[i].MineralsMined[Minerals.Gold];
            howMuchMithril = DwarfsPopulation[i].MineralsMined[Minerals.Mithril];
            howMuchTrainedGold = DwarfsPopulation[i].MineralsMined[Minerals.TaintedGold];
            howMuchSilver = DwarfsPopulation[i].MineralsMined[Minerals.Silver];
        }

        private static void SetMaterialstozero(List<Dwarf> DwarfsPopulation, int i)
        {
            DwarfsPopulation[i].MineralsMined[Minerals.Gold] = 0;
            DwarfsPopulation[i].MineralsMined[Minerals.Mithril] = 0;
            DwarfsPopulation[i].MineralsMined[Minerals.Silver] = 0;
            DwarfsPopulation[i].MineralsMined[Minerals.TaintedGold] = 0;
        }
    }
}