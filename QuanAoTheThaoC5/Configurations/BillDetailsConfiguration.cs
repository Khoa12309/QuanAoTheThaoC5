using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuanAoTheThaoC5.Models;

namespace QuanAoTheThaoC5.Configurations
{
    public class BillDetailsConfiguration : IEntityTypeConfiguration<BillDetails>
    {
        public void Configure(EntityTypeBuilder<BillDetails> builder)
        {
            builder.HasKey(c => c.ID);
            builder.HasOne(c => c.Bill).WithMany().HasForeignKey(c => c.IDBill);
            builder.HasOne(c => c.Product).WithMany().HasForeignKey(c => c.IDProduct);
        }
    }
}
