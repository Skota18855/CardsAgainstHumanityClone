using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardsAgainstHumanityClone.Models
{
    public enum eReplaceType
    {
        Discard,
        Top, 
        Bottom,
        Shuffle
    }

    public class BlackDeck
    {
        // Represents all card that are a part of the deck 
        public BlackCard[] DeckCards { get; set; }

        // Represents all cards that are a part of the discard pile (if applicable)
        public BlackCard[] DiscardedCards { get; set; }
        
        /// <summary>
        /// Returns an array of BlackCard equal to the amount specified. Cards returned will be removed from the active deck.
        /// </summary>
        /// <param name="amount">The amount of cards to be drawn.</param>
        /// <returns>An array of BlackCards from the top of the deck (starting at index 0 of the Main Deck array)</returns>
        public BlackCard[] DrawCards(int amount = 1)
        {
            if (amount > DeckCards.Length) throw new ArgumentException("Cannot pass in a value greater than the size of the current deck.");
            BlackCard[] result = new BlackCard[amount];

            for (int i = 0; i < amount; i++)
            {
                result[i] = DeckCards[i];
            }

            int deckSize = DeckCards.Length;
            BlackCard[] tempDeck = new BlackCard[deckSize - amount];

            for (int i = amount; i < DeckCards.Length; i++)
            {
                tempDeck[i - amount] = DeckCards[i];
            }
            
            DeckCards = tempDeck;

            return result;
        }

        /// <summary>
        /// Replaces the returnedCards passed in either back into the deck or the discard pile depending on the ReplaceType used. 
        /// </summary>
        /// <param name="type">The replace type to use. Discard will push the cards to the discar pile while all other types will place the cards into the main deck as specified.</param>
        /// <param name="returnedCards"></param>
        public void ReplaceCards(eReplaceType type, BlackCard[] returnedCards)
        {
            int length;
            BlackCard[] tempDeck;
            switch (type)
            {
                case eReplaceType.Discard:
                    length = DiscardedCards.Length + returnedCards.Length;
                    tempDeck = new BlackCard[length];
                    int discardLength = DiscardedCards.Length;
                    for (int i = 0; i < discardLength; i++)
                    {
                        tempDeck[i] = DiscardedCards[i];
                    }
                    for (int i = discardLength; i < length; i++)
                    {
                        tempDeck[i] = returnedCards[i - discardLength];
                    }
                    DiscardedCards = tempDeck;
                    break;
                case eReplaceType.Top:
                    length = DeckCards.Length + returnedCards.Length;
                    tempDeck = new BlackCard[length];

                    int returnedLength = returnedCards.Length;
                    for (int i = 0; i < returnedLength; i++)
                    {
                        tempDeck[i] = returnedCards[i];
                    }
                    for (int i = returnedLength; i < length; i++)
                    {
                        tempDeck[i] = DeckCards[i - returnedLength];
                    }

                    DeckCards = tempDeck;
                    break;
                case eReplaceType.Bottom:
                    length = DeckCards.Length + returnedCards.Length;
                    tempDeck = new BlackCard[length];

                    int deckLength = DeckCards.Length;
                    for (int i = 0; i < deckLength; i++)
                    {
                        tempDeck[i] = DeckCards[i];
                    }
                    for (int i = deckLength; i < length; i++)
                    {
                        tempDeck[i] = returnedLength[i - deckLength];
                    }

                    DeckCards = tempDeck;
                    break;
                case eReplaceType.Shuffle:
                    ReplaceCards(eReplaceType.Top, returnedCards);
                    ShuffleCards();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Shuffles the cards in the main deck.
        /// </summary>
        /// <param name="withDiscard">Defaults to false; determines if the discard pile should be placed back into the deck before shuffling.</param>
        public void ShuffleCards(bool withDiscard = false)
        {
            if (withDiscard) ReplaceDiscardedCards(eReplaceType.Top);
            List<BlackDeck> deckList = DeckCards;
            BlackCard[] deckArray = BlackCard[DeckCards.Length];
            Random rng = new Random();

            int size = deckArray.Length;
            for (int i = 0; i < size; i++)
            {
                int index = rng.Next(0, deckList.Count());
                BlackCard card = deckList.ElementAt(index);
                deckArray[i] = card;
                deckList.Remove(card);
            }
        }

        /// <summary>
        /// Replaces the discard pile back into the main deck in the manner specified by replaceType. The default is to shuffle them back in.
        /// </summary>
        /// <param name="replaceType">The type of replacement to do. Selecting Discard will have no effect.</param>
        public void ReplaceDiscardedCards(eReplaceType replaceType = eReplaceType.Shuffle)
        {
            ReplaceCards(replaceType, DiscardedCards);
            DiscardedCards = new BlackCard[];
        }
    }
    public class WhiteDeck
    {

    }
}
