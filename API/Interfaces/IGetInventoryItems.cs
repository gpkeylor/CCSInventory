using System.Collections.Generic;
using API.Models;

namespace API.Interfaces
{
    public interface IGetInventoryItems
    {
         public List<InventoryItem> GetAllInventoryItems();
    }
}