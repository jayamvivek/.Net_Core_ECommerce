using System.ComponentModel.DataAnnotations;

namespace EcommerceWebAPI.Models
{
    public class UomTypes
    { 
        public int Id { get; set; }

        [MaxLength(20)]
        public string Name { get; set; } = string.Empty;
    }
}
