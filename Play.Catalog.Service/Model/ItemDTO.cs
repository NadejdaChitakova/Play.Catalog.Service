using System.ComponentModel.DataAnnotations;

namespace Play.Catalog.Service.Model
{
    public class ItemDTO
    {
        public ItemDTO(Guid id, string? name, string? description, decimal price)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
        }

        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
    }
}
