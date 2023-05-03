namespace OrderEats.Core.Models
{
    public class Cart : TrackingEntity
    {
        public Cart()
        {
            CartItems = new List<CartItem>();
        }
        public long UserId { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
    }
}
