using Microsoft.AspNetCore.SignalR;

namespace ExamenPR.Hubs
{
    public class IdeasHub : Hub
    {
   
        public async Task NotifyNewIdea(string message)
        {
            await Clients.All.SendAsync("ReceiveNewIdea", message);
        }

       
        public async Task NotifyNewVote(string message)
        {
            await Clients.All.SendAsync("ReceiveNewVote", message);
        }
    }
}
