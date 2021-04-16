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
            html += "<tr><td>" + transaction.transactionID + "</td><td>" + transaction.empID + "</td></tr>" + itemID + "</td></tr>" + checkOutDate + "</td></tr>" + dueDate + "</td></tr>" + returnDate + "</td></tr>" + adminID ;
        });
        html += "</ul";
        document.getElementById("transaction").innerHTML = html;
    }).catch(function(error)
    {
        console.log(error);
    });
}