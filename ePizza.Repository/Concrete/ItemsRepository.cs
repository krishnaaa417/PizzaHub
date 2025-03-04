using ePizza.Domain.Models;
using ePizza.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePizza.Repository.Concrete
{
    public class ItemsRepository : GenericRepository<Item>, IItemsRepository
    {
        public ItemsRepository(ePizzaHubDbContext dbContext) : base(dbContext)
        {
        }
    }
}
