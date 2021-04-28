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

            string stm = "INSERT INTO transaction (empid, itemid, checkoutdate, duedate, returndate, checkoutadminID , returnadminID) VALUES(@empid, @itemid, @checkoutdate, @duedate, @returndate, @checkoutadminID , @returnadminID)"; 
            using var cmd = new MySqlCommand(stm,con);                                                       
            cmd.Parameters.AddWithValue("@empid", transaction.EmpID);
            cmd.Parameters.AddWithValue("@itemid", transaction.ItemID);
            cmd.Parameters.AddWithValue("@checkoutdate", transaction.CheckOutDate);
            cmd.Parameters.AddWithValue("@duedate", transaction.DueDate);
            cmd.Parameters.AddWithValue("@returndate", transaction.ReturnDate);
            cmd.Parameters.AddWithValue("@checkoutadminID", transaction.CheckoutAdminID);
            cmd.Parameters.AddWithValue("@returnadminID", transaction.ReturnAdminID);
            cmd.Prepare();
            
            cmd.ExecuteNonQuery();
        }

        public void UpdateTransactionReturnDate(Transaction transaction) 
        {                                                                  
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);

            con.Open();

            string stm = "UPDATE transaction SET returnadminID = @returnadminID, returndate = CurDate() WHERE transactionID = @transactionID";
            using var cmd = new MySqlCommand(stm,con);
            cmd.Parameters.AddWithValue("@returnadminID", transaction.ReturnAdminID);
            cmd.Parameters.AddWithValue("@transactionID", transaction.TransactionID);
            
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