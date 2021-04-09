using API.Interfaces;
using API.Models;
using MySql.Data.MySqlClient;

namespace API.Database
{
    public class SaveInventoryItemData : IAddInventoryItem, IUpdateInventoryItem, IDeleteInventoryItem
    {
        public void AddInventoryItem(InventoryItem item)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);

            con.Open();

            string stm = "INSERT INTO inventoryitem (itemname, itemcomments, itemcheckedoutstatus) VALUES(@itemname, @itemcomments, @itemcheckedoutstatus)";
            using var cmd = new MySqlCommand(stm,con);
            cmd.Parameters.AddWithValue("@itemname", item.ItemName);
            cmd.Parameters.AddWithValue("@itemcomments", item.ItemComments);
            cmd.Parameters.AddWithValue("@itemcheckedoutstatus", item.ItemCheckedOutStatus);
            cmd.Prepare();
            
            cmd.ExecuteNonQuery();
        }

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
        public void UpdateInventoryItemComments(InventoryItem item)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);

            con.Open();

            string stm = "UPDATE inventoryitem SET itemcomments = @itemcomments WHERE itemID = @itemID";
            using var cmd = new MySqlCommand(stm,con);
            cmd.Parameters.AddWithValue("@itemID", item.ItemID);
            cmd.Parameters.AddWithValue("@itemname", item.ItemComments);
            cmd.Prepare();
            
            cmd.ExecuteNonQuery();
        }
        public void UpdateInventoryItemCheckedOutStatus(InventoryItem item)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);

            con.Open();

            string stm = "UPDATE inventoryitem SET itemcheckedoutstatus = @itemcheckedoutstatus WHERE itemID = @itemID";
            using var cmd = new MySqlCommand(stm,con);
            cmd.Parameters.AddWithValue("@itemID", item.ItemID);
            cmd.Parameters.AddWithValue("@itemname", item.ItemCheckedOutStatus);
            cmd.Prepare();
            
            cmd.ExecuteNonQuery();
        }
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