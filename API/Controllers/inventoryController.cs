using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Database;
using API.Interfaces;
using API.Interfaces.InventoryItemInterfaces;
using API.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class inventoryController : ControllerBase
    {
        // GET: api/inventory
        [EnableCors("AnotherPolicy")]
        [HttpGet]
        public List<InventoryItem> Get()
        {
            IGetInventoryItems readObject = new ReadInventoryItems();
            return readObject.GetAllInventoryItems();
        }

        // GET: api/inventory/5
        [EnableCors("AnotherPolicy")]
        [HttpGet("{id}", Name = "Get")]
        public InventoryItem Get(int id)
        {
            IGetInventoryItem readObject = new ReadInventoryItems();
            return readObject.GetInventoryItem(id);
        }

        // InventoryItem: api/inventory
        [EnableCors("AnotherPolicy")]
        [HttpPost]
        public void InventoryItem([FromBody] InventoryItem item)
        {
            IAddInventoryItem addObject = new SaveInventoryItemData();
            addObject.AddInventoryItem(item);
        }

        // PUT: api/inventory/5
        [EnableCors("AnotherPolicy")]
        [HttpPut("{id}")]
        public void PutItemName(int id, [FromBody] InventoryItem item)
        {
            IUpdateInventoryItem updateObject = new SaveInventoryItemData();
            updateObject.UpdateInventoryItemName(item);
        }
        [EnableCors("AnotherPolicy")]
        [HttpPut("{id}")]
        public void PutItemComments(int id, [FromBody] InventoryItem item)
        {
            IUpdateInventoryItem updateObject = new SaveInventoryItemData();
            updateObject.UpdateInventoryItemName(item);
        }
        [EnableCors("AnotherPolicy")]
        [HttpPut("{id}")]
        public void PutItemCheckedOutStatus(int id, [FromBody] InventoryItem item)
        {
            IUpdateInventoryItem updateObject = new SaveInventoryItemData();
            updateObject.UpdateInventoryItemName(item);
        }

        // DELETE: api/ApiWithActions/5
        [EnableCors("AnotherPolicy")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            IGetInventoryItems readObject = new ReadInventoryItems();
            List<InventoryItem> tempInventoryItems = new List<InventoryItem>();
            tempInventoryItems = readObject.GetAllInventoryItems();
            IDeleteInventoryItem deleteObject = new SaveInventoryItemData();
            InventoryItem tempInventoryItem = new InventoryItem();
            foreach(InventoryItem i in tempInventoryItems)
            {
                if(id== i.ItemID)
                {
                    tempInventoryItem = i;
                }
            }
            deleteObject.DeleteInventoryItem(tempInventoryItem);
        }
    }
}
