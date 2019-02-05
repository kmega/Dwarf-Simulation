using System;
using System.Collections.Generic;
using System.Text;
using DwarfMineSimulator;
using NUnit.Framework;

namespace DwarfMineSimulatorTests
{
    public class ShopTests
    {


        [Test]
        public void ShopShouldEarnMoneyWhenDwarfsBuyProducts()
        {
            //Given
            Shop shop = new Shop();

            List<Dwarf> DwarfsPopulation = new List<Dwarf>()
            {
                new Dwarf(){Alive = true,Type = DwarfTypes.Father,Money=0.0M,MoneyEarndedThisDay=1.0M},
                new Dwarf(){Alive = true,Type = DwarfTypes.Father,Money=0.0M,MoneyEarndedThisDay=1.0M},
                new Dwarf(){Alive = true,Type = DwarfTypes.Father,Money=0.0M,MoneyEarndedThisDay=1.0M},
                new Dwarf(){Alive = true,Type = DwarfTypes.Single,Money=0.0M,MoneyEarndedThisDay=1.0M},
                new Dwarf(){Alive = true,Type = DwarfTypes.Single,Money=0.0M,MoneyEarndedThisDay=1.0M},
                new Dwarf(){Alive = true,Type = DwarfTypes.Lazy,Money=0.0M,MoneyEarndedThisDay=1.0M}
            };

            //When
            shop.BuyProducts(DwarfsPopulation);
            decimal actual = shop.EarnedMoney;

            //Then
            Assert.AreEqual(2.5M, actual);
        }

        [Test]
        public void ShopShouldSellSuitableProductsToDwarfsType()
        {
            //Given
            Shop shop = new Shop();

            List<Dwarf> DwarfsPopulation = new List<Dwarf>()
            {
                new Dwarf(){Alive = true,Type = DwarfTypes.Father,Money=0.0M,MoneyEarndedThisDay=1.0M},
                new Dwarf(){Alive = true,Type = DwarfTypes.Father,Money=0.0M,MoneyEarndedThisDay=1.0M},
                new Dwarf(){Alive = true,Type = DwarfTypes.Father,Money=0.0M,MoneyEarndedThisDay=1.0M},
                new Dwarf(){Alive = true,Type = DwarfTypes.Single,Money=0.0M,MoneyEarndedThisDay=1.0M},
                new Dwarf(){Alive = true,Type = DwarfTypes.Single,Money=0.0M,MoneyEarndedThisDay=1.0M},
                new Dwarf(){Alive = true,Type = DwarfTypes.Lazy,Money=0.0M,MoneyEarndedThisDay=1.0M}
            };

            //When
            shop.BuyProducts(DwarfsPopulation);
            int soldAlcohol = shop.AlcoholBought;
            int soldFood = shop.FoodBought;

            //Then
            Assert.AreEqual(3, soldFood);
            Assert.AreEqual(2, soldAlcohol);
        }


        [Test]
        public void ShopNotSellProductsToLazyDwarfs()
        {
            //Given
            Shop shop = new Shop();

            List<Dwarf> DwarfsPopulation = new List<Dwarf>()
            {
                new Dwarf(){Alive = true,Type = DwarfTypes.Lazy,Money=0.0M,MoneyEarndedThisDay=1.0M},
                new Dwarf(){Alive = true,Type = DwarfTypes.Lazy,Money=0.0M,MoneyEarndedThisDay=1.0M}
            };

            //When
            shop.BuyProducts(DwarfsPopulation);
            int soldProducts = shop.AlcoholBought + shop.FoodBought;
            
            //Then
            Assert.AreEqual(0, soldProducts);

        }
    }
}
