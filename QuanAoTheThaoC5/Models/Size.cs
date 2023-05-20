namespace QuanAoTheThaoC5.Models
{
    public class Size
    {
        public Guid SizeId { get; set; }
        public string SizeName { get; set; }
        public string Description { get; set; }
        public virtual IEnumerable<Product> Products { get; set; }
    }
}