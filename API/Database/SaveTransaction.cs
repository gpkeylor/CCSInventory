using API.Interfaces.TransactionInterfaces;
using API.Models;
using MySql.Data.MySqlClient;

namespace API.Database
{
    
    public class SaveTransaction : IAddTransaction, IDeleteTransaction, IUpdateTransactionReturnDate
    {
        public void AddTransaction(Transaction transaction) //Checkout Function 
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);

            con.Open();

            string stm = "INSERT INTO transaction (empid, itemid, checkoutdate, duedate, returndate, checkoutadminid , returnadminid) VALUES(@empid, @itemid, @checkoutdate, @duedate, @returndate, @checkoutadminid , @returnadminid)"; //don't need to insert checkedoutdate, duedate, returndate, or returnadminid 
            using var cmd = new MySqlCommand(stm,con);                                                         //because they are initialized in the constructor when a transaction is created
            cmd.Parameters.AddWithValue("@empid", transaction.EmpID);
            cmd.Parameters.AddWithValue("@itemid", transaction.ItemID);
            cmd.Parameters.AddWithValue("@checkoutdate", transaction.CheckOutDate);
            cmd.Parameters.AddWithValue("@checkoutdate", transaction.DueDate);
            cmd.Parameters.AddWithValue("@checkoutdate", transaction.ReturnDate);
            cmd.Parameters.AddWithValue("@checkoutadminid", transaction.CheckoutAdminID);
            cmd.Parameters.AddWithValue("@checkoutadminid", transaction.ReturnAdminID);
            cmd.Prepare();
            
            cmd.ExecuteNonQuery();
        }

        public void UpdateTransactionReturnDate(Transaction transaction) 
        {                                                                  
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);

            con.Open();

            string stm = "UPDATE Transaction SET returnadminID=@returnadminID, returndate = CurDate() WHERE transactionID = @transactionID";
            using var cmd = new MySqlCommand(stm,con);
            cmd.Parameters.AddWithValue("@transactionID", transaction.TransactionID);
            cmd.Parameters.AddWithValue("@returnadminID", transaction.ReturnAdminID);
            cmd.Prepare();
            
            cmd.ExecuteNonQuery();
        }
        public void DeleteTransaction(Transaction transaction) //Deletes transaction from database
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);

            con.Open();

            string stm = "DELETE FROM Transaction WHERE transactionID = @transactionID";
            using var cmd = new MySqlCommand(stm,con);
            cmd.Parameters.AddWithValue("@transactionID", transaction.TransactionID);
            cmd.Prepare();
            
            cmd.ExecuteNonQuery();
        }
    }
}