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
<<<<<<< HEAD
              //  console.log(administrator.adminID);
               // document.getElementById("administrator").setAttribute("href","./transactions.html");
               window.location ="\ transaction.html";
            }
            else{
                displayErrorMessage();
=======
              
               window.location ="\ transaction.html";
>>>>>>> f186271d839f43da5d1ea2c2fa131c654d7bd247
            }
        });
       
    }).catch(function(error)
    {
        console.log(error);
    });
}  

function displayErrorMessage(){
    let html = "<p style = color:red !important;>Error! Invalid AdminID. Please enter a valid AdminID.</p>";
    document.getElementById("errormessage").innerHTML = html;
}
