﻿using ePizza.Models.Request;
using ePizza.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePizza.Core.Contracts
{
    public interface IUserService
    {
        // void GetAllUsers();
        IEnumerable<UserResponseModel> GetAllUsers();

        UserResponseModel GetUserById(int id);

        bool AddUser(CreateUserRequest userRequest);
    }
}
