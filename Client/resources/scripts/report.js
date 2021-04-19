
function getReport(report){
    const apiURL = "https://localhost:5001/api/report/" + value//= overdue
    fetch(api.URL).then(function(response){
        console.log(response);
        return response.json();
    }).then(function(json){
        console.log(json);
        displayReport(json);
    }).catch(function(error){
        console.log(error);
    });
}

function handleOnChange(){
    const report = document.getElementById("report").value;
    console.log(value)
    if(report != "none"){
        getReport(report);
    }
}

function displayReport(report){
    let html = "<table>";
    html+= "<tr><th><b>EmpID</th><th><b>EmpEmail</th><th><b>Days Overdue</th></tr>";
    json.forEach((report) => {
        html+= "<tr><td>" + report.empID + 
        "</td><td>" + report.empEmail + "</td></tr>" +report.daysOverdue + "</td></tr>"
    });
    html+= "</table>";
    document.getElementById("reportTable").innerHTML = html;
}