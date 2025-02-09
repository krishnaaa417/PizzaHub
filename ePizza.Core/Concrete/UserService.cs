using ePizza.Core.Contracts;
using ePizza.Core.Mappers;
using ePizza.Models.Request;
using ePizza.Models.Response;
using ePizza.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePizza.Core.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool AddUser(CreateUserRequest userRequest)
        {
            return true;
            
        }

        public IEnumerable<UserResponseModel> GetAllUsers()
        {
            var users = _userRepository.GetAll().AsEnumerable();
            return users.ConvertToUserResponseModelUsingLinq();
        }

        public UserResponseModel GetUserById(int id)
        {
            var users = _userRepository.GetAll().AsEnumerable().FirstOrDefault();
            return users.ConvertToUserResponseModelUsingLinq();
        }

        //public void GetAllUsers()
        //{
        //  var users =   _userRepository.GetAll();
        //}
    }

    //public class EmployeeService : IUserService
    //{
    //    public void GetAllUsers()
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
