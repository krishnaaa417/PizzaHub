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
        private readonly IRolesRepository _rolesRepository;
        public UserService(IUserRepository userRepository,IMapper mapper,IRolesRepository rolesRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _rolesRepository = rolesRepository;
        }

        public bool AddUser(CreateUserRequest userRequest)
        {
            // need to convert createuserrequest model to user model looks like repo model
           // var roles = _userRepository.GetAll().Where(x => x.Name == "User").FirstOrDefault();
           var roles = _rolesRepository.GetAll().Where(x => x.Name == "User").FirstOrDefault();
            //refactoring..
            if ( roles!= null)
            {
                
                var userDetails = _mapper.Map<User>(userRequest);
                userDetails.Roles.Add(roles);
                userDetails.Password = BCrypt.Net.BCrypt.HashPassword(userDetails.Password);
                _userRepository.Add(userDetails);
                int rowsAffected = _userRepository.CommitChanges();
                return rowsAffected > 0;
            }
            return false;
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
