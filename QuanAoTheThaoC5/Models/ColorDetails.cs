namespace QuanAoTheThaoC5.Models
{
    public class ColorDetails
    {
        public Guid Id { get; set; }
        public Guid ProductID { get; set; }
        public Guid ColorID { get; set; }
        public string Description { get; set; }

        // public virtual Product Product { get; set; } 
        // public virtual Color Color { get; set; }
    }
}
