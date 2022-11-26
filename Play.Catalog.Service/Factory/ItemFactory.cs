﻿using Play.Catalog.Service.Model;

namespace Play.Catalog.Service.Factory
{
    public static class ItemFactory
    {
        public static ItemDTO CreateItemDTO(string name, string description, decimal price)
        {
            ItemDTO itemDTO = new();
            itemDTO.Id= Guid.NewGuid();
            itemDTO.Name= name;
            itemDTO.Description= description;
            itemDTO.Price = price;
            itemDTO.CreatedAt = DateTime.Now;

            return itemDTO;
        }
    }
}