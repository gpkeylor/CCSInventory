namespace API
{
    
    public class ConnectionString
    {
        public string cs{get;  set;}

        // using mySQL workbench to see the database values 
        public ConnectionString()
        {
            string server = "pfw0ltdr46khxib3.cbetxkdyhwsb.us-east-1.rds.amazonaws.com";
            string database = "f5d637nx5mqu2fjb";
            string port= "3306";
            string username = "zq5omzpqeisigum2";
            string password = "ic50ttdtvjsswvz3";

            cs = $@"server = {server};user={username};database={database};port={port};password={password};";
        }
    }
}