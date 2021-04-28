using API.Models;

namespace API.Interfaces
{
    public interface IUpdateInventoryItem
    {
         public void UpdateInventoryItemName(InventoryItem item);
         public void UpdateInventoryItemComments(InventoryItem item);
         public void UpdateInventoryItemCheckedOutStatus(InventoryItem item);
        public void UpdateInventoryItemCheckedOutStatusReturned(InventoryItem item);

         
    }
}