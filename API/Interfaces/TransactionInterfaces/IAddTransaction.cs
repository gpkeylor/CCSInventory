using API.Models;

namespace API.Interfaces.TransactionInterfaces
{
    public interface IAddTransaction
    {
         public void AddTransaction(Transaction transaction);
    }
}