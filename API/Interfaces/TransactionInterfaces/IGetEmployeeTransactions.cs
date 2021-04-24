using System.Collections.Generic;
using API.Models;

namespace API.Interfaces.TransactionInterfaces
{
    public interface IGetEmployeeTransactions
    {
         public List<Transaction> GetEmployeeTransactions(int id);
    }
}