namespace LiveSportsScoreTracker.Hubs
{
    using Microsoft.AspNetCore.SignalR;
    using System.Threading.Tasks;

    namespace LiveSportsScoreTracker.Hubs
    {
        public class ScoreHub : Hub
        {
            public async Task SendScoreUpdate(string gameId, string score)
            {
                await Clients.Group(gameId).SendAsync("ReceiveScoreUpdate", score);
            }

            public async Task JoinGameGroup(string gameId)
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, gameId);
            }

            public async Task LeaveGameGroup(string gameId)
            {
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, gameId);
            }
        }
    }

}
