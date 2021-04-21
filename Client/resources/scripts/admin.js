//get the administrator
function getAdministrator()
{
    const allAdmApiUrl = "https://localhost:5001/api/admin";
    fetch(allAdmApiUrl).then(function(response)
    {
        return response.json();
    }).then(function(json)
    {
        var enteredId = document.getElementById("administrator").value;
       // enteredId = parseInt(enteredId);
       console.log(enteredId)
        json.forEach(administrator => {
            if (administrator.adminID == enteredId)
            {
              //  console.log(administrator.adminID);
               // document.getElementById("administrator").setAttribute("href","./transactions.html");
               window.location ="\Client\adminFunctions.html";
            }
        });
       
    }).catch(function(error)
    {
        console.log(error);
    });
}