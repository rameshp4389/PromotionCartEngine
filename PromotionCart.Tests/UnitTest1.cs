using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionCart.Engine;
using PromotionCart.Engine.Model;

namespace PromotionCart.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod_ForScenario1_ReturnsTotalPrice()
        {
            Dictionary<String, int> cart1 = new Dictionary<String, int>();
            cart1.Add("itemA", 3);
            Dictionary<String, int> cart2 = new Dictionary<String, int>();
            cart2.Add("itemB", 2);
            Dictionary<String, int> cart3 = new Dictionary<String, int>();
            cart3.Add("itemC", 1);
            cart3.Add("itemD", 1);
            List<Promotion> promotions = new List<Promotion>()
            {
                new Promotion(1, cart1, 130),
                new Promotion(2, cart2, 45),
                new Promotion(3, cart3, 30)
            };
            Order order = new Order(1, new List<Product>() { new Product("itemA"), new Product("itemB"), new Product("itemC") });
            decimal expectedvalue = 100;
            decimal promotionalPrices = promotions
                    .Select(promo => CalculatePromotion.GetTotalPrice(order, promo))
                    .ToList().Sum();
            Assert.IsNotNull(promotionalPrices);
            Assert.AreEqual(expectedvalue, promotionalPrices);
        }

        [TestMethod]
        public void TestMethod_ForScenario2_ReturnsTotalPrice()
        {
            Dictionary<String, int> cart1 = new Dictionary<String, int>();
            cart1.Add("itemA", 3);
            Dictionary<String, int> cart2 = new Dictionary<String, int>();
            cart2.Add("itemB", 2);
            Dictionary<String, int> cart3 = new Dictionary<String, int>();
            cart3.Add("itemC", 1);
            cart3.Add("itemD", 1);
            List<Promotion> promotions = new List<Promotion>()
            {
                new Promotion(1, cart1, 130),
                new Promotion(2, cart2, 45),
                new Promotion(3, cart3, 30)
            };
            Order order = new Order(2, new List<Product>() { new Product("itemA"), new Product("itemA"), new Product("itemA"), new Product("itemA"), new Product("itemA"), new Product("itemB"), new Product("itemB"), new Product("itemB"), new Product("itemB"), new Product("itemB"), new Product("itemC") });
            decimal expectedvalue = 370;
            decimal promotionalPrices = promotions
                    .Select(promo => CalculatePromotion.GetTotalPrice(order, promo))
                    .ToList().Sum();
            Assert.IsNotNull(promotionalPrices);
            Assert.AreEqual(expectedvalue, promotionalPrices);
        }

        [TestMethod]
        public void TestMethod_ForScenario3_ReturnsTotalPrice()
        {
            Dictionary<String, int> cart1 = new Dictionary<String, int>();
            cart1.Add("itemA", 3);
            Dictionary<String, int> cart2 = new Dictionary<String, int>();
            cart2.Add("itemB", 2);
            Dictionary<String, int> cart3 = new Dictionary<String, int>();
            cart3.Add("itemC", 1);
            cart3.Add("itemD", 1);
            List<Promotion> promotions = new List<Promotion>()
            {
                new Promotion(1, cart1, 130),
                new Promotion(2, cart2, 45),
                new Promotion(3, cart3, 30)
            };

            Order order = new Order(3, new List<Product>() { new Product("itemA"), new Product("itemA"), new Product("itemA"), new Product("itemB"), new Product("itemB"), new Product("itemB"), new Product("itemB"), new Product("itemB"), new Product("itemC"), new Product("itemD") });
            decimal expectedvalue = 280;
            decimal promotionalPrices = promotions
                    .Select(promo => CalculatePromotion.GetTotalPrice(order, promo))
                    .ToList().Sum();
            Assert.IsNotNull(promotionalPrices);
            Assert.AreEqual(expectedvalue, promotionalPrices);
        }
    }
}

