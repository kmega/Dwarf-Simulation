using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfMineSimulator
{
    class Guild
    {
        public List<Dwarf> HowMuchDwarfEarnedMoney(List<Dwarf> DwarfsPopulation)
        {
            Randomizer random = new Randomizer();
            CalculatingDataForTheReport calculating = new CalculatingDataForTheReport();
            ViewInformation view = new ViewInformation();
            decimal sumMoney = 0;
            decimal sumTax = 0;
            for (int i = 0; i < DwarfsPopulation.Count; i++)
            {
                Random priceForRawMaterials = new Random();
                int howMuchGold= 0, howMuchMithril=0, howMuchTrainedGold=0, howMuchSilver=0;
                CheckHowMuchDwarfGetMinerals(DwarfsPopulation, i, out howMuchGold, out howMuchMithril, out howMuchTrainedGold, out howMuchSilver);
                //mithril 15 - 25j, zoto 10 - 20j, srebro 5 - 15, brudne zoto 2
                var price = random.GetPriceMinerals();
                
                decimal earnedMoney = HowMuchMoneyDwarfsGet(price, howMuchGold, howMuchMithril, howMuchTrainedGold, howMuchSilver);
                decimal taxMoney = earnedMoney * 0.25m;
                earnedMoney -= taxMoney;
                calculating.MoneyAndTaxFromGuild(earnedMoney, taxMoney);
                sumMoney += earnedMoney;
                sumTax += taxMoney;
                DwarfsPopulation[i].MoneyEarndedThisDay = earnedMoney;
                DwarfsPopulation[i].Money += earnedMoney;

                SetMaterialstozero(DwarfsPopulation, i);
            }
            view.ViewMoneyAndTaxFromGuild(sumMoney, sumTax);
            return DwarfsPopulation;
        }

        private static decimal HowMuchMoneyDwarfsGet(Dictionary<Minerals,int> price, int howMuchGold, int howMuchMithril, int howMuchTrainedGold, int howMuchSilver)
        {       
            decimal earnedMoney = (howMuchGold * price[Minerals.Gold]) 
                + (howMuchMithril * price[Minerals.Mithril])
                + (howMuchSilver * price[Minerals.Silver]) 
                + (howMuchTrainedGold * price[Minerals.TaintedGold]);        
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