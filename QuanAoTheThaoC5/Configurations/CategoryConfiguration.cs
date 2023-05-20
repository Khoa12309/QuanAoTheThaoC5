using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuanAoTheThaoC5.Models;

namespace QuanAoTheThaoC5.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.CategoryId);
            builder.Property(p => p.CategoryName).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(p => p.Description).HasColumnType("nvarchar(1000)").IsRequired();
        }
    }
}
