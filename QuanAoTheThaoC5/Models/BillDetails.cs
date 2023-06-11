namespace QuanAoTheThaoC5.Models
{
    public class BillDetails
    {
        public Guid ID {get; set;}
        public Guid IDBill { get; set; }
        public Guid IDProduct { get; set; }
        public double Price { get; set; }   
        public int Amount { get; set; }
        public virtual Bill? Bill { get; set; }
        public virtual Product? Product { get; set; }
    }
}
