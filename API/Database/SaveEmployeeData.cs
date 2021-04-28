using API.Models;
using MySql.Data.MySqlClient;

namespace API.Database
{
    public class SaveEmployeeData
    {
        public void AddEmployeeNoOfItemsCheckedOut(Employee employee)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);

            con.Open();

            string stm = "UPDATE employee SET noofitemscheckedout = noofitemscheckedout + 1 WHERE empID = @empID";
            using var cmd = new MySqlCommand(stm,con);
            cmd.Parameters.AddWithValue("@empID", employee.EmpID);
            cmd.Prepare();
            
            cmd.ExecuteNonQuery();
        }
        public void SubtractEmployeeNoOfItemsCheckedOut(Employee employee)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);

            con.Open();

            string stm = "UPDATE employee SET noofitemscheckedout = noofitemscheckedout -1 WHERE empID = @empID";
            using var cmd = new MySqlCommand(stm,con);
            cmd.Parameters.AddWithValue("@empID", employee.EmpID);
            cmd.Prepare();
            
            cmd.ExecuteNonQuery();
        }
    }
}