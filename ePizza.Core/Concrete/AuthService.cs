using AutoMapper;
using ePizza.Core.Contracts;
using ePizza.Models.Response;
using ePizza.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePizza.Core.Concrete
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public AuthService(IUserRepository userRepository,IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;

        }

        public ValidateUserResponse ValidateUser(string username, string password)
        {
            var userDetails = _userRepository.FindUser(username); //if user exists or not
            if (userDetails != null)
            {
                bool isValidPassword = BCrypt.Net.BCrypt.Verify(password,userDetails.Password);
                if (isValidPassword)
                {
                    return new ValidateUserResponse()
                    {
                        Email = username,
                        Name = userDetails.Name,
                        Roles = userDetails.Roles.Select(x => x.Name).ToList(),
                    };
                }
            }
            return new ValidateUserResponse();   
        }
    }
}
