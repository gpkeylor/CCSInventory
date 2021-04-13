using System.Collections.Generic;
using API.Models;
using MySql.Data.MySqlClient;

namespace API.Database
{
    public class TransactionReport
    { 
        // checks to see if an item checked out is overdue or not
        public List<OverdueReport> OverdueStatus()
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);

            con.Open();

            string stm = "SELECT e.empid, e.empemail, t.itemID, t.itemname, DATEDIFF(day, t.duedate, GetDate()) as daysoverdue," + 
                "FROM transaction t join employee e on (t.empid = e.empid) WHERE DATEDIFF(day, t.duedate, GetDate()) > 0" +
                "AND t.returndate = '0000-00-00'";
            using var cmd = new MySqlCommand(stm,con);

            using MySqlDataReader rdr = cmd.ExecuteReader();

            List<OverdueReport> overdueList = new List<OverdueReport>();
            while(rdr.Read())
            {
                OverdueReport overdueReport = new OverdueReport(){EmpID = rdr.GetInt32(0), EmpEmail = rdr.GetString(1), 
                                                                DaysOverdue = rdr.GetInt32(2)};
                overdueList.Add(overdueReport);
            }
            return overdueList;
        }
        // if the item is lost the admin can hit 3 to mark it as lost
        public List<InventoryItem> LostItemsReport()
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);

            con.Open();

            string stm = "SELECT * FROM inventoryitem WHERE itemcomments like '3%'"; //3 is the set number indicating an item is lost/missing
            using var cmd = new MySqlCommand(stm,con);

            using MySqlDataReader rdr = cmd.ExecuteReader();

            List<InventoryItem> lostInventoryItems = new List<InventoryItem>();
            while(rdr.Read())
            {
                InventoryItem temp = new InventoryItem(){ItemID=rdr.GetInt32(0), ItemName=rdr.GetString(1), ItemComments = rdr.GetString(2), ItemCheckedOutStatus = rdr.GetInt32(3)};
                lostInventoryItems.Add(temp);
            }
            return lostInventoryItems;

        }
        // if an item that was checked out was damaged, the admin can press 2 to mark it as damaged
                public List<InventoryItem> DamagedItemsReport()
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);

            con.Open();

            string stm = "SELECT * FROM inventoryitem WHERE itemcomments like '2%'"; //2 is the set number indicating an item is damaged 
            using var cmd = new MySqlCommand(stm,con);

            using MySqlDataReader rdr = cmd.ExecuteReader();

            List<InventoryItem> damagedInventoryItems = new List<InventoryItem>();
            while(rdr.Read())
            {
                InventoryItem temp = new InventoryItem(){ItemID=rdr.GetInt32(0), ItemName=rdr.GetString(1), ItemComments = rdr.GetString(2), ItemCheckedOutStatus = rdr.GetInt32(3)};
                damagedInventoryItems.Add(temp);
            }
            return damagedInventoryItems;
        }
    }
}