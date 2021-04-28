
function getReport(reportchoice){
    console.log(reportchoice);
    const apiURL = "https://localhost:5001/api/report/" + reportchoice; //<--this works if you hard code the api endpoint (overdue, lost, etc) ;
    fetch(apiURL).then(function(response){
        console.log(response);
        return response.json();
    }).then(function(json){
        console.log(json);
        if (reportchoice == "Overdue") 
        {
            displayOverdueReport(json);
        } 
        if (reportchoice == "Lost")
        {
            displayLostReport(json);
        }
        if (reportchoice == "Damaged") 
        {
            displayDamagedReport(json);
        } 
        if (reportchoice == "Newest")
        {
            displayNewestReport(json);
        }
        if (reportchoice == "Oldest")
        {
            displayOldestReport(json);
        };  
    }).catch(function(error){          
        console.log(error);
    });
}

function handleOnChange(){
    var reportchoice = document.getElementById("report").value;
    console.log(reportchoice)
    if(reportchoice != "None"){
        getReport(reportchoice);
    }
}

function displayOverdueReport(json){
    let html = "<table class=\"table-bordered table-hover\">";
    html+= "<tr><th><b>EmpID</th><th><b>EmpEmail</th><th><b>Days Overdue</th></tr>";
    json.forEach((report) => {
        html+= "<tr><td>" + report.empID + 
        "</td><td>" + report.empEmail + "</td><td style = color:red !important;>" +report.daysOverdue + "</td></tr>"
    });
    html+= "</table>";
    document.getElementById("reportTable").innerHTML = html;
}
function displayLostReport(json){
    let html = "<table class=\"table-bordered table-hover\">";
    html+= "<tr><th><b>Item ID</th><th><b>Item Name</th><th><b>Item Comments</th>" +
    "<th><b>Item Checked Out Status</th><th><b>Date Comments Updated</th></tr>";
    json.forEach((report) => {
        html+= "<tr><td>" + report.itemID + 
        "</td><td>" + report.itemName + "</td><td>" +report.itemComments+ "</td>"
        +"<td>" + report.itemCheckedOutStatus+ "</td>"+"<td>" + report.dateCommentsUpdated+ "</td></tr>"
    });
    html+= "</table>";
    document.getElementById("reportTable").innerHTML = html;
}
function displayOldestReport(json){
    let html = "<table class=\"table-bordered table-hover\">";
    html+= "<tr><th><b>Transaction ID</th><th><b>Employee ID</th><th><b>Item ID</th>" +
    "<th><b>Check Out Date</th><th><b>Due Date</th><th><b>Return Date</th><th><b>Checkout Admin ID</th>" +
    "<th><b>Return Admin ID</th></tr>";
    json.forEach((report) => {
        html+= "<tr><td>" + report.transactionID + "<td>" + report.itemID+ "</td>" +
        "</td><td>" + report.empID + "</td><td>" +report.checkOutDate+ "</td>"
        +"<td>" + report.dueDate+ "</td>"+"<td>" + report.returnDate+ "</td>"
        +"<td>" +report.checkoutAdminID+ "</td><td>" + report.returnAdminID+ "</td></tr>"
    });
    html+= "</table>";
    document.getElementById("reportTable").innerHTML = html;
}

function displayNewestReport(json){
    let html = "<table class=\"table-bordered table-hover\">";
    html+= "<tr><th><b>Transaction ID</th><th><b>Employee ID</th><th><b>Item ID</th>" +
    "<th><b>Check Out Date</th><th><b>Due Date</th><th><b>Return Date</th><th><b>Checkout Admin ID</th>" +
    "<th><b>Return Admin ID</th></tr>";
    json.forEach((report) => {
        html+= "<tr><td>" + report.transactionID + "<td>" + report.itemID+ "</td>" +
        "</td><td>" + report.empID + "</td><td>" +report.checkOutDate+ "</td>"
        +"<td>" + report.dueDate+ "</td>"+"<td>" + report.returnDate+ "</td>"
        +"<td>" +report.checkoutAdminID+ "</td><td>" + report.returnAdminID+ "</td></tr>"
    });
    html+= "</table>";
    document.getElementById("reportTable").innerHTML = html;
}
function displayDamagedReport(json){
    let html = "<table class=\"table-bordered table-hover\">";
    html+= "<tr><th><b>Item ID</th><th><b>Item Name</th><th><b>Item Comments</th>" +
    "<th><b>Item Checked Out Status</th><th><b>Date Comments Updated</th></tr>";
    json.forEach((report) => {
        html+= "<tr><td>" + report.itemID + 
        "</td><td>" + report.itemName + "</td><td>" +report.itemComments+ "</td>"
        +"<td>" + report.itemCheckedOutStatus+ "</td>"+"<td>" + report.dateCommentsUpdated+ "</td></tr>"
    });
    html+= "</table>";
    document.getElementById("reportTable").innerHTML = html;
}


