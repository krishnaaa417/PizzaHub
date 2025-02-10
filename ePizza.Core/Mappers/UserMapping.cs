using AutoMapper;
using ePizza.Domain.Models;
using ePizza.Models.Request;
using ePizza.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePizza.Core.Mappers
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<User,UserResponseModel>()
                .ForMember(dest => dest.Id,src => src.MapFrom(src =>src.Id))
                .ReverseMap();
            CreateMap<User, CreateUserRequest>();
        }
    }
}
