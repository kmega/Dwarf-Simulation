using System;
using System.Collections.Generic;
using ChickenKitchen;
using ChickenKitchen.RestaurantDataBase;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void EmperorChickenHasGoodIngredients()
        {
            Dictionary<Ingredients, int> EmperorChicken = new Dictionary<Ingredients, int>()
            {
                { Ingredients.Chicken, 1 },
                {Ingredients.Asparagus, 3 },
                {Ingredients.Honey,3 },
                {Ingredients.Milk,3 },
                {Ingredients.Potatoes,1 },
                {Ingredients.Tomatoes,1 },
                {Ingredients.Pickles,1 },
                {Ingredients.Feta,1 },
                {Ingredients.Paprika,1 },
                {Ingredients.Garlic,1 },
                {Ingredients.Water,1 },
                {Ingredients.Tuna,1 },
                {Ingredients.Chocolate,1 }

                

            };

            Menu menu = new Menu();
            RegularClients rc = new RegularClients();
            Storage store = new Storage();
            MasterChef pascal = new MasterChef();

            Dictionary<Ingredients, int> result = pascal.PrepareMeal(menu.menu[8], store.store);


            CollectionAssert.AreEquivalent(EmperorChicken, result);


        }


        [TestMethod]
        public void AdamSmithCanOrderEmperorChicken()
        {
           

            Menu menu = new Menu();
            RegularClients rc = new RegularClients();
            Storage store = new Storage();
            MasterChef pascal = new MasterChef();

           string result = pascal.GiveAMeal(menu.menu[8], store.store,rc.regularclients[2]);

            Assert.IsTrue(result.StartsWith("We prepared Emperor Chicken for Adam Smith"));
           


        }

        [TestMethod]
        public void BernardUnfortunateCantOrderEMperorChicken()
        {


            Menu menu = new Menu();
            RegularClients rc = new RegularClients();
            Storage store = new Storage();
            MasterChef pascal = new MasterChef();

            string result = pascal.GiveAMeal(menu.menu[8], store.store, rc.regularclients[5]);

            Assert.IsTrue(result.StartsWith("This meal will kill you"));



        }


    }
}
