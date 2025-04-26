using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using MovieCampaignMetrics.Shared;
using MovieCampaignMetrics.Server.Services;

namespace MovieCampaignMetrics.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TwitterController : ControllerBase
    {
        private readonly TwitterService _twitterService;

        public TwitterController(TwitterService twitterService)
        {
            _twitterService = twitterService;
        }

        [HttpGet("{tweetId}")]
        public async Task<IActionResult> Get(string tweetId, [FromQuery] string bearerToken)
        {
            using var http = new HttpClient();
            http.DefaultRequestHeaders.Add("Authorization", $"Bearer {bearerToken}");

            var url = $"https://api.twitter.com/2/tweets/{tweetId}?tweet.fields=public_metrics,text";

            var response = await http.GetStringAsync(url);
            var json = JObject.Parse(response);
            var data = json["data"];

            var metrics = data?["public_metrics"];

            var result = new TwitterMetrics
            {
                TweetId = tweetId,
                Text = (string)data?["text"],
                LikeCount = metrics?["like_count"]?.ToString(),
                RetweetCount = metrics?["retweet_count"]?.ToString(),
                ReplyCount = metrics?["reply_count"]?.ToString(),
                FetchedAt = DateTime.UtcNow
            };

            await _twitterService.SaveTwitterMetricsAsync(result);

            return Ok(result);
        }
    }
}
