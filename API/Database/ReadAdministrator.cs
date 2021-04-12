using System.Collections.Generic;
using API.Interfaces;
using API.Interfaces.AdministratorInterfaces;
using API.Models;
using MySql.Data.MySqlClient;

namespace API.Database
{
    public class ReadAdministrator : IGetAdministrators, IGetAdministrator
    {
        // gets the admin data
        public List<Administrator> GetAllAdministrators()
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);

            con.Open();

            string stm = "SELECT * FROM administrator";
            using var cmd = new MySqlCommand(stm,con);

            using MySqlDataReader rdr = cmd.ExecuteReader();

            List<Administrator> myAdministrators = new List<Administrator>();
            while(rdr.Read())
            {
                Administrator temp = new Administrator(){AdminID=rdr.GetInt32(0), AdminName=rdr.GetString(1), AdminEmail = rdr.GetString(2)};
                myAdministrators.Add(temp);
            }
            return myAdministrators;
        }

        // searches if admin ID exists
        public Administrator GetAdministrator(int adminid)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);

            con.Open();

            string stm = "SELECT * FROM administrator WHERE adminID = @AdminID";
            using var cmd = new MySqlCommand(stm,con);
            cmd.Parameters.AddWithValue("@adminID", adminid);
            cmd.Prepare();

            using MySqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            Administrator admin = new Administrator(){AdminID=rdr.GetInt32(0), AdminName=rdr.GetString(1), AdminEmail = rdr.GetString(2)};
            return admin;
        }
    }
}