using PromotionCart.Engine.Model;
using System.Linq;

namespace PromotionCart.Engine
{
    public static class CalculatePromotion
    {
        //returns PromotionID and count of promotions
        public static decimal GetTotalPrice(Order ord, Promotion prom)
        {
            decimal totalPrice = 0M;
            //get promoted products count in order
            var count = ord.Products
                .GroupBy(x => x.itemId)
                .Where(grp => prom.prodInfo.Any(y => grp.Key == y.Key && grp.Count() >= y.Value))
                .Select(grp => grp.Count())
                .Sum();

            //get promoted products count from promotion
            int promoProductCount = prom.prodInfo.Sum(kvp => kvp.Value);
            while (count >= promoProductCount)
            {
                totalPrice += prom.promotionPrice;
                count -= promoProductCount;
            }
            if (totalPrice != 0M)
            {
                totalPrice = totalPrice + count * new Product(prom.prodInfo.Keys.FirstOrDefault()).Price;
            }
            else
            {
                totalPrice = totalPrice + new Product(prom.prodInfo.Keys.FirstOrDefault()).Price;
            }
            //return totalPrice
            return totalPrice;
        }
    }
}

