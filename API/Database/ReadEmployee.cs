using System.Collections.Generic;
using API.Interfaces;
using API.Models;
using MySql.Data.MySqlClient;

namespace API.Database
{
    public class ReadEmployee : IGetEmployees, IGetEmployee
    {
        // gets all the employees
        public List<Employee> GetAllEmployees()
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);

            con.Open();

            string stm = "SELECT * FROM employee";
            using var cmd = new MySqlCommand(stm,con);

            using MySqlDataReader rdr = cmd.ExecuteReader();

            List<Employee> myEmployees = new List<Employee>();
            while(rdr.Read())
            {
                Employee temp = new Employee(){EmpID=rdr.GetInt32(0), EmpName=rdr.GetString(1), EmpEmail = rdr.GetString(2), NoOfItemsCheckedOut = rdr.GetInt32(3)};
                myEmployees.Add(temp);
            }
            return myEmployees;
        }

        // finds a given employee, searches the database to find each individual
        public Employee GetEmployee(int empid)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);

            con.Open();

            string stm = "SELECT * FROM employee WHERE empID = @EmpID";
            using var cmd = new MySqlCommand(stm,con);
            cmd.Parameters.AddWithValue("@empID", empid);
            cmd.Prepare();

            using MySqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            Employee Emp = new Employee(){EmpID=rdr.GetInt32(0), EmpName=rdr.GetString(1), EmpEmail = rdr.GetString(2), NoOfItemsCheckedOut = rdr.GetInt32(3)};
            return Emp;
        }
    }
}