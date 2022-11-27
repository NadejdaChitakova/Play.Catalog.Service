using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using MongoDB.Bson;
using Play.Catalog.Service.Factory;
using Play.Catalog.Service.Model;
using Play.Catalog.Service.Repositories;
using System.Reflection.Metadata.Ecma335;

namespace Play.Catalog.Service.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private readonly ItemRepository _itemsRepository = new();

        private static readonly List<Item> itemDTOs = new()
        {
            ItemFactory.CreateItem("Potion", "Restores a small amount of HP", 5),
            ItemFactory.CreateItem("Antidote", "Cures poison", 7),
            ItemFactory.CreateItem("Bronze sword", "Deals a sma;; amount of demage", 20)
        };

        [HttpGet]
        public async Task<IEnumerable<ItemDTO>> GetAsync()
        {
            var items = (await _itemsRepository.GetAllAsync()).Select(item => Helper.Extensions.AsDTO(item)); ;
            return items;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDTO>> GetByIdAsync(Guid id)
        {
           var item = await _itemsRepository.GetItemAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return Helper.Extensions.AsDTO(item);
        }

        [HttpPost]
        public async Task<ActionResult<Item>> PostAsync(ItemDTO itemDTO)
        {
            Item item = ItemFactory.CreateItem(itemDTO.Name, itemDTO.Description, itemDTO.Price);
            itemDTOs.Add(item);

            await _itemsRepository.CreateAsync(item);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(Guid id, string name, string description, decimal price)
        {
            var existingItem = _itemsRepository.GetItemAsync(id).Result;

            if (existingItem == null)
            {
                return NotFound();
               
            }

            existingItem.Name = name;
            existingItem.Description = description;
            existingItem.Price = price;

            await _itemsRepository.UpdateAsync(existingItem);
            return NoContent() ;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var item = _itemsRepository.GetItemAsync(id).Result;

            if (item == null)
            {
                return NotFound();
            }

            await _itemsRepository.RemoveAsync(item.Id);

            return NoContent();
        }
    }
}
