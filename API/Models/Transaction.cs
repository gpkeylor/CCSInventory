using System;
namespace API.Models
{
    public class Transaction
    {
        public int TransactionID{get; set;}
        public DateTime CheckOutDate{get; set;}
        public DateTime DueDate{get; set;}
        public DateTime ReturnDate{get; set;}
        public int AdminID{get; set;}
        public int EmpID{get;set;}
        public int ItemID{get;set;}
    }
}