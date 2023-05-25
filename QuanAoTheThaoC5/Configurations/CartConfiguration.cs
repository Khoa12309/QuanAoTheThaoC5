using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuanAoTheThaoC5.Models;

namespace QuanAoTheThaoC5.Configurations
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasOne(c => c.User).WithOne().HasForeignKey<Cart>(c=>c.User_ID);
        }
    }
}
