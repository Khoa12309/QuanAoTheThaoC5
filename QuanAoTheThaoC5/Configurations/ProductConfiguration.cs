using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuanAoTheThaoC5.Models;
namespace QuanAoTheThaoC5.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x=>x.Id);
            builder.Property(p => p.Name).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(p => p.Description).HasColumnType("nvarchar(1000)").IsRequired();
            builder.HasOne(p => p.ProductMaterial).WithMany().HasForeignKey(p => p.IDProductMaterial);
            builder.HasOne(p => p.Supplier).WithMany().HasForeignKey(p => p.IDSupplier);
            builder.HasOne(p => p.Size).WithMany().HasForeignKey(p => p.IDSize);
            builder.HasOne(p => p.Color).WithMany().HasForeignKey(p => p.IDColor);
            builder.HasOne(p => p.Category).WithMany().HasForeignKey(p => p.IDCategory);
           
        }
    }
}
