using API.Models;
namespace API.Interfaces
{
    public interface IGetTransaction
    {
         public Transaction GetTransaction(int id);
    }
}