using System.Collections.Generic;
using API.Models;

namespace API.Interfaces
{
    public interface IGetEmployees
    {
         public List<Employee> GetAllEmployees();
    }
}