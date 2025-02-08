using ePizza.Core.Contracts;
using ePizza.Core.Mappers;
using ePizza.Domain.Models;
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
        public ItemService(IItemRepository itemRepository)
        {
           _itemRepository = itemRepository;
        }
        public IEnumerable<ItemResponse> GetAllItems()
        {
            var items = _itemRepository.GetAll().AsEnumerable();

            return items.ConvertToItem();
            

        }   
    }
}
