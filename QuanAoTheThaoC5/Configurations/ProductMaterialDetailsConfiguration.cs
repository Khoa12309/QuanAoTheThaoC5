using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuanAoTheThaoC5.Models;

namespace QuanAoTheThaoC5.Configurations
{
    public class ProductMaterialDetailsConfiguration : IEntityTypeConfiguration<ProductMaterialDetails>
    {
        public void Configure(EntityTypeBuilder<ProductMaterialDetails> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Description).HasColumnType("nvarchar(1000)").IsRequired();

            builder.HasOne(x => x.ProductMaterial).WithMany().HasForeignKey(x => x.IDProductMaterial);
            builder.HasOne(x => x.Product).WithMany().HasForeignKey(x => x.IDProduct);
        }
    }
}
