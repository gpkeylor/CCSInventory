namespace API.Models
{
    public class OverdueReport
    {
        //These values are determined in sql statement in TransactionReport class OverdueStatus()
        public int EmpID{get; set;}
        public string EmpEmail{get; set;}
        public int DaysOverdue{get; set;}
    }
}