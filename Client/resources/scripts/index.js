//** not sure if ther local hosts are right, thety seem to be right based on what braden showed */
//gets all transactions
function getTransaction()
{
    const allTransApiUrl = "https://localhost:5001/api/transaction";
    fetch(allTransApiUrl).then(function(response)
    {
        return response.json();
    }).then(function(json)
    {
        let html = "<ul>";
        html += "<tr><th><b>TransactionID</<th><th><b>EmpID</<th><th><b>ItemID</<th><th><b>CheckOutDate</<th><th><b>DueDate</<th><th><b>ReturnDate</<th><th><b>AdminID</th></tr>";
        json.forEach(transaction => {
            html += "<tr><td>" + transaction.TransactionID + "</td><td>" + transaction.EmpID + "</td></tr>" + transaction.ItemID + "</td></tr>" + transaction.CheckOutDate + "</td></tr>" + transaction.DueDate + "</td></tr>" + transaction.ReturnDate + "</td></tr>" + transaction.AdminID + "</td></tr>";
        });
        html += "</ul";
        document.getElementById("transaction").innerHTML = html;
    }).catch(function(error)
    {
        console.log(error);
    });
}
//gets inventory items
function getInventoryItem()
{
    const allItemApiUrl = "https://localhost:5001/api/inventoryitem";
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
// gets all employees 
function getEmployee()
{
    const allEmpApiUrl = "https://localhost:5001/api/employee";
    fetch(allEmpApiUrl).then(function(response)
    {
        return response.json();
    }).then(function(json)
    {
        let html = "<ul>";
        html += "<tr><th><b>EmpID</<th><th><b>EmpName</<th><th><b>EmpEmail</<th><th><b>NoOfItemsCheckedOut</th></tr>";
        json.forEach(employee => {
            html += "<tr><td>" + employee.EmpID + "</td><td>" + employee.EmpName + "</td></tr>" + employee.EmpEmail + "</td></tr>" + employee.NoOfItemsCheckedOut + "</td></tr>";
        });
        html += "</ul";
        document.getElementById("employee").innerHTML = html;
    }).catch(function(error)
    {
        console.log(error);
    });
}