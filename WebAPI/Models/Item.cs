namespace WebAPI.Models
{
    public class Item
    {
        public Guid ItemId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime Created { get; set; }

        public Item(Guid itemId, string name, decimal price, DateTime created)
        {
            ItemId = itemId;
            Name = name;
            Price = price;
            Created = created;
        }
    }
}