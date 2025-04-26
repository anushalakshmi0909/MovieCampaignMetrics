namespace MovieCampaignMetrics.Shared
{
    public class TwitterMetrics
    {
        public int Id { get; set; }
        public string TweetId { get; set; }
        public string Text { get; set; }
        public string LikeCount { get; set; }
        public string RetweetCount { get; set; }
        public string ReplyCount { get; set; }
        public DateTime FetchedAt { get; set; }
    }
}
