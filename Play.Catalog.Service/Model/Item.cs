using System.ComponentModel.DataAnnotations;

namespace Play.Catalog.Service.Model
{
    public class Item
    {
        public Guid Id { get; set; }

        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }

        [Required]
        [Range(0, 1000)]
        public decimal Price { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
