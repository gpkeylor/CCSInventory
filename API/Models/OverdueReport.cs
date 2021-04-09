namespace API.Models
{
    public class OverdueReport
    {
        public int EmpID{get; set;}
        public string EmpEmail{get; set;}
        public int DaysOverdue{get; set;}
    }
}