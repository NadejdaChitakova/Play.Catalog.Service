using Play.Catalog.Service.Model;

namespace Play.Catalog.Service.Factory
{
    public static class ItemFactory
    {
        public static Item CreateItem(string name, string description, decimal price)
        {
            Item itemDTO = new();
            itemDTO.Id= Guid.NewGuid();
            itemDTO.Name= name;
            itemDTO.Description= description;
            itemDTO.Price = price;
            itemDTO.CreatedAt = DateTime.Now;

            return itemDTO;
        }
    }
}
