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
            await Clients.All.SendAsync("ReceiveCard", user, whiteCardText);
        }
    }
}
