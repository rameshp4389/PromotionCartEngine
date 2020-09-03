using PromotionCart.Engine.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PromotionCart.Engine
{
    public class Program
    {
        static void Main(string[] args)
        {
            //creating list of promotions
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

            //create orders
            List<Order> orders = new List<Order>();
            Order order1 = new Order(1, new List<Product>() { new Product("itemA"), new Product("itemB"), new Product("itemC") });
            Order order2 = new Order(2, new List<Product>() { new Product("itemA"), new Product("itemA"), new Product("itemA"), new Product("itemA"), new Product("itemA"), new Product("itemB"), new Product("itemB"), new Product("itemB"), new Product("itemB"), new Product("itemB"), new Product("itemC") });
            Order order3 = new Order(3, new List<Product>() { new Product("itemA"), new Product("itemA"), new Product("itemA"), new Product("itemB"), new Product("itemB"), new Product("itemB"), new Product("itemB"), new Product("itemB"), new Product("itemC"), new Product("itemD") });
            orders.AddRange(new Order[] { order1, order2, order3 });

            //check if order meets promotion
            foreach (Order order in orders)
            {
                //calculate promotion
                List<decimal> promotionalPrices = promotions
                    .Select(promo => CalculatePromotion.GetTotalPrice(order, promo))
                    .ToList();
                decimal promoPrice = promotionalPrices.Sum();
                //final Price 
                Console.WriteLine($"OrderID: {order.OrderID} => Final price: {promoPrice.ToString("0.00")}");
                Console.Read();
            }
        }
    }
}

