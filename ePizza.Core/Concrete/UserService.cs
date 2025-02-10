using AutoMapper;
using ePizza.Core.Contracts;
using ePizza.Core.Mappers;
using ePizza.Domain.Models;
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
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository,IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public bool AddUser(CreateUserRequest userRequest)
        {
            //refactoring..
            var roles = _userRepository.GetAll().Select(x => x.Id == 2);
            var userDetails = _mapper.Map<User>(userRequest);
            userDetails.Password = BCrypt.Net.BCrypt.HashPassword(userDetails.Password);
            _userRepository.Add(userDetails);
         int rowsAffected =    _userRepository.CommitChanges();
            return rowsAffected > 0;
            //return true;
        }

        public IEnumerable<UserResponseModel> GetAllUsers()
        {
            var users = _userRepository.GetAll().AsEnumerable();

            var userResponse = _mapper.Map<IEnumerable<UserResponseModel>>(users);
            return userResponse;
          //  return users.ConvertToUserResponseModelUsingLinq();
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
