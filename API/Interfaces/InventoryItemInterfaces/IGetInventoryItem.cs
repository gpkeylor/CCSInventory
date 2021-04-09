using API.Models;

namespace API.Interfaces.InventoryItemInterfaces
{
    public interface IGetInventoryItem
    {
         public InventoryItem GetInventoryItem(int id);
    }
}