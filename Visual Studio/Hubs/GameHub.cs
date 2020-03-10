using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CardsAgainstHumanityClone.Models;

namespace CardsAgainstHumanityClone.Hubs
{
    public class GameHub : Hub
    {
        public async Task SendCard(string user, string whiteCardText)
        {
            string sending = CardToJson(user, whiteCardText);
            await Clients.All.SendAsync("ReceiveCard", sending);
        }

        public async Task FinalizeCard(string cardJson)
        {
            GameCard card = GameCard.FromJson(cardJson);

            await Clients.All.SendAsync("FinalReceive", card.cardContent, card.owner);
        }

        private string CardToJson(string user, string whiteCardText)
        {
            GameCard card = new GameCard();
            card.cardType = "whiteCard";
            card.cardContent = whiteCardText;
            card.owner = user;
            return GameCard.ToJson(card);
        }
    }
}
