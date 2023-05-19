namespace QuanAoTheThaoC5.Models
{
    public class ProductImg
    {
        public Guid Id { get; set; }
        public Guid IDProduct { get; set; }
        public string URl { get; set; }
        public virtual Product Products { get; set; }

    }
}
