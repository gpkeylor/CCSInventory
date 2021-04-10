using System.Collections.Generic;
using API.Interfaces;
using API.Models;
using MySql.Data.MySqlClient;

namespace API.Database
{
    public class ReadTransactions : IGetTransactions, IGetTransaction
    {
        public List<Transaction> GetAllTransactions()
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);

            con.Open();

            string stm = "SELECT * FROM Transaction";
            using var cmd = new MySqlCommand(stm,con);

            using MySqlDataReader rdr = cmd.ExecuteReader();

            List<Transaction> myTransactions = new List<Transaction>();
            while(rdr.Read())
            {
                Transaction transaction = new Transaction(){TransactionID=rdr.GetInt32(0), EmpID = rdr.GetInt32(1),ItemID = rdr.GetInt32(2), CheckOutDate=rdr.GetDateTime(3), 
                                                            DueDate = rdr.GetDateTime(4), ReturnDate = rdr.GetDateTime(5), AdminID = rdr.GetInt32(6)};
                myTransactions.Add(transaction);
            }
            return myTransactions;
        }
        public Transaction GetTransaction(int transactionid)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);

            con.Open();

            string stm = "SELECT * FROM Transaction WHERE transactionID = @transactionID";
            using var cmd = new MySqlCommand(stm,con);
            cmd.Parameters.AddWithValue("@transactionID", transactionid);
            cmd.Prepare();

            using MySqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            Transaction transaction = new Transaction(){TransactionID=rdr.GetInt32(0), EmpID = rdr.GetInt32(1),ItemID = rdr.GetInt32(2), CheckOutDate=rdr.GetDateTime(3), 
                                                            DueDate = rdr.GetDateTime(4), ReturnDate = rdr.GetDateTime(5), AdminID = rdr.GetInt32(6)};
            return transaction;
        }
    }
}