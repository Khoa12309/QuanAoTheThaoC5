namespace QuanAoTheThaoC5.Models
{
    public class Color
    {
        public Guid Id { get; set; }
        public string ColerCode { get; set; }
        public string Name { get; set; }
        public virtual IQueryable<ColorDetails> Details { get; set; }
    }
}