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
        public DateTime ReturnDate{get; set;} 
        public int CheckoutAdminID{get; set;}
        public int ReturnAdminID{get; set;} //needed because return admin may be different thatn admin at checkout

        public Transaction() //when a new transaction is created sets DueDate to two weeks from day of checkout
        {
            DueDate = DateTime.Now.AddDays(14); 
            CheckOutDate = DateTime.Now; //current date that the transaction is instantiated
            ReturnDate = new DateTime(1001,1,1); //acts as a placeholder - basically same as a null value until the item is returned and the return date is updated
            ReturnAdminID = 0; //acts as a placeholder - basically same as null value until the item is returned by an admin
        }
        
        
    }
}