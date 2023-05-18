namespace QuanAoTheThaoC5.Models
{
    public class Voucher
    {
        public Guid Id { get; set; }  
        public string Name { get; set; }
        public string VoucherCode { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int DiscountValue { get; set; }


    }
}
