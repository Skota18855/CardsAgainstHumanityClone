var gameBoard = getClasses("boardContainer")[0];
var playerHand = getClasses("playerHand")[0];
var playerListElement = getClasses("playerList")[0];

let playerList = [];
let playerListElements = getClasses("player");

var cardDataAttributeString = "data-owner";

function addCard(cardType, cardContent, cardLocation, cardOwner) {

    switch (cardLocation) {

        case "playerHand":
            addCardTo(playerHand, cardType, cardContent, cardOwner, "cardInPlayerHand");
            break;

        case "gameBoard":
        case "":
            addCardTo(gameBoard, cardType, cardContent, cardOwner, "");
            break;

        default:
            console.error("addCard(cardType, cardContent, cardLocation, cardOwner) has been invoked using incorrect arguments")
    }
}

function resetGameBoard(cardContent) {
    gameBoard.innerHTML = `<div class='gameCard blackCard'><p class='blackCardContent'>${cardContent}</p></div >`;
}

function addPlayer(playerName) {

    let player = {
        "name": playerName,
        "score": 0,
        "isCzar": false,
    }

    playerList.push(player);

    var elementToAdd = `<div onclick="testUpdatePlayerScore(this)" class="player" data-player='${player.name}'>${player.score} - ${playerName}</div>`
    playerListElement.innerHTML += elementToAdd;
}

function removePlayer(playerIndex) {
    //remove player
    //bump everyone at backof list up to remove the empty spot
    //reflect the removal on the front end
}

function incrementPlayerScore(playerIndex) {
    if (typeof playerIndex == "number" && playerIndex >= playerList.length || playerIndex < 0) { return console.error(`incrementPlayerScore(playerIndex) was invoked using incorrect arguments. playerIndex must be a number greater than 0 and less than the total number of players. playerIndex was ${playerIndex}; player count is ${playerList.length}`); }

    playerList[playerIndex].score++;
    updateFrontEndPlayer(playerIndex);
}

function updateFrontEndPlayer(playerIndex) {
    //safe input... only called from incrementPlayerScore. If being called elsewhere, validate the index is a safe one before calling this method

    //get the front end player element and update the score value
    playerListElements[playerIndex].innerHTML = replaceAt(playerListElements[playerIndex].innerHTML, 0, playerList[playerIndex].score);
}

function setCzar(playerIndex) {
    if (typeof playerIndex != "number") {
        return console.error(`setCzar(playerIndex) has been invoked using incorrect arguments. Arguments must be a number less than the current number of players. Argument was: ${playerIndex}; Player count is: ${playerList.length}`);
    }

    if (playerIndex >= playerList.length || playerIndex < 0) {
        return console.error(`setCzar(playerIndex) has been invoked using incorrect arguments. Arguments must be a number greater than 0 and less than the current number of players. Argument was: ${playerIndex}; Player count is: ${playerList.length}`);
    }

    playerList.forEach(p => p.isCzar = false);

    playerList[playerIndex].isCzar = true;

    let playerElements = getClasses("player");

    for (let i = 0; i < playerElements.length; i++) {
        if (playerElements[i].innerHTML.endsWith(" - CZAR")) {
            playerElements[i].innerHTML = playerElements[i].innerHTML.substring(0, playerElements[i].innerHTML.length - 6);
        }
    }

    playerElements[playerIndex].innerHTML += " - CZAR";
}

function addCardTo(htmlElement, cardType, cardContent, dataAttributeValue, intoPlayerHandClass) {
    //If the element is to be added to the player's hand then it's onclick should be to playCard and all the other cards onclick should be disabled unless the black card is a picktwo. 
    //If the element is added to the gameBoard (should only be done via the playCard onclick method) the onclick should be chooseWinner but only be clickable by the cardCzar and only one should be clickable.
    var elementToAdd;

    if (intoPlayerHandClass.length > 0) { elementToAdd = `<div onclick='playCard("${cardContent}","${dataAttributeValue}", this)' class='gameCard ${cardType} ${intoPlayerHandClass}' ${cardDataAttributeString}='${dataAttributeValue}'><p class='${cardType}Content'>${cardContent}</p></div>` }
    else { elementToAdd = `<div class='gameCard ${cardType} ${intoPlayerHandClass}' ${cardDataAttributeString}='${dataAttributeValue}'><p class='${cardType}Content'>${cardContent}</p></div>` }
    htmlElement.innerHTML += elementToAdd;
}

function getClasses(className) {
    return document.getElementsByClassName(className);
}

function replaceAt(string, index, replace) {
    return string.substring(0, index) + replace + string.substring(index + 1);
}

function removeCard(cardElementToRemove) {
    //remove card from html
    cardElementToRemove.parentNode.removeChild(cardElementToRemove);
}

function playCard(cardContent, cardOwner, cardToRemove) {
    //Remove card from player's hand and add that card to the gameboard.
    //removeCard()
    addCard("whiteCard", cardContent, "gameBoard", cardOwner);
    removeCard(cardToRemove);
}

function chooseWinner() {

}


////DEBUG CODE////
function testAddPlayer() {
    let nameElm = document.getElementById("newNameId");
    if (nameElm.value === "") return console.error("Please enter a name for the test player to add");

    addPlayer(nameElm.value);
    nameElm.value = "";
}

function testUpdatePlayerScore(playerElement) {
    let playerName = playerElement.dataset.player;

    for (let i = 0; i < playerList.length; i++) {
        if (playerList[i].name === playerName) {
            incrementPlayerScore(i);
        }
    }
}

function testAddCard() {
    let cardDestElm = document.getElementById("addTestCard");

    if (cardDestElm.checked) {
        //hand
        addCard("whiteCard", "test content", "playerHand", profile);
    }
    else {
        //board
        addCard("whiteCard", "test content", "gameBoard", profile);
    }
}

function testResetBoard() {
    resetGameBoard("debug board reset");
}
