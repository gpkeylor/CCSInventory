namespace API.Models
{
    public class InventoryItem
    {
        public int ItemID{get; set;}
        public string ItemName{get; set;}
        public string ItemComments{get;set;}
        public int ItemCheckedOutStatus{get; set;}

        public InventoryItem()
        {
            ItemCheckedOutStatus = 0;
        }
    }
}