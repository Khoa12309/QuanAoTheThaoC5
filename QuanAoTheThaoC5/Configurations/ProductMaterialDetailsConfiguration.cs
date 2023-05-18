using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuanAoTheThaoC5.Models;

namespace QuanAoTheThaoC5.Configurations
{
    public class ProductMaterialDetailsConfiguration : IEntityTypeConfiguration<ProductMaterialDetails>
    {
        public void Configure(EntityTypeBuilder<ProductMaterialDetails> builder)
        {
           builder.HasKey(x => x.Id);
        }
    }
}
