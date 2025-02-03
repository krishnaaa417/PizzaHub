using ePizza.Domain.Models;
using ePizza.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePizza.Core.Mappers
{
    public static class UserMappingExtension
    {
// my motive is to convert the domain model code into business class model
            
        public static IEnumerable<UserResponseModel> ConvertToUserResponseModel(this IEnumerable<User> userList)
        {
            List<UserResponseModel> userResponseModelList = new List<UserResponseModel>();

            if (userList.Any())
            {
                foreach (var user in userList)
                {

                    UserResponseModel userResponseModel = new UserResponseModel()
                    {
                        Id = user.Id,
                        Name = user.Name,
                        Email = user.Email,
                        Password = user.Password,
                        PhoneNumber = user.PhoneNumber,
                        CreatedDate = user.CreatedDate
                    };
                    userResponseModelList.Add(userResponseModel);
                }
            }
            return userResponseModelList;
        }

        public static IEnumerable<UserResponseModel> ConvertToUserResponseModelUsingLinq(this IEnumerable<User> userList)
        {
            return userList.Select(x => x.ConvertToUserResponseModelUsingLinq());
        }

        public static UserResponseModel ConvertToUserResponseModelUsingLinq(this User user)
        {
            return new UserResponseModel()
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                PhoneNumber = user.PhoneNumber,
                CreatedDate = user.CreatedDate
            };

        }
    }
}
