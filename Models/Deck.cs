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
        
        // Will return an array of BlackCards equal to the amount specified.
        /// <summary>
        /// Returns an array of BlackCard equal to the amount specified. Cards returned will be removed from the active deck.
        /// </summary>
        /// <param name="amount">The amount of cards to be drawn.</param>
        /// <returns></returns>
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

        public void ReplaceCards(eReplaceType type, BlackCard[] returnedCards)
        {
            int length;
            BlackCard[] tempDeck;
            switch (type)
            {
                case eReplaceType.Discard:
                    length = DiscardedCards.Length + returnedCards.Length;
                    tempDeck = new BlackCard[length];
                    for (int i = 0; i < DiscardedCards.Length; i++)
                    {
                        tempDeck[i] = DiscardedCards[i];
                    }
                    for (int i = DiscardedCards.Length; i < length; i++)
                    {
                        tempDeck[i] = returnedCards[i - DiscardedCards.Length];
                    }
                    DiscardedCards = tempDeck;
                    break;
                case eReplaceType.Top:
                    length = DeckCards.Length + returnedCards.Length;
                    tempDeck = new BlackCard[length];

                    foreach(BlackCard card in DeckCards)
                    {
                        returnedCards.Append(card);
                    }
                    DeckCards = tempDeck;
                    break;
                case eReplaceType.Bottom:
                    break;
                case eReplaceType.Shuffle:
                    break;
                default:
                    break;
            }
        }

        public void ShuffleCards(bool withDiscard = false)
        {

        }

        // If shuffle is false, will place 
        public void ReplaceDiscardedCards(eReplaceType replaceType = eReplaceType.Shuffle)
        {

        }
    }
    public class WhiteDeck
    {

    }
}
