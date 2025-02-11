using ePizza.Domain.Models;
using ePizza.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePizza.Repository.Concrete
{
    public class RolesRepository : GenericRepository<Role>, IRolesRepository
    {
        public RolesRepository(ePizzaHubDbContext dbContext) : base(dbContext)
        {

        }

        //public void Add(User entity)
        //{
        //    throw new NotImplementedException();
        //}

        //IEnumerable<User> IGenericRepository<User>.GetAll()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
