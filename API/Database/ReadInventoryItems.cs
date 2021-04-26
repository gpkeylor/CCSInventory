using System.Collections.Generic;
using API.Interfaces;
using API.Interfaces.InventoryItemInterfaces;
using API.Models;
using MySql.Data.MySqlClient;

namespace API.Database
{
    public class ReadInventoryItems : IGetInventoryItems, IGetInventoryItem
    {
        // gets all the items
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
                InventoryItem temp = new InventoryItem(){ItemID=rdr.GetInt32(0), ItemName=rdr.GetString(1), ItemComments = rdr.GetString(2), DateCommentsUpdated = rdr.GetDateTime(3), ItemCheckedOutStatus = rdr.GetInt32(4)};
                myInventoryItems.Add(temp);
            }
            return myInventoryItems;
        }
        // gets the given individual inventory item
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
            InventoryItem item = new InventoryItem(){ItemID=rdr.GetInt32(0), ItemName=rdr.GetString(1), ItemComments = rdr.GetString(2), DateCommentsUpdated = rdr.GetDateTime(3), ItemCheckedOutStatus = rdr.GetInt32(4)};
            return item;
        }
        //Gets all distinct item names of inventoryitems avaialable to rent (items not checkedout and not damaged or missing)
        public List<ItemName> GetInventoryItemNamesAvaialableToCheckOut()
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);

            con.Open();

            string stm = "SELECT DISTINCT itemname, itemID FROM inventoryitem WHERE itemcheckedoutstatus <> 1 AND itemcomments like '1%'";
            using var cmd = new MySqlCommand(stm,con);

            using MySqlDataReader rdr = cmd.ExecuteReader();

            List<ItemName> myInventoryItems = new List<ItemName>();
            while(rdr.Read())
            {
                ItemName temp = new ItemName(){Name = rdr.GetString(0), ItemID =rdr.GetInt32(1)};
                myInventoryItems.Add(temp);
            }
            return myInventoryItems;
        }
    }
    
}