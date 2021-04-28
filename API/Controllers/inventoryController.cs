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
        [EnableCors("AnotherPolicy")]
        [HttpGet ("ItemNames")]
        //Gets all distinct item names of inventoryitems avaialable to rent (items not checkedout and not damaged or missing)
        public List<ItemName> GetInventoryNamesToCheckout() 
        {
            ReadInventoryItems readObject = new ReadInventoryItems();
            return readObject.GetInventoryItemNamesAvaialableToCheckOut();
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
        [HttpPut("itemname/{id}")]
        public void PutInventoryItemNam([FromBody] InventoryItem item)
        {
            IUpdateInventoryItem updateObject = new SaveInventoryItemData();
            updateObject.UpdateInventoryItemName(item);
        }
        [EnableCors("AnotherPolicy")]
        [HttpPut("itemcomments/{id}")] //I think this is how you decorate the http in order to update just comments
        public void PutItemComments(int id, [FromBody] InventoryItem item)
        {
            IUpdateInventoryItem updateObject = new SaveInventoryItemData();
            updateObject.UpdateInventoryItemComments(item);
        }
        [EnableCors("AnotherPolicy")]
        [HttpPut("itemcheckedoutstatus/{id}")]//I think this is how you decorate the http in order to update just checkedoutstatus
        public void PutItemCheckedOutStatus(int id, [FromBody] InventoryItem item)
        {
            IUpdateInventoryItem updateObject = new SaveInventoryItemData();
            updateObject.UpdateInventoryItemCheckedOutStatus(item);
        }
        [EnableCors("AnotherPolicy")]
        [HttpPut("itemcheckedoutstatusreturned/{id}")]//I think this is how you decorate the http in order to update just checkedoutstatus
        public void PutItemCheckedOutStatusReturned(int id, [FromBody] InventoryItem item)
        {
            IUpdateInventoryItem updateObject = new SaveInventoryItemData();
            updateObject.UpdateInventoryItemCheckedOutStatusReturned(item);
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
