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
            console.log(item.name);
            html += "<input type=\"radio\" id="+item.id+ "name=\"equipment\" value=" +item.id+ " ><label for="+item.name+" >"+item.name+"</label><br>"
        })
    document.getElementById("itemnames").innerHTML = html;
    }).catch(function(error)
    {
        console.log(error);
    });
}

function addCheckoutTransaction(){
    const transactionAPI = "https://localhost:5001/api/transaction";
    const enteredEmpID = document.getElementById("empID").value; //<--value from employeeID entered to check employee eligibility
    const chosenItemID =  "";        //<--need to get this value from selected radio button
    const adminCheckingOutItemID = ";"   //<--need to get this value from admin id entered at login or could have admin re enter their id
    //other values like checkoutdate(today's date), duedate(today's date + 14 days), returndate(1001-01-01 placeholder), 
    //returnadminID(0 as a placeholder) are automatically instantiated in transaction constructor

    fetch(transactionAPI, {
        method: "POST",
        headers: {
            "Accept" : "application/json",
            "Content-Type" : "application/json"
        },
        body: JSON.stringify({
            empID: enteredEmpID,
            itemID: chosenItemID,
            checkoutAdminID: adminCheckingOutItemID
        })
    })
    .then((response)=>{
        console.log(response);
    })
}
app.use(function(req, res, next) {
    res.header("Access-Control-Allow-Origin", "*");
    res.header("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept");
    res.header('Access-Control-Allow-Methods', 'PUT, POST, GET, DELETE, OPTIONS');
       next();
 });
function updateTransaction(){
    
    var transactionID = document.getElementById("updateTransactionID").value;
    var adminID = document.getElementById("updateAdminID").value;
    const empTransactions ="https://localhost:5001/api/transaction/" + transactionID;
    const item = {
        TransactionID : transactionID,
        ReturnAdminID : adminID,
    }
    fetch(empTransactions, {
        method: "PUT",
        headers: {
            
            "Accept": 'application/json',
            "Content-Type": 'application/json',
        },
        body: JSON.stringify(item)
    }).then((response)=>{
        console.log(response)
        checkEmployeeEligibility();
    })
}
function updateInventoryItems()
{
    var conditions = document.getElementsByName('condition');
    var condition_value;
    for(var i = 0; i < conditions.length; i++){
    if(conditions[i].checked){
        condition_value = conditions[i].value;
    }
}
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
                + "<td>" + transaction.dueDate + "</td>" + "<td>" + transaction.checkoutAdminID + "</td>" 
            } 
        });
        html+= "</table>";
        document.getElementById("empTransactions").innerHTML = html;
    }).catch(function(error){
        console.log(error);
    })
}
