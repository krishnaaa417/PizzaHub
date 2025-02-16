﻿using ePizza.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePizza.Core.Contracts
{
    public interface IAuthService
    {
        ValidateUserResponse ValidateUser(string username, string password);
    }
}
