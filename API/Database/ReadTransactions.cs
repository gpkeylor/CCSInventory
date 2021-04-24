using System.Collections.Generic;
using API.Interfaces;
using API.Interfaces.TransactionInterfaces;
using API.Models;
using MySql.Data.MySqlClient;

namespace API.Database
{
    public class ReadTransactions : IGetTransactions, IGetTransaction, IGetEmployeeTransactions
    {
        //  gets the past transcations from db
        public List<Transaction> GetAllTransactions()
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);

            con.Open();

            string stm = "SELECT * FROM transaction";
            using var cmd = new MySqlCommand(stm,con);

            using MySqlDataReader rdr = cmd.ExecuteReader();

            List<Transaction> myTransactions = new List<Transaction>();
            while(rdr.Read())
            {
                Transaction transaction = new Transaction(){TransactionID=rdr.GetInt32(0), EmpID = rdr.GetInt32(1),ItemID = rdr.GetInt32(2), CheckOutDate=rdr.GetDateTime(3), 
                                                            DueDate = rdr.GetDateTime(4), ReturnDate = rdr.GetDateTime(5), CheckoutAdminID = rdr.GetInt32(6), ReturnAdminID = rdr.GetInt32(7)};
                myTransactions.Add(transaction);
            }
            return myTransactions;
        }
        // gets a given individual transaction
        public Transaction GetTransaction(int transactionid)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);

            con.Open();

            string stm = "SELECT * FROM transaction WHERE transactionID = @transactionID";
            using var cmd = new MySqlCommand(stm,con);
            cmd.Parameters.AddWithValue("@transactionID", transactionid);
            cmd.Prepare();

            using MySqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            Transaction transaction = new Transaction(){TransactionID=rdr.GetInt32(0), EmpID = rdr.GetInt32(1),ItemID = rdr.GetInt32(2), CheckOutDate=rdr.GetDateTime(3), 
                                                            DueDate = rdr.GetDateTime(4), ReturnDate = rdr.GetDateTime(5), CheckoutAdminID = rdr.GetInt32(6), ReturnAdminID = rdr.GetInt32(7)};
            return transaction;
        }
        //gets all transactions for a specified employee
        public List<Transaction> GetEmployeeTransactions(int empid)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);

            con.Open();

            string stm = "SELECT * FROM transaction t join employee e on (t.empid = e.empid)";
            using var cmd = new MySqlCommand(stm,con);
            cmd.Parameters.AddWithValue("@empID", empid);
            cmd.Prepare();

            using MySqlDataReader rdr = cmd.ExecuteReader();
            List<Transaction> empTransactions = new List<Transaction>();
            while(rdr.Read())
            {
                Transaction transaction = new Transaction(){TransactionID=rdr.GetInt32(0), EmpID = rdr.GetInt32(1),ItemID = rdr.GetInt32(2), CheckOutDate=rdr.GetDateTime(3), 
                                                            DueDate = rdr.GetDateTime(4), ReturnDate = rdr.GetDateTime(5), CheckoutAdminID = rdr.GetInt32(6), ReturnAdminID = rdr.GetInt32(7)};
                empTransactions.Add(transaction);
            }
            return empTransactions;
        }
        //gets all unreturned transactions for a specified employee 
        public List<Transaction> GetEmployeeTransactionsToReturn(int empid)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);

            con.Open();

            string stm = "SELECT * FROM transaction t join employee e on (t.empID = e.empID) WHERE returndate = '1001-01-01'";
            using var cmd = new MySqlCommand(stm,con);
            cmd.Parameters.AddWithValue("@empID", empid);
            cmd.Prepare();

            using MySqlDataReader rdr = cmd.ExecuteReader();
            List<Transaction> empTransactions = new List<Transaction>();
            while(rdr.Read())
            {
                Transaction transaction = new Transaction(){TransactionID=rdr.GetInt32(0), EmpID = rdr.GetInt32(1),ItemID = rdr.GetInt32(2), CheckOutDate=rdr.GetDateTime(3), 
                                                            DueDate = rdr.GetDateTime(4), ReturnDate = rdr.GetDateTime(5), CheckoutAdminID = rdr.GetInt32(6), ReturnAdminID = rdr.GetInt32(7)};
                empTransactions.Add(transaction);
            }
            return empTransactions;
        }


    }
}