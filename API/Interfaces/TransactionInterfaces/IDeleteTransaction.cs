using API.Models;

namespace API.Interfaces.TransactionInterfaces
{
    public interface IDeleteTransaction
    {
         public void DeleteTransaction(Transaction transaction);
    }
}