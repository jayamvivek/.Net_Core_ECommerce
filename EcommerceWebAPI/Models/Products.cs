namespace EcommerceWebAPI.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public int UomId { get; set; }
        public Uoms Uom { get; set; }

        public ICollection<ProductImages> Images { get; set; } = new List<ProductImages>();

    }
}
