using API.Models;
using MySql.Data.MySqlClient;

namespace API.Database
{
    public class SaveInventoryItemData
    {
        public void AddInventoryItem(InventoryItem InventoryItem)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);

            con.Open();

            string stm = "INSERT INTO inventoryitems SET text = @text WHERE ID = @id";
            using var cmd = new MySqlCommand(stm,con);
            cmd.Parameters.AddWithValue("@transactionID",);
            cmd.Prepare();
            
            cmd.ExecuteNonQuery();
        }

        public void UpdateInventoryItem(InventoryItem InventoryItem)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);

            con.Open();

            string stm = "UPDATE InventoryItems SET text = @text WHERE ID = @id";
            using var cmd = new MySqlCommand(stm,con);
            cmd.Parameters.AddWithValue("@transactionID",);
            cmd.Prepare();
            
            cmd.ExecuteNonQuery();
            
        }
        public void DeleteInventoryItem(InventoryItem InventoryItem)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);

            con.Open();

            string stm = "DELETE FROM inventoryitem SET text = @text WHERE ID = @id";
            using var cmd = new MySqlCommand(stm,con);
            cmd.Parameters.AddWithValue("@transactionID",);
            cmd.Prepare();
            
            cmd.ExecuteNonQuery();
        }
    }
}