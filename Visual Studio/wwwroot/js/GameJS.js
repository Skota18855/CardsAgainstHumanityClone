//here build a connection
var connection = new signalR.HubConnectionBuilder().withUrl("/gameHub").build();

document.getElementById("AddCard").disabled = true;


//This method receive the message and Append it to our list 
connection.on("ReceiveCard", function (cardJson) {
    connection.invoke("FinalizeCard", cardJson).catch(function (err) {
        return console.error(err.toString());
    });
});

connection.start().then(function () {
    document.getElementById("AddCard").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

connection.on("FinalReceive", function (content, owner) {

});

//this block of code is used to send message.
document.getElementById("SendCard").addEventListener("click", function (event) {
    var user = "ako";
    var whiteCardText = "Testing White Card";
    connection.invoke("SendCard", user, whiteCardText).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});