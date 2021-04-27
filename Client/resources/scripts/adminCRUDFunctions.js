function addInventoryItem()
{
    const postItemApiUrl = "https://localhost:5001/api/inventory";
    const ItemName = document.getElementById("ItemName").value;
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
        getInventoryItem();
    });
}
function deleteInventoryItem(ItemID)
{
    ItemID = document.getElementById("ItemID").value;
    const deleteApiUrl = "https://localhost:5001/api/inventory"+ ItemID;
 
    fetch(deleteApiUrl,
    {
        method : "DELETE",
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json"
        },
    }).then((response)=>{
    getInventoryItem();
    });
}