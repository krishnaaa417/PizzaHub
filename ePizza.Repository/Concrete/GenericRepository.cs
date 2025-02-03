using ePizza.Domain.Models;
using ePizza.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePizza.Repository.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected ePizzaHubDbContext _ePizzaHubDbContext;
        
        public GenericRepository(ePizzaHubDbContext dbContext)
        {
            _ePizzaHubDbContext = dbContext;
        }
        public void Add(T entity)
        {
           _ePizzaHubDbContext.Set<T>().Add(entity);
        }

        public IEnumerable<T> GetAll()
        {
          return _ePizzaHubDbContext.Set<T>().ToList();
        }
    }
}
