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