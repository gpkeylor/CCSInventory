function start()
{
    getDeleteInventoryItems();
    getUpdateInventoryItems();
}

function addInventoryItem()
{
    const postItemApiUrl = "https://localhost:5001/api/inventory";
    const ItemName = document.getElementById("inventoryitem").value;
    let item = {
        ItemName : ItemName
    };
    console.log(item);
    fetch(postItemApiUrl,
    {
        method : "POST",
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json",
        },
    body:JSON.stringify(item)
    }).then((response)=>{
        console.log(response);
    });
}
//gets inventory items
function getDeleteInventoryItems()
{
    const allItemApiUrl = "https://localhost:5001/api/inventory";
    fetch(allItemApiUrl).then(function(response){
        return response.json();
    }).then(function(json){
        console.log(json);
        let html= "<table class=\"table-bordered table-hover\">";
        html+= "<tr><th><b>ItemID</th><th><b>Item Name</th>";
        html+= "<th><b>Item Comments</th><th><b>Date Comments Updated</th>";
        html+= "<th><b>Checked Out Status</th><th></th>";
        json.forEach(inventoryItem => {
            html += "<tr><td>" + inventoryItem.itemID + "</td><td>" + inventoryItem.itemName + "</td><td>" 
            + inventoryItem.itemComments + "</td><td>" + inventoryItem.dateCommentsUpdated + "</td>"+ "<td>" 
            + inventoryItem.itemCheckedOutStatus + "</td><td><button class =\"btn-primary\" onclick = \"deleteInventoryItem("+inventoryItem.itemID+")\">Delete</button></tr>";
        });
        html += "</ul";
        document.getElementById("deleteinventory").innerHTML = html;
    }).catch(function(error)
    {
        console.log(error);
    });
}

function deleteInventoryItem(id)
{
    const deleteApiUrl = "https://localhost:5001/api/inventory/"+ id;
 
    fetch(deleteApiUrl,
    {
        method : "DELETE",
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json"
        },
    }).then((response)=>{
        console.log(response);
        getInventoryItem();
    });
}

function getUpdateInventoryItems()
{
    const allItemApiUrl = "https://localhost:5001/api/inventory";
    fetch(allItemApiUrl).then(function(response){
        return response.json();
    }).then(function(json){
        console.log(json);
        let html= "<table class=\"table-bordered table-hover\">";
        html+= "<tr><th><b>ItemID</th><th><b>Item Name</th>";
        html+= "<th><b>Item Comments</th><th><b>Date Comments Updated</th>";
        html+= "<th><b>Checked Out Status</th><th></th>";
        json.forEach(inventoryItem => {
            html += "<tr><td>" + inventoryItem.itemID + "</td><td>" + inventoryItem.itemName + "<br><button class =\"btn-primary\" onclick = \"updateItemName("+inventoryItem.itemID+")\">Update</button></td><td>" 
            + inventoryItem.itemComments + "<br><button class =\"btn-primary\" onclick = \"updateItemComments("+inventoryItem.itemID+")\">Update</button></td><td>" + inventoryItem.dateCommentsUpdated + "</td>"+ "<td>" 
            + inventoryItem.itemCheckedOutStatus + "<br><button class =\"btn-primary\" onclick = \"updateItemCheckedOutStatus("+inventoryItem.itemID+")\">Update</button></td><td></td></tr>";
        });
        html += "</ul";
        document.getElementById("updateinventory").innerHTML = html;
    }).catch(function(error)
    {
        console.log(error);
    });
}