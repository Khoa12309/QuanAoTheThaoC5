using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuanAoTheThaoC5.Models;
namespace QuanAoTheThaoC5.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasColumnType("nvarchar(1000)").IsRequired();
        }
    }
}
