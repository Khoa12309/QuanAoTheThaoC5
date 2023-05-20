
namespace QuanAoTheThaoC5.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public Guid IDCategory { get; set; }
        public Guid IDSupplier { get; set; }
        public Guid IDSize { get; set; }
        public Guid IDColor { get; set; }
        public Guid IDProductMaterial { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public int Status { get; set; }
        public virtual Category Category { get; set; }
        public virtual ProductMaterial ProductMaterial { get; set; }
        public virtual Color Color { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual Size Size { get; set; }

    }
}
