using API.Models;

namespace API.Interfaces.AdministratorInterfaces
{
    public interface IGetAdministrator
    {
         public Administrator GetAdministrator(int id);
    }
}