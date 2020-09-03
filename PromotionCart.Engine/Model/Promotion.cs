using System.Collections.Generic;

namespace PromotionCart.Engine.Model
{
    public class Promotion
    {
        public int promotionID { get; set; }
        public Dictionary<string, int> prodInfo { get; set; }
        public decimal promotionPrice { get; set; }

        public Promotion(int promoID, Dictionary<string, int> prodInfo, decimal pp)
        {
            this.promotionID = promoID;
            this.prodInfo = prodInfo;
            this.promotionPrice = pp;
        }
    }
}
