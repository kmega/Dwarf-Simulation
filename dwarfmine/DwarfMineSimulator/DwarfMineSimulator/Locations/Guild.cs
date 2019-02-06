using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfMineSimulator
{
    class Guild
    {
        public List<Dwarf> HowMuchDwarfEarnedMoney(List<Dwarf> DwarfsPopulation)
        {
            decimal sumMoney = 0;
            decimal sumTax = 0;
            for (int i = 0; i < DwarfsPopulation.Count; i++)
            {
                Random priceForRawMaterials = new Random();
                int howMuchGold, howMuchMithril, howMuchTrainedGold, howMuchSilver;
                CheckHowMuchDwarfGetMinerals(DwarfsPopulation, i, out howMuchGold, out howMuchMithril, out howMuchTrainedGold, out howMuchSilver);
                
                //mithril 15 - 25j, zoto 10 - 20j, srebro 5 - 15, brudne zoto 2
                decimal earnedMoney = HowMuchMonetDwarfsGet(priceForRawMaterials, howMuchGold, howMuchMithril, howMuchTrainedGold, howMuchSilver);
                decimal taxMoney = earnedMoney * 0.25m;
                earnedMoney -= taxMoney;
                Simulation.TotalMoneyEarned += earnedMoney;
                Simulation.TaxedMoney += taxMoney;
                sumMoney += earnedMoney;
                sumTax += taxMoney;
                DwarfsPopulation[i].MoneyEarndedThisDay = earnedMoney;
                DwarfsPopulation[i].Money += earnedMoney;

                SetMaterialstozero(DwarfsPopulation, i);
            }
            Console.WriteLine("");
            Console.WriteLine("## Money and taxed from guild ##");
            Console.WriteLine("Total money earned:" + sumMoney);
            Console.WriteLine("Total money from tax guild" + sumTax);
            return DwarfsPopulation;
        }

        private static decimal HowMuchMonetDwarfsGet(Random priceForRawMaterials, int howMuchGold, int howMuchMithril, int howMuchTrainedGold, int howMuchSilver)
        {
            int priceMithril = priceForRawMaterials.Next(15, 26);
            int priceGold = priceForRawMaterials.Next(10, 21);
            int priceSilver = priceForRawMaterials.Next(5, 16);
            decimal earnedMoney = (howMuchGold * priceGold) + (howMuchMithril * priceMithril)
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
    //dwarfminer-pkozlowski
}