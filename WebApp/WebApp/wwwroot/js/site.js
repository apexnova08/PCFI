// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

class Sched {
    constructor(balance, duedate, term, amount, interest, insurance) {
        this.balance = balance;
        this.duedate = duedate;
        this.term = term;
        this.amount = amount;
        this.interest = interest;
        this.insurance = insurance;
    }
}
function OnLoad() {

    // Define the API URL
    const apiUrl = 'https://localhost:7084/EquitySchedule?SellingPrice=20000&ReservationDate=2022-2-2&EquityTerm=5';

    // Make a GET request
    fetch(apiUrl)
        .then(response => {
            if (!response.ok) {
                document.getElementById("test").textContent = "not epic";
            }
            document.getElementById("test").textContent = "epic";
            return response.json();
        })
        .then(data => {
            console.log(data);
        })
        .catch(error => {
            console.error('Error:', error);
        });
}
