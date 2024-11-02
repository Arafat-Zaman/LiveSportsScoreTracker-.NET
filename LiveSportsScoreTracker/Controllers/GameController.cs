using LiveSportsScoreTracker.Hubs;
using LiveSportsScoreTracker.Hubs.LiveSportsScoreTracker.Hubs;
using LiveSportsScoreTracker.Models;
using LiveSportsScoreTracker.Models.LiveSportsScoreTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace LiveSportsScoreTracker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        private readonly IHubContext<ScoreHub> _hubContext;

        public GameController(IHubContext<ScoreHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost("update-score")]
        public async Task<IActionResult> UpdateScore([FromBody] Game game)
        {
            // Broadcast score to all users following this game
            await _hubContext.Clients.Group(game.GameId).SendAsync("ReceiveScoreUpdate", game);
            return Ok();
        }

        [HttpPost("send-event")]
        public async Task<IActionResult> SendEvent([FromBody] GameEvent gameEvent)
        {
            await _hubContext.Clients.Group(gameEvent.GameId).SendAsync("ReceiveEvent", gameEvent);
            return Ok();
        }
    }
}
