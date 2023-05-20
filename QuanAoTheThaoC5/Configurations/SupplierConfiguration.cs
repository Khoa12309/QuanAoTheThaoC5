using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuanAoTheThaoC5.Models;
namespace QuanAoTheThaoC5.Configurations
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.SupplierName).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(c => c.SupllierCode).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(c => c.PhoneNumber).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(c => c.Address).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(c => c.Descripton).HasColumnType("nvarchar(1000)").IsRequired();
        }
    }
}
