
function getReport(report){
    const apiURL = "https://localhost:5001/api/transaction" + value//= overdue
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
    if(report != "none"){
        getReport(report);
    }
}

function displayReport(report){
    let html = "<>";
}