namespace EcommerceWebAPI.Models
{
    public class Uoms
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<Products> Products { get; set; } = new List<Products>();

    }
}
