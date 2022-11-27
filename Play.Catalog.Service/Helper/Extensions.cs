using Play.Catalog.Service.Model;
using System.Runtime.CompilerServices;

namespace Play.Catalog.Service.Helper
{
    public class Extensions
    {
        public static ItemDTO AsDTO(Item item)
        {
            return new ItemDTO(item.Id, item.Name, item.Description, item.Price);
        }
    }
}
