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
            html += "<tr><td>" + inventoryItem.itemID + "</td><td>" + inventoryItem.itemName + "<br><input name='choice' value = \"name\" type=\"radio\" onclick = \"updateItemChoice("+inventoryItem.itemID+")\"></td><td>" 
            + inventoryItem.itemComments + "<br><input name='choice' value=\"comments\" type=\"radio\" onclick = \"updateItemChoice("+inventoryItem.itemID+")\"></td><td>" + inventoryItem.dateCommentsUpdated + "</td>"+ "<td>" 
            + inventoryItem.itemCheckedOutStatus + "<br><input name='choice' value=\"checkedout\" type=\"radio\" onclick = \"updateItemChoice("+inventoryItem.itemID+")\"></td><td></td></tr>";
        });
        html += "</ul";
        document.getElementById("updateinventory").innerHTML = html;
    }).catch(function(error)
    {
        console.log(error);
    });

}

var updateChoice;
var userChoice;
function updateItemChoice(id){
    updateChoice = document.getElementsByName('choice');
    for(i=0; i<updateChoice.length;i++){
        if(updateChoice[i].checked){
            userChoice = updateChoice[i].value
        }
    }
}
function updateItem(userChoice, id)
{
    const itemAPI = "https://localhost:5001/api/inventory";
    const name;
    const comments;
    const itemcheckedoutstatus;
    fetch(itemAPI).then(function(response){
        return response.json();
    }).then(function(json){
        console.log(json);
    }).then(function(json){
        console.log(json);
        json.forEach(item => {
            if(id == item.itemID)
            {
                name = item.itemName;
                comments = item.itemComments;
                datecommentsupated = item.dateCommentsUpdated;
                itemcheckedoutstatus = item.itemCheckedOutStatus;
            }
        })
    })
    if(userChoice == "name")
    {
        const itemNameAPI = "https://localhost:5001/api/inventory/itemname/" + id;
        name = document.getElementById("updateValue").value ;
        const updatedItem ={
                itemID: id,
                itemName: name,
                itemComments: comments, 
                itemCheckedOutStatus: itemcheckedoutstatus
            }
        fetch(itemNameAPI, {
                method: "PUT",
                headers: {
                    "Accept" : "application/json",
                    "Content-Type" : "application/json"
                },
                body: JSON.stringify(updatedItem)
        }).then((response)=>{
            console.log(response);
            getUpdateInventoryItems();
        })
    }
    if(userChoice == "comments")
    {
        const itemNameAPI = "https://localhost:5001/api/inventory/itemcomments/" + id;
        comments = document.getElementById("updateValue").value ;
        const updatedItem ={
                itemID: id,
                itemName: name,
                itemComments: comments, 
                itemCheckedOutStatus: itemcheckedoutstatus,
            }
        fetch(itemNameAPI, {
                method: "PUT",
                headers: {
                    "Accept" : "application/json",
                    "Content-Type" : "application/json"
                },
                body: JSON.stringify(updatedItem)
        }).then((response)=>{
            console.log(response);
            getUpdateInventoryItems();
        })
    }
    if(userChoice == "checkedoutstatus")
    {
        const itemNameAPI = "https://localhost:5001/api/inventory/itemcheckedoutstatus/" + id;
        checkedoutstatus = document.getElementById("updateValue").value ;
        const updatedItem ={
                itemID: id,
                itemName: name,
                itemComments: comments, 
                itemCheckedOutStatus: itemcheckedoutstatus,
            }
        fetch(itemNameAPI, {
                method: "PUT",
                headers: {
                    "Accept" : "application/json",
                    "Content-Type" : "application/json"
                },
                body: JSON.stringify(updatedItem)
        }).then((response)=>{
            console.log(response);
            getUpdateInventoryItems();
        })
    }
}


