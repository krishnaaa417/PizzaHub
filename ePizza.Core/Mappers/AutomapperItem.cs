using ePizza.Domain.Models;
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
            List<ItemResponse> items = new List<ItemResponse>();
            if (itemlist.Any())
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
    }
}
