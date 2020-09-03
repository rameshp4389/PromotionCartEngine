namespace PromotionCart.Engine.Model
{
    public class Product
    {
        public string itemId { get; set; }
        public decimal Price { get; set; }

        public Product(string id)
        {
            this.itemId = id;
            switch (id)
            {
                case "itemA":
                    this.Price = 50m;

                    break;
                case "itemB":
                    this.Price = 30m;

                    break;
                case "itemC":
                    this.Price = 20m;

                    break;
                case "itemD":
                    this.Price = 15m;
                    break;
            }
        }
    }
}

