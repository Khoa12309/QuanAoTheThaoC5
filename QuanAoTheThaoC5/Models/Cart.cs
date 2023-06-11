namespace QuanAoTheThaoC5.Models
{
    public class Cart
    {
        public Guid Id { get; set; }
        public Guid User_ID { get; set; }
        public int Status { get; set; }
        public virtual User? User { get; set; }
    }
}
