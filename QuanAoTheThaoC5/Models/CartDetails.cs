namespace QuanAoTheThaoC5.Models
{
    public class CartDetails
    {
        public int Id { get; set; }
        public Guid Product_ID { get; set; }
        public Guid Cart_ID { get; set; }
        public int Quantity { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual Product Product { get; set; }
    }
}
