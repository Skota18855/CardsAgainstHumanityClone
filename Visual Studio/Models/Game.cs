using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardsAgainstHumanityClone.Models
{
    public class Game
    {
        readonly public List<HouseRule> houseRules = new List<HouseRule>()
        {
            new HouseRule("Rando Cardrissian","Every round, pick one random white card from the pile and place it into play. This card belongs to an imaginary player named Rando Cardrissian, and if he wins the game, all players go home in a state of everlasting shame.",false),
            new HouseRule("Happy Ending"," When you’re ready to end the game, play the “Make a haiku” black card. This is the official ceremonial ending of a good game of Cards Against Humanity. Note: Haikus don’t need to follow the 5-7-5 form. They just have to be read dramatically",false),
            new HouseRule("Wheaton's Law","Each round, the Card Czar draws two black cards, chooses the one they’d prefer to play, and puts the other at the bottom of the black card pile",false),
            new HouseRule("Rebooting the Universe"," At any time, players may trade in a point to return as many white cards as they’d like to the deck and draw back to ten.",false),
            new HouseRule("Packing Heat"," For Pick 2s, all players draw an extra card before playing the hand to open up more options",false),
            new HouseRule("Meritocracy"," Instead of passing clockwise, the role of Card Czar passes to the winner of the previous round.",false),
            new HouseRule("Tie Breaker"," If the Card Czar can’t decide between two white cards, they may declare a Tie Breaker. In the event of a Tie Breaker, the more conventionally attractive player wins.",false),
            new HouseRule("Don't Play Cards Against Humanity","Walk to a park. Call your mother. Live a little",false)
        };

        WhiteDeck WhiteDeck;
        BlackDeck BlackDeck;
        List<Player> Players;

        BlackCard playedBlackCard = null;
        List<WhiteCard> playedWhiteCards = new List<WhiteCard>();

        public Game()
        {
            WhiteDeck = new WhiteDeck();
            BlackDeck = new BlackDeck();
            Players = new List<Player>();
        }

        public void PlayGame(List<Profile> playerProfiles)
        {
            GameSetup(playerProfiles);
            bool gameOver = false;
            while (!gameOver)
            {
                SetupRound();
                PlayRound();
            }
        }

        private Player CreatePlayer(Profile profile)
        {
            return new Player(profile.UserName);
        }

        private void GameSetup(List<Profile> playerProfiles)
        {
            if (houseRules[0].IsEnabled)
            {
                playerProfiles.Add(new Profile("Rando Cardrissian", null, null));
            }

            int firstPlayerIndex = new Random().Next(0, playerProfiles.Count);
            for (int i = firstPlayerIndex; i != firstPlayerIndex - 1; i++)
            {
                if (i < playerProfiles.Count)
                {
                    Players.Add(CreatePlayer(playerProfiles[i]));
                }
                else
                {
                    i = 0;
                }
            }

            //WhiteDeck.CreateDeck();
            //BlackDeck.CreateDeck();

            foreach (Player player in Players)
            {
                player.Hand = WhiteDeck.DrawCards(10).ToList();
            }
        }

        public Player GetLocalPlayer(Profile p)
        {
            return null;
        }

        public void SetupRound()
        {
            playedBlackCard = BlackDeck.DrawCards().First();

            if (houseRules[4].IsEnabled && playedBlackCard.BlankSpaces == 2)
            {
                foreach (Player player in Players.Where(player => player.IsCzar == false))
                {
                    player.Hand.Add(WhiteDeck.DrawCards().First());
                }
            }
        }

        private void PlayRound()
        {

        }

        public void EndRound(WhiteCard chosenCard)
        {
            Players.Where(player => player.Hand.Contains(chosenCard)).First().Score++;
        }
    }
}
