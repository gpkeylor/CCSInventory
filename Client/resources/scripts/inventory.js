//gets inventory items
function getInventoryItem()
{
    const allItemApiUrl = "https://localhost:5001/api/inventory";
    fetch(allItemApiUrl).then(function(response)
    {
        return response.json();
    }).then(function(json)
    {
        let html = "<ul>";
        html += "<tr><th><b>ItemID</<th><th><b>ItemName</<th><th><b>ItemComments</<th><th><b>ItemCheckedOutStatus</th></tr>";
        json.forEach(inventoryItem => {
            html += "<tr><td>" + inventoryItem.ItemID + "</td><td>" + inventoryItem.ItemName + "</td></tr>" + inventoryItem.ItemComments + "</td></tr>" + inventoryItem.ItemCheckedOutStatus + "</td></tr>";
        });
        html += "</ul";
        document.getElementById("inventoryItem").innerHTML = html;
    }).catch(function(error)
    {
        console.log(error);
    });
}