using System.Collections.Generic;
using API.Interfaces;
using API.Models;
using MySql.Data.MySqlClient;

namespace API.Database
{
    public class ReadInventoryItems : IGetInventoryItems, IGetInventoryItem
    {
        public List<InventoryItem> GetAllInventoryItems()
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);

            con.Open();

            string stm = "SELECT * FROM inventoryitem";
            using var cmd = new MySqlCommand(stm,con);

            using MySqlDataReader rdr = cmd.ExecuteReader();

            List<InventoryItem> myInventoryItems = new List<InventoryItem>();
            while(rdr.Read())
            {
                InventoryItem temp = new InventoryItem(){ItemID=rdr.GetInt32(0), ItemName=rdr.GetString(1), ItemComments = rdr.GetString(2), ItemCheckedOutStatus = rdr.GetInt32(3)};
                myInventoryItems.Add(temp);
            }
            return myInventoryItems;
        }

        public InventoryItem GetInventoryItem(int itemid)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);

            con.Open();

            string stm = "SELECT * FROM inventoryitem WHERE itemID = @itemID";
            using var cmd = new MySqlCommand(stm,con);
            cmd.Parameters.AddWithValue("@itemID", itemid);
            cmd.Prepare();

            using MySqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            InventoryItem item = new InventoryItem(){ItemID=rdr.GetInt32(0), ItemName=rdr.GetString(1), ItemComments = rdr.GetString(2), ItemCheckedOutStatus = rdr.GetInt32(3)};
            return item;
        }
    }
}