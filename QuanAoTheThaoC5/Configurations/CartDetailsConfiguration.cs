using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuanAoTheThaoC5.Models;
namespace QuanAoTheThaoC5.Configurations
{
    public class CartDetailsConfiguration : IEntityTypeConfiguration<CartDetails>
    {
        public void Configure(EntityTypeBuilder<CartDetails> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasOne(c => c.Carts).WithMany().HasForeignKey(c => c.Cart_ID);
            builder.HasOne(c => c.Product).WithMany().HasForeignKey(c => c.Product_ID);
        }
    }
}
