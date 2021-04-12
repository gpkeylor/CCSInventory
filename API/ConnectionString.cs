namespace API
{
    // using mySQL workbench
    public class ConnectionString
    {
        public string cs{get;  set;}

        public ConnectionString()
        {
            string server = "jhdjjtqo9w5bzq2t.cbetxkdyhwsb.us-east-1.rds.amazonaws.com";
            string database = "zpsfskh0flhfzhe6";
            string port= "3306";
            string username = "m173a7fuq4qs77yi";
            string password = "vegnyi6cl18z26ig";

            cs = $@"server = {server};user={username};database={database};port={port};password={password};";
        }
    }
}