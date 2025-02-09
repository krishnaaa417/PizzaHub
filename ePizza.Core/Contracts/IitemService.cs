using ePizza.Domain.Models;
using ePizza.Models.Request;
using ePizza.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePizza.Core.Contracts
{
    public interface IitemService 
    {
        IEnumerable<ItemResponse> GetAllItems();

        Item AddItem(ItemRequest request);
    }
}
