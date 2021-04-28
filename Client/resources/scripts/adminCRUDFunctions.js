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
        itemName : ItemName
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
    getUpdateInventoryItems();
    getDeleteInventoryItems();
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
        getDeleteInventoryItems();
        getUpdateInventoryItems();
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
var itemIdChosenToUpdate;
function updateItemChoice(id){
    updateChoice = document.getElementsByName('choice');
    for(i=0; i<updateChoice.length;i++){
        if(updateChoice[i].checked){
            userChoice = updateChoice[i].value
        }
    }
    console.log(userChoice);
    console.log(id);
    itemIdChosenToUpdate = id;
}
function handleOnClick(){
    updateItem(userChoice, itemIdChosenToUpdate);
    getUpdateInventoryItems();
    getDeleteInventoryItems();
}


function updateItem(userChoice, itemIdChosenToUpdate)
{
    const itemAPI = "https://localhost:5001/api/inventory";
    var name ="";
    var comments = "";
    var itemcheckedoutstatus = "";
    fetch(itemAPI).then(function(response){
        return response.json();
    }).then(function(json){
        console.log(json);
        json.forEach(item => {
            if(itemIdChosenToUpdate == item.itemID)
            {
                name = item.itemName;
                comments = item.itemComments;
                itemcheckedoutstatus = item.itemCheckedOutStatus;
            }
        })
    })
    
    if(userChoice == "name")
    {
        const itemNameAPI = "https://localhost:5001/api/inventory/itemname/" + itemIdChosenToUpdate;
        name = document.getElementById("updateValue").value ;
        const updatedItem ={
                itemID: itemIdChosenToUpdate,
                itemName: name
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
        })
    }
    getUpdateInventoryItems();
    getDeleteInventoryItems();
    if(userChoice == "comments")
    {
        const itemNameAPI = "https://localhost:5001/api/inventory/itemcomments/"+ itemIdChosenToUpdate;
        comments = document.getElementById("updateValue").value ;
        console.log(comments)
        const updatedItem ={
                itemID: itemIdChosenToUpdate,
                itemComments: comments
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
        })
    } 
    getUpdateInventoryItems();
    getDeleteInventoryItems();
    if(userChoice == "checkedout")
    {
        const itemNameAPI = "https://localhost:5001/api/inventory/itemcheckedoutstatus/" + itemIdChosenToUpdate;
        itemcheckedoutstatus = parseInt(document.getElementById("updateValue").value);
        console.log(itemcheckedoutstatus);
        const updatedItem = {
                itemID: itemIdChosenToUpdate,
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
            
        })
        getUpdateInventoryItems();
        getDeleteInventoryItems();
    }
}


