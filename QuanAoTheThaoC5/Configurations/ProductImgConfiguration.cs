using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuanAoTheThaoC5.Models;
namespace QuanAoTheThaoC5.Configurations
{
    public class ProductImgConfiguration : IEntityTypeConfiguration<ProductImg>
    {
        public void Configure(EntityTypeBuilder<ProductImg> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.URl).HasColumnType("nvarchar(1000)").IsRequired();
            builder.HasOne(c=>c.Products).WithMany().HasForeignKey(c => c.IDProduct);
        }
    }
}
