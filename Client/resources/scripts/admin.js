//get the administrator
function getAdministrator()
{
    const allAdmApiUrl = "https://localhost:5001/api/administrator";
    fetch(allAdmApiUrl).then(function(response)
    {
        return response.json();
    }).then(function(json)
    {
        var enteredId = document.getElementById("administrator").innerHTML = html;
        json.forEach(administrator => {
            if (administrator.AdminID == enteredId)
            {
                document.getElementById("administrator").setAttribute("href","./transactions.html");
            }

        });
        html += "</ul";
    }).catch(function(error)
    {
        console.log(error);
    });
}