using API.Interfaces;
using API.Models;
using MySql.Data.MySqlClient;

namespace API.Database
{
    public class SaveInventoryItemData : IAddInventoryItem, IUpdateInventoryItem, IDeleteInventoryItem
    {
        // if they want a new item to be added to inventory
        public void AddInventoryItem(InventoryItem item)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);

            con.Open();

            string stm = "INSERT INTO inventoryitem (itemname, itemcomments, itemcheckedoutstatus, datecommentsupdated) VALUES (@itemname, @itemcomments, @itemcheckedoutstatus,  @datecommentsupdated)";
            using var cmd = new MySqlCommand(stm,con);
            cmd.Parameters.AddWithValue("@itemname", item.ItemName);
            cmd.Parameters.AddWithValue("@itemcomments", item.ItemComments);
            cmd.Parameters.AddWithValue("@itemcheckedoutstatus", item.ItemCheckedOutStatus);
            cmd.Parameters.AddWithValue("@datecommentsupdated", item.DateCommentsUpdated);
            cmd.Prepare();
            
            cmd.ExecuteNonQuery();
        }
        // edits or updates a current inventory item in our database 
        public void UpdateInventoryItemName(InventoryItem item)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);

            con.Open();

            string stm = "UPDATE inventoryitem SET itemname = @itemname WHERE itemID = @itemID";
            using var cmd = new MySqlCommand(stm,con);
            cmd.Parameters.AddWithValue("@itemID", item.ItemID);
            cmd.Parameters.AddWithValue("@itemname", item.ItemName);
            cmd.Prepare();
            
            cmd.ExecuteNonQuery();
        }
        // edits the comments on a given inventory item
        public void UpdateInventoryItemComments(InventoryItem item)
        {
            
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);

            con.Open();

            string stm = "UPDATE inventoryitem SET itemcomments = @itemcomments, datecommentsupdated = CurDate(), itemcheckedoutstatus = @itemstatus WHERE itemID = @itemID";
            using var cmd = new MySqlCommand(stm,con);
            cmd.Parameters.AddWithValue("@itemID", item.ItemID);
            cmd.Parameters.AddWithValue("@itemcomments", item.ItemComments);
            cmd.Parameters.AddWithValue("@itemstatus", item.ItemCheckedOutStatus);
            cmd.Prepare();
            
            cmd.ExecuteNonQuery();
        }
        // updates the checked out status of an item
        public void UpdateInventoryItemCheckedOutStatus(InventoryItem item)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);

            con.Open();

            string stm = "UPDATE inventoryitem SET itemcheckedoutstatus = @itemcheckedoutstatus WHERE itemID = @itemID";
            using var cmd = new MySqlCommand(stm,con);
            cmd.Parameters.AddWithValue("@itemID", item.ItemID);
            cmd.Parameters.AddWithValue("@itemcheckedoutstatus", item.ItemCheckedOutStatus);
            cmd.Prepare();
            
            cmd.ExecuteNonQuery();
        }
         public void UpdateInventoryItemCheckedOutStatusReturned(InventoryItem item)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);

            con.Open();

            string stm = "UPDATE inventoryitem SET itemcheckedoutstatus = 0 WHERE itemID = @itemID";
            using var cmd = new MySqlCommand(stm,con);
            cmd.Parameters.AddWithValue("@itemID", item.ItemID);
            cmd.Prepare();
            
            cmd.ExecuteNonQuery();
        }
        // deletes item entirely from the database
        public void DeleteInventoryItem(InventoryItem item)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);

            con.Open();

            string stm = "DELETE FROM inventoryitem WHERE itemID = @itemID";
            using var cmd = new MySqlCommand(stm,con);
            cmd.Parameters.AddWithValue("@itemID", item.ItemID);
            cmd.Prepare();
            
            cmd.ExecuteNonQuery();
        }
    }
}