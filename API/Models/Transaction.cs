using System;

namespace API.Models
{
    public class Transaction
    {
        public int TransactionID{get; set;}
        public int EmpID{get;set;}
        public int ItemID{get;set;}
        public DateTime CheckOutDate{get; set;}
        public DateTime DueDate{get; set;}
        public DateTime ReturnDate{get; set;} //? allows ReturnDate to be null
        public int AdminID{get; set;}

        public Transaction() //when a new transaction is created sets DueDate to two weeks from day of checkout
        {
            DueDate = DateTime.Now.AddDays(14);
            CheckOutDate = DateTime.Now;
            ReturnDate = new DateTime(1001,1,1);
        }
        
        
    }
}