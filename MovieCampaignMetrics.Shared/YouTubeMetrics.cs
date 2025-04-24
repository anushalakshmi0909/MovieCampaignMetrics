namespace MovieCampaignMetrics.Shared
{
    public class YouTubeMetrics
    {
        public int Id { get; set; }
        public string VideoId { get; set; }
        public string Title { get; set; }
        public string ViewCount { get; set; }
        public string LikeCount { get; set; }
        public string CommentCount { get; set; }
        public DateTime FetchedAt { get; set; }
    }
}
