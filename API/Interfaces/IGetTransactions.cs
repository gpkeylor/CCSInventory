using API.Models;
using System.Collections.Generic;
namespace API.Interfaces
{
    public interface IGetTransactions
    {
         public List<Transaction> GetAllTransactions();
    }
}