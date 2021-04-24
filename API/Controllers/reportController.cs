using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Database;
using API.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class reportController : ControllerBase
    {
        // GET: api/report/lost
        [EnableCors("AnotherPolicy")]
        [HttpGet("Lost")]
        public List<InventoryItem> GetLostItemsReport()
        {
            TransactionReport reportObject = new TransactionReport();
            List<InventoryItem> lostItems = reportObject.LostItemsReport();
            return lostItems;
        }
        // GET: api/report/overdue
        [EnableCors("AnotherPolicy")]
        [HttpGet("Overdue")]
        public List<OverdueReport> GetOverdueReport()
        {
            TransactionReport reportObject = new TransactionReport();
            List<OverdueReport> listOfOverdue = reportObject.OverdueStatus();
            return listOfOverdue;
        }
        // GET: api/report/damaged
        [EnableCors("AnotherPolicy")]
        [HttpGet("Damaged")]
        public List<InventoryItem> GetDamagedItemsReport()
        {
            TransactionReport reportObject = new TransactionReport();
            List<InventoryItem> damagedItems = reportObject.DamagedItemsReport();
            return damagedItems;
        }
        // GET: api/report/newest
        [EnableCors("AnotherPolicy")]
        [HttpGet("Newest")]
        public List<Transaction> TransactionsSortedByNewest()
        {
            TransactionReport reportObject = new TransactionReport();
            List<Transaction> newest = reportObject.TransactionsSortedByNewest();
            return newest;
        }
        // GET: api/report/oldest
        [EnableCors("AnotherPolicy")]
        [HttpGet("Oldest")]
        public List<Transaction> TransactionsSortedByOldest()
        {
            TransactionReport reportObject = new TransactionReport();
            List<Transaction> oldest = reportObject.TransactionsSortedByOldest();
            return oldest;
        }
        // GET: api/report
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        // GET: api/report/5
        [HttpGet("{id}", Name = "Getitt")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/report
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/report/5
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
