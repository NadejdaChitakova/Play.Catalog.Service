using MongoDB.Driver;
using Play.Catalog.Service.Model;

namespace Play.Catalog.Service.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private const string collectionName = "items";
        private readonly IMongoCollection<Item> _dbCollection;
        private readonly FilterDefinitionBuilder<Item> _filterDefinitionBuilder = Builders<Item>.Filter;

        public ItemRepository()
        {
            var mongoClinet = new MongoClient("mongodb://localhost:27017");
            var database = mongoClinet.GetDatabase("Catalog");
            _dbCollection = database.GetCollection<Item>(collectionName);
        }

        public async Task<IReadOnlyCollection<Item>> GetAllAsync()
        {
            return await _dbCollection.Find(_filterDefinitionBuilder.Empty).ToListAsync();
        }

        public async Task<Item> GetItemAsync(Guid id)
        {
            FilterDefinition<Item> filter = _filterDefinitionBuilder.Eq(entity => entity.Id, id);
            return await _dbCollection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(Item entity)
        {
            if (entity == null)
            {
                throw new ArgumentException(nameof(entity));
            }

            await _dbCollection.InsertOneAsync(entity);
        }

        public async Task UpdateAsync(Item entity)
        {
            if (entity == null)
            {
                throw new ArgumentException(nameof(entity));
            }

            FilterDefinition<Item> filter = _filterDefinitionBuilder.Eq(existingEntity => existingEntity.Id, entity.Id);
            await _dbCollection.ReplaceOneAsync(filter, entity);
        }

        public async Task RemoveAsync(Guid id)
        {
            FilterDefinition<Item> filter = _filterDefinitionBuilder.Eq(entity => entity.Id, id);

            await _dbCollection.DeleteOneAsync(filter);
        }
    }
}
