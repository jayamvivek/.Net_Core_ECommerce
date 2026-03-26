namespace EcommerceWebAPI.Models
{
    public class ProductImages
    {
        public int Id { get; set; }
        public string Url { get; set; } = string.Empty;

        public int ProductId { get; set; }
        public Products Product { get; set; }

    }
}
