var gameBoard = getClasses("boardContainer")[0];
var playerHand = getClasses("playerHand")[0];

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

function addCardTo(htmlElement, cardType, cardContent, dataAttributeValue) {
    var elementToAdd = `<div class='gameCard ${cardType}' ${cardDataAttributeString}='${dataAttributeValue}'><p class='${cardType}Content'>${cardContent}</p></div>`
    htmlElement.innerHTML += elementToAdd;
}

function getClasses(className) {
    return document.getElementsByClassName(className);
}