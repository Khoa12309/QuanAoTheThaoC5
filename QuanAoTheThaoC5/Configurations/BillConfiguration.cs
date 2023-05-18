using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuanAoTheThaoC5.Models;

namespace QuanAoTheThaoC5.Configurations
{
    public class BillConfiguration : IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> builder)
        {
            builder.HasKey(c=>c.Id);     
            builder.Property(c => c.PhoneNumber).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(c => c.Address).HasColumnType("nvarchar(1000)").IsRequired();

        }
    }
}
