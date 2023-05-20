using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuanAoTheThaoC5.Models;
namespace QuanAoTheThaoC5.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(c => c.Name).HasColumnType("nvarchar(100)").IsRequired();
            builder.Property(c => c.PhoneNumber).HasColumnType("nvarchar(100)").IsRequired();
            builder.Property(c => c.Address).HasColumnType("nvarchar(100)").IsRequired();
            builder.Property(c => c.Email).HasColumnType("nvarchar(100)").IsRequired();
            builder.Property(c => c.Password).HasColumnType("nvarchar(100)").IsRequired();
            builder.Property(c => c.Status).HasColumnType("int").IsRequired();
            builder.HasOne(c => c.Roles).WithMany().HasForeignKey(c => c.IDRole);
        }
    }
}
