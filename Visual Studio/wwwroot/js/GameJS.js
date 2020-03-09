//here build a connection
var connection = new signalR.HubConnectionBuilder().withUrl("/gameHub").build();

document.getElementById("AddCard").disabled = true;


//This method receive the message and Append it to our list 
connection.on("ReceiveCard", function (user, whiteCardText) {
    //var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    //var encodedMsg = user + " says " + msg;
    var li = document.createElement("li");
    li.textContent = user + " plays: " + whiteCardText;
    document.getElementById("GameUl").appendChild(li);
});

connection.start().then(function () {
    document.getElementById("AddCard").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});


//this block of code is used to send message.
document.getElementById("AddCard").addEventListener("click", function (event) {
    //var user = document.getElementById("userName").value;
    //var message = document.getElementById("userMessage").value;
    var user = "ako";
    var whiteCardText = "Testing White Card";
    connection.invoke("SendCard", user, whiteCardText).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});