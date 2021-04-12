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

            string stm = "INSERT INTO transaction (empid, itemid, adminid) VALUES(@empid, @itemid, @adminid)"; //don't need to insert checkedoutdate, duedate, or returndate 
            using var cmd = new MySqlCommand(stm,con);                                                         //because they are initialized in the constructor when a transaction is created
            cmd.Parameters.AddWithValue("@empid", transaction.EmpID);
            cmd.Parameters.AddWithValue("@transactioncomments", transaction.ItemID);
            cmd.Parameters.AddWithValue("@transactioncheckedoutstatus", transaction.AdminID);
            cmd.Prepare();
            
            cmd.ExecuteNonQuery();
        }

        public void UpdateTransactionReturnDate(Transaction transaction) //ReturnTransaction
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);

            con.Open();

            string stm = "UPDATE Transaction SET returndate = @returndate WHERE transactionID = @transactionID";
            using var cmd = new MySqlCommand(stm,con);
            cmd.Parameters.AddWithValue("@transactionID", transaction.TransactionID);
            cmd.Parameters.AddWithValue("@returndate", transaction.ReturnDate);
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