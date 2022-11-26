using Microsoft.AspNetCore.Mvc;
using Play.Catalog.Service.Factory;
using Play.Catalog.Service.Model;
using System.Reflection.Metadata.Ecma335;

namespace Play.Catalog.Service.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private static readonly List<ItemDTO> itemDTOs = new()
        {
            ItemFactory.CreateItemDTO("Potion", "Restores a small amount of HP", 5),
            ItemFactory.CreateItemDTO("Antidote", "Cures poison", 7),
            ItemFactory.CreateItemDTO("Bronze sword", "Deals a sma;; amount of demage", 20)
        };

        [HttpGet]
        public IEnumerable<ItemDTO> Get()
        {
            return itemDTOs;
        }

        [HttpGet("{id}")]
        public ItemDTO GetById(Guid id)
        {
            return itemDTOs.Where(i => i.Equals(id)).SingleOrDefault();
        }

        [HttpPost]
        public ActionResult<ItemDTO> Post(string name, string description, decimal price)
        {
            ItemDTO dto = ItemFactory.CreateItemDTO(name, description, price);
            itemDTOs.Add(dto);

            return new OkObjectResult(dto);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, string name, string description, decimal price)
        {
           var existingItem = itemDTOs.Where(item => item.Id.Equals(id)).SingleOrDefault();
            if (existingItem != null)
            {
                existingItem.Name = name;
                existingItem.Description = description;
                existingItem.Price = price;
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var item = itemDTOs.Remove(itemDTOs.Where(itemid => itemid.Equals(id)).SingleOrDefault()); 

            return NoContent();
        }
    }
}
