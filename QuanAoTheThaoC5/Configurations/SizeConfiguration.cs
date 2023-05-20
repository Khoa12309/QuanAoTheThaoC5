using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuanAoTheThaoC5.Models;
namespace QuanAoTheThaoC5.Configurations
{
    public class SizeConfiguration : IEntityTypeConfiguration<Size>
    {
        public void Configure(EntityTypeBuilder<Size> builder)
        {
            builder.HasKey(c => c.SizeId);
            builder.Property(c => c.SizeName).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(c => c.Description).HasColumnType("nvarchar(1000)").IsRequired();
        }
    }
}
