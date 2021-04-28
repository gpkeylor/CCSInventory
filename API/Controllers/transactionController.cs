using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Database;
using API.Interfaces;
using API.Interfaces.InventoryItemInterfaces;
using API.Interfaces.TransactionInterfaces;
using API.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class transactionController : ControllerBase
    {
        [EnableCors("AnotherPolicy")]
        [HttpGet]
        public List<Transaction> Get()
        {
            IGetTransactions readObject = new ReadTransactions();
            return readObject.GetAllTransactions();
        }
        //GET: api/transactions/emptransactions
        [EnableCors("AnotherPolicy")]
        [HttpGet ("emptransactions")]
        public List<Transaction> GetEmployeeTransactions(int empid)
        {
            IGetEmployeeTransactions readObject = new ReadTransactions();
            return readObject.GetEmployeeTransactions(empid);
        }
        //GET: api/transactions/emptransactionsreturn
        [EnableCors("AnotherPolicy")]
        [HttpGet ("emptransactionsreturn")]
        public List<Transaction> GetUnreturnedEmployeeTransactions(int empid)
        {
            ReadTransactions readObject = new ReadTransactions();
            return readObject.GetEmployeeTransactionsToReturn(empid);
        }

        // GET: api/transaction/5 Name = "Getit
        [EnableCors("AnotherPolicy")]
        [HttpGet("{id}")]
        public Transaction Get(int id)
        {
            IGetTransaction readObject = new ReadTransactions();
            return readObject.GetTransaction(id);
        }

        // Transaction: api/transaction
        [EnableCors("AnotherPolicy")]
        [HttpPost]
        public void Transaction([FromBody] Transaction transaction)
        {
            IAddTransaction addObject = new SaveTransaction();
            addObject.AddTransaction(transaction);
        }
        // PUT: api/transaction/5
        [EnableCors("AnotherPolicy")]
        [HttpPut("{id}")]
        public void Put([FromBody] Transaction item) //Used when returning an item to update it to current date
        {
            IUpdateTransactionReturnDate updateObject = new SaveTransaction();
            updateObject.UpdateTransactionReturnDate(item);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            IGetTransactions readObject = new ReadTransactions();
            List<Transaction> tempTransactions = new List<Transaction>();
            tempTransactions = readObject.GetAllTransactions();
            IDeleteTransaction deleteObject = new SaveTransaction();
            Transaction tempTransaction = new Transaction();
            foreach(Transaction t in tempTransactions)
            {
                if(id== t.TransactionID)
                {
                    tempTransaction = t;
                }
            }
            deleteObject.DeleteTransaction(tempTransaction);
        }
    }
}
