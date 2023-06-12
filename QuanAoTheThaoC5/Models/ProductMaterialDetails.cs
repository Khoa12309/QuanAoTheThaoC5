namespace QuanAoTheThaoC5.Models
{
    public class ProductMaterialDetails
    {
        public Guid Id { get; set; }
        public Guid IDProductMaterial { get; set; }
        public Guid IDProduct { get; set; }
        public string? Description { get; set; }

        public virtual Product ? Product { get; set; }
        public virtual ProductMaterial ? ProductMaterial { get; set; }

    }
}