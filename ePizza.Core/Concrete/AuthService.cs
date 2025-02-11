using AutoMapper;
using ePizza.Core.Contracts;
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

        public bool ValidateUser(string username, string password)
        {
            var userDetails = _userRepository.FindUser(username); //if user exists or not
            if (userDetails != null)
            {
                bool isValidPassword = BCrypt.Net.BCrypt.Verify(password,userDetails.Password);
                if (isValidPassword)
                {
                    return true;
                }
            }
            return false;   
        }
    }
}
