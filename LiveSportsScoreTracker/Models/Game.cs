namespace LiveSportsScoreTracker.Models
{
    namespace LiveSportsScoreTracker.Models
    {
        public class Game
        {
            public string GameId { get; set; }
            public string TeamA { get; set; }
            public string TeamB { get; set; }
            public int TeamAScore { get; set; }
            public int TeamBScore { get; set; }
            public DateTime StartTime { get; set; }
        }
    }

}
