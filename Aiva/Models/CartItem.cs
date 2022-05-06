namespace Aiva.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public Client Client { get; set; }
        public Item Item { get; set; }
        public int Count { get; set; }
    }
}
