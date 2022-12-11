using Play.Catalog.Service.Model;

namespace Play.Catalog.Service.Repositories
{
    public interface IItemRepository
    {
        Task CreateAsync(Item entity);
        Task<IReadOnlyCollection<Item>> GetAllAsync();
        Task<Item> GetItemAsync(Guid id);
        Task RemoveAsync(Guid id);
        Task UpdateAsync(Item entity);
    }
}