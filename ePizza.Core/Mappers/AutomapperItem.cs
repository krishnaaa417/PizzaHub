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
    public static class AutomapperItem
    {

        public static IEnumerable<ItemResponse> ConvertToItem(this IEnumerable<Item> itemlist)
        {
            List<ItemResponse> items = new List<ItemResponse>(); // this will store the converted items into items
            if (itemlist.Any()) // for checking the itemlist is empty or not.
            {
                foreach (var item in itemlist)
                {
                    ItemResponse itemResponse = new ItemResponse()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Description = item.Description,
                        UnitPrice = item.UnitPrice
                    };
                    items.Add(itemResponse);
                }
            }
            return items;
        }

        public static IEnumerable<ItemResponse> ConvertIntoItems(this IEnumerable<Item> items)
        {
            return items.Select(item => new ItemResponse
            {
                Id=item.Id,
                Name = item.Name,
                Description = item.Description,
                UnitPrice = item.UnitPrice
            });
        }

        public static IEnumerable<CreateUserRequest> ConvertIntoCreateUserRequest(this IEnumerable<User> users)
        {
            return users.Select(userr => new CreateUserRequest()
            {
                Name = userr.Name,
                Email = userr.Email,
                Password = userr.Password,
                PhoneNumber = userr.PhoneNumber,
            });
        }
    }
}
