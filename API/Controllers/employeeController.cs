using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Database;
using API.Interfaces;
using API.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class employeeController : ControllerBase
    {
        // GET: api/employee
        [EnableCors("AnotherPolicy")]
        [HttpGet]
        public List<Employee> Get()
        {
            IGetEmployees readObject = new ReadEmployee();
            return readObject.GetAllEmployees();
        }

        // GET: api/employee/5
        [EnableCors("AnotherPolicy")]
        [HttpGet("{id}", Name = "Gettttt")]
        public Employee Get(int id)
        {
            IGetEmployee readObject = new ReadEmployee();
            return readObject.GetEmployee(id);
        }

        // POST: api/employee
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/employee/5
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
