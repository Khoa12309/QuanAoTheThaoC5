using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuanAoTheThaoC5.Models;
namespace QuanAoTheThaoC5.Configurations
{
    public class ColorConfiguration : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Name).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(p => p.ColerCode).HasColumnType("nvarchar(1000)").IsRequired();
        }
    }
}
