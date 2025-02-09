using ePizza.Core.Contracts;
using ePizza.Core.Mappers;
using ePizza.Domain.Models;
using ePizza.Models.Request;
using ePizza.Models.Response;
using ePizza.Repository.Concrete;
using ePizza.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePizza.Core.Concrete
{
    public class ItemService : IitemService
    {
        private readonly IItemRepository _itemRepository;

        private static int _idCounter = 1;
        public ItemService(IItemRepository itemRepository)
        {
           _itemRepository = itemRepository;
        }

        public Item AddItem(ItemRequest request)
        {
            var newItem = new Item
            {
                Id = _idCounter++,
                Name = request.Name,
                Description = request.Description,
                UnitPrice = request.UnitPrice,
                CreatedDate = DateTime.UtcNow
            };

            _itemRepository.Add(newItem);
            return newItem;
        }

        public IEnumerable<ItemResponse> GetAllItems()
        {
            var items = _itemRepository.GetAll().AsEnumerable();

            return items.ConvertIntoItems();
            

        }   
    }
}
