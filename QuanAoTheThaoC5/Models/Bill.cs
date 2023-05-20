namespace QuanAoTheThaoC5.Models
{
    public class Bill
    {
        public Guid Id { get; set; }
        public Guid? IDUser { get; set; }
        public Guid? IDVoucher { get; set; }

        public DateTime CreateDate { get; set; }
        public int Status { get; set; }
        public double TotalMoney { get; set; }
        public double TransportFee { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

       public virtual User User { get; set; }
        public virtual Voucher Voucher { get; set; }

    }
}
