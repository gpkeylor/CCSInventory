using System.Collections.Generic;
using API.Models;

namespace API.Interfaces
{
    public interface IGetAdministrators
    {
         public List<Administrator> GetAllAdministrators();
    }
}