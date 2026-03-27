namespace EcommerceWebAPI.Models
{
    public class Uoms
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; 
        public int Qty { get; set; }

        // Foreign key to UomTypes
        public int UomTypeId { get; set; }

        // Navigation property
        public UomTypes UomType { get; set; }

        public ICollection<Products> Products { get; set; } = new List<Products>();

    }
}
