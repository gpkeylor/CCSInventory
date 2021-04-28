using System;

namespace API.Models
{
    public class InventoryItem
    {
        public int ItemID{get; set;}
        public string ItemName{get; set;}
        public string ItemComments{get;set;}
        public int ItemCheckedOutStatus{get; set;}
        public DateTime DateCommentsUpdated{get; set;}

        //When a new item is created, automatically sets checkedoutstatus to 0, itemcomments to 1 (perfect condtions),
        // and datecommentsupdated to the current date
        public InventoryItem()
        {
            ItemCheckedOutStatus = 0;
            ItemComments = "1. Perfect condition, available to be rented.";
            DateCommentsUpdated = DateTime.Now;
        }
    }
}