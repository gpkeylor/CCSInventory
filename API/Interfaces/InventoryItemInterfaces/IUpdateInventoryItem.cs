using API.Models;

namespace API.Interfaces
{
    public interface IUpdateInventoryItem
    {
         public void UpdateInventoryItemName(InventoryItem item);
         public void UpdateInventoryItem(InventoryItem item);
         public void UpdateInventoryItemCheckedOutStatus(InventoryItem item);
    }
}