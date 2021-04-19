using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Database;
using API.Interfaces;
using API.Interfaces.AdministratorInterfaces;
using API.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class adminController : ControllerBase
    {
        // GET: api/admin
        [EnableCors("AnotherPolicy")]
        [HttpGet]
        public List<Administrator> Get()
        {
            IGetAdministrators readObject = new ReadAdministrator();
            return readObject.GetAllAdministrators();
        }

        // GET: api/admin/5
        [EnableCors("AnotherPolicy")]
        [HttpGet("{id}", Name = "Getqqq")]
        public Administrator Get(int id)
        {
            IGetAdministrator readObject = new ReadAdministrator();
            return readObject.GetAdministrator(id);
        }

        // POST: api/admin
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/admin/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
