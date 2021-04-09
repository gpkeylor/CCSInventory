using System.Collections.Generic;
using API.Models;
using MySql.Data.MySqlClient;

namespace API.Database
{
    public class TransactionReport
    {
        public List<OverdueReport> OverdueStatus()
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);

            con.Open();

            string stm = "SELECT e.empid, e.empemail, DATEDIFF(day, t.duedate, GetDate()) as daysoverdue" + 
                "FROM transaction t join employee e on (t.empid = e.empid) WHERE DATEDIFF(day, t.duedate, GetDate()) > 0";
            using var cmd = new MySqlCommand(stm,con);

            using MySqlDataReader rdr = cmd.ExecuteReader();

            List<OverdueReport> overdueList = new List<OverdueReport>();
            while(rdr.Read())
            {
                OverdueReport overdueReport = new OverdueReport(){EmpEmail = rdr.GetString(0), DaysOverdue = rdr.GetInt32(1)};
                overdueList.Add(overdueReport);
            }
            return overdueList;
        }
    }
}