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
function checkEmployeeEligibility()
{
    const allEmpApiUrl = "https://localhost:5001/api/employee";
    var enteredEmpId = document.getElementById("empID").value;
    console.log(enteredEmpId);
    fetch(allEmpApiUrl).then(function(response){
        return response.json();
    }).then(function(json){
        var databaseEmpId;
        var numberOfItemsCheckedOut;
        var today = new Date();
        console.log(today);
        var date =today.setDate(today.getDate() + 14); //sets the due date for 14 days after current date
        date = (today.getMonth()+1)+'-'+today.getDate()+'-'+today.getFullYear();
        console.log(date);
        json.forEach(employee => {
            if(employee.empID == enteredEmpId)
            {
                console.log(employee.empID)
                databaseEmpId = employee.empID;
                numberOfItemsCheckedOut = employee.noOfItemsCheckedOut;
            } 
            if(enteredEmpId == databaseEmpId)
            {
                displayEmployeeTransactions(enteredEmpId);
                if(numberOfItemsCheckedOut < 3)
                {
                    let htmlEligible = "<p style = color:black !important;>Employee currently has " +numberOfItemsCheckedOut + " item(s) checked out. Employee is eligible to checkout another item. An item checked out today will be due: <b><u>"+ date+"</p>";
                    document.getElementById("employeeEligibility").innerHTML = htmlEligible;
                }
                else{
                    htmlNotEligible = "<p style = color:red !important;>Employee currently has " + employee.noOfItemsCheckedOut+ " items checked out. This is the maximum amount of items checked out at once</p>"
                    document.getElementById("employeeEligibility").innerHTML = htmlNotEligible;
                }
            }
            else{   
                let htmlError = "<p style = color:red !important;>Error! Invalid EmployeeID. Please enter a valid EmployeeID.</p>"
                document.getElementById("employeeEligibility").innerHTML = htmlError;
            }
        })
    })/*.catch(function(error)
    {
        console.log(error);
    })*/   
}

function displayInventoryItemNames(){
    const allAvailableItemNames = "https://localhost:5001/api/inventory/itemnames";
    fetch(allAvailableItemNames).then(function(response){
        return response.json();
    }).then(function(json){
        let html ="";
        json.forEach(item =>{
            html += "<input type=\"radio\" id="+item.itemID+ "name='equipment' onClick = \"checkItemPicked("+item.itemID+")\" value=" +item.itemID+ " ><label for="+item.name+" >"+item.name+"</label><br>"
        })
    document.getElementById("itemnames").innerHTML = html;
    }).catch(function(error)
    {
        console.log(error);
    });
}

var userItemChoiceID
function checkItemPicked(id){
    
    console.log(id);
    userItemChoiceID = id;
    console.log(userItemChoiceID);
    
}
function handleOnClick()
{
    addCheckoutTransaction(userItemChoiceID);
    updateInventoryItems(userItemChoiceID)
}

function addCheckoutTransaction(userItemChoiceID){
    const transactionAPI = "https://localhost:5001/api/transaction";
    const enteredEmpID = parseInt(document.getElementById("empID").value); 
    const chosenItemID =  userItemChoiceID;
    var getAdmin = window.location.search;
    var parameters = new URLSearchParams(getAdmin);
    const adminCheckingOutItemID = parseInt(parameters.get("adminID"));
    console.log(adminCheckingOutItemID);
    //const checkoutAdminID = parseInt(document.getElementById("checkoutadminid").value);
    let transaction = {
        empID: enteredEmpID,
        itemID: chosenItemID,
        checkoutAdminID: adminCheckingOutItemID
    }
    fetch(transactionAPI, {
        method: "POST",
        headers: {
            "Accept" : "application/json",
            "Content-Type" : "application/json"
        },
        body:JSON.stringify(transaction)
    })
    .then((response)=>{
        console.log(response);
    })
    checkEmployeeEligibility();
}
function updateTransactionTable(){
    var transID = document.getElementById("updateTransactionID").value ;
    var adminID = document.getElementById("updateAdminID").value ;
    var transAPIID = parseInt(transID,32);
    var adminAPIID = parseInt(adminID,32);
    const TransactionURL = "https://localhost:5001/api/transaction/" + transAPIID;
    
    const updatedTransaction = {
                transactionID: transAPIID,
                empID: 0,
                itemID: 0,
                checkOutDate: "2021-04-28T07:51:11.139Z",
                dueDate: "2021-04-28T07:51:11.139Z",
                returnDate: "2021-04-28T07:51:11.139Z",
                checkoutAdminID: 0,
                returnAdminID:  adminAPIID
                
    }
    fetch(TransactionURL, {
            method: "PUT",
            headers: {
                "Accept" : "application/json",
                "Content-Type" : "application/json"
            },
            body: JSON.stringify(updatedTransaction)
        }).then((response)=>{
            console.log(response);
            checkEmployeeEligibility();
        })
}

function updateInventoryItems(userItemChoiceID)
{
    
    const InventoryItemsURL = "https://localhost:5001/api/inventory/itemcheckedoutstatus/" + userItemChoiceID;
    const updatedInventory = {
        itemID: userItemChoiceID,
        itemCheckedOutStatus: 1
    }
    fetch(InventoryItemsURL, {
    method: "PUT",
    headers: {
        "Accept" : "application/json",
        "Content-Type" : "application/json"
    },
    body: JSON.stringify(updatedInventory)
        }).then((response)=>{
        console.log(response);
        checkEmployeeEligibility();
        })
}




function displayEmployeeTransactions(){
    const empTransactions = "https://localhost:5001/api/transaction/emptransactionsreturn";
    var enteredEmpId = document.getElementById("empID").value;
    fetch(empTransactions).then(function(response){
        return response.json();
    }).then(function(json){
        console.log(json);
        let html= "<table class=\"table-bordered table-hover\">";
        html+= "<tr><th><b>TransactionID</th><th><b>EmployeeID</th>";
        html+= "<th><b>ItemID</th><th><b>Check Out Date</th>";
        html+= "<th><b>Due Date</th><th><b>Admin At Check Out</th><th></th>";
        json.forEach((transaction) => {
            if(enteredEmpId == transaction.empID)
            {
                html+= "<tr><td>" + transaction.transactionID + 
                "</td><td>" + transaction.empID + "</td>" 
                +"<td>" + transaction.itemID + "</td>"  + "<td>" + transaction.checkOutDate + "</td>"
                + "<td>" + transaction.dueDate + "</td>" + "<td>" + transaction.checkoutAdminID + "</td>" + "<td><button>Return</button></td>" 
            } 
        });
        html+= "</table>";
        document.getElementById("empTransactions").innerHTML = html;
    }).catch(function(error){
        console.log(error);
    })
}
