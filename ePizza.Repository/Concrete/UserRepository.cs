using ePizza.Domain.Models;
using ePizza.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePizza.Repository.Concrete
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ePizzaHubDbContext dbContext) : base(dbContext)
        {

        }

        public User FindUser(string emailAddress)
        {
           return _ePizzaHubDbContext.Users.Where(x => x.Email == emailAddress).FirstOrDefault()!;
            //s
        }
    }
}
