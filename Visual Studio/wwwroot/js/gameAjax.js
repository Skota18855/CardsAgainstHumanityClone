var gameBoard = getClasses("boardContainer")[0];
var playerHand = getClasses("playerHand")[0];
var playerListElement = getClasses("playerList")[0];

let playerList = [];

var cardDataAttributeString = "data-owner";

function addCard(cardType, cardContent, cardLocation, cardOwner) {

    switch (cardLocation) {

        case "playerHand":
            addCardTo(playerHand, cardType, cardContent, cardOwner);
            break;

        case "gameBoard":
        case "":
            addCardTo(gameBoard, cardType, cardContent, cardOwner);
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

    var elementToAdd = `<div class="player">${playerName} - ${player.score}</div>`
    playerListElement.innerHTML += elementToAdd;
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

function addCardTo(htmlElement, cardType, cardContent, dataAttributeValue) {
    //If the element is to be added to the player's hand then it's onclick should be to playCard and all the other cards onclick should be disabled unless the black card is a picktwo. 
    //If the element is added to the gameBoard (should only be done via the playCard onclick method) the onclick should be chooseWinner but only be clickable by the cardCzar and only one should be clickable.
    var elementToAdd = `<div onclick='playCard("${cardContent}","${dataAttributeValue}")' class='gameCard ${cardType}' ${cardDataAttributeString}='${dataAttributeValue}'><p class='${cardType}Content'>${cardContent}</p></div>`
    htmlElement.innerHTML += elementToAdd;
}

function getClasses(className) {
    return document.getElementsByClassName(className);
}

function playCard(cardContent, cardOwner) {
    //Remove card from player's hand and add that card to the gameboard.
    //removeCard()
    addCard("whiteCard", cardContent, "gameBoard", cardOwner);
}

function chooseWinner() {

}
