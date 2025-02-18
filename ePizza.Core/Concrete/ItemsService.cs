using AutoMapper;
using ePizza.Core.Contracts;
using ePizza.Models.Responses;
using ePizza.Repository.Concrete;
using ePizza.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePizza.Core.Concrete
{
    public class ItemsService : IItemsService
    {
        private readonly IItemsRepository _itemsRepository;
        private readonly IMapper _mapper;
        public ItemsService(IItemsRepository itemsRepository,IMapper mapper)
        {
            _itemsRepository = itemsRepository;
            _mapper = mapper;
        }
        public IEnumerable<ItemsResponseModel> GetItems()
        {
            var items = _itemsRepository.GetAll();
            return _mapper.Map<IEnumerable<ItemsResponseModel>>(items);
        }
    }
}
