using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using MovieCampaignMetrics.Shared;
using MovieCampaignMetrics.Server.Services;

namespace MovieCampaignMetrics.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class YouTubeController : ControllerBase
    {
        private readonly YouTubeService _youTubeService;

        public YouTubeController(YouTubeService youTubeService)
        {
            _youTubeService = youTubeService;
        }

        [HttpGet("{videoId}")]
        public async Task<IActionResult> Get(string videoId, [FromQuery] string apiKey)
        {
            using var http = new HttpClient();
            var url = $"https://www.googleapis.com/youtube/v3/videos?part=snippet,statistics&id={videoId}&key={apiKey}";

            var response = await http.GetStringAsync(url);
            var json = JObject.Parse(response);
            var video = json["items"]?.FirstOrDefault();

            var result = new YouTubeMetrics
            {
                VideoId = videoId,
                Title = (string)video?["snippet"]?["title"],
                ViewCount = (string)video?["statistics"]?["viewCount"],
                LikeCount = (string)video?["statistics"]?["likeCount"],
                CommentCount = (string)video?["statistics"]?["commentCount"],
                FetchedAt = DateTime.UtcNow
            };

            await _youTubeService.SaveYouTubeMetricsAsync(result);

            return Ok(result);
        }
    }
}
