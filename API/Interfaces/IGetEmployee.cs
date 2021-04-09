using API.Models;

namespace API.Interfaces
{
    public interface IGetEmployee
    {
         public Employee GetEmployee(int empid);
    }
}