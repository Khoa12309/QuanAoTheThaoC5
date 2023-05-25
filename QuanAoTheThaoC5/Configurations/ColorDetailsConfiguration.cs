using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuanAoTheThaoC5.Models;
namespace QuanAoTheThaoC5.Configurations
{
    public class ColorDetailsConfiguration : IEntityTypeConfiguration<ColorDetails>
    {
        public void Configure(EntityTypeBuilder<ColorDetails> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(p => p.Description).HasColumnType("nvarchar(1000)").IsRequired();
            builder.HasOne(c => c.Product).WithMany().HasForeignKey(c => c.ProductID);
            builder.HasOne(c => c.Color).WithMany().HasForeignKey(c => c.ColorID);
        }
    }
}
