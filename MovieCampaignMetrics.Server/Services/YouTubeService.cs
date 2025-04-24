using MovieCampaignMetrics.Shared;
using MovieCampaignMetrics.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace MovieCampaignMetrics.Server.Services
{

    public class YouTubeService
    {
        private readonly ApplicationDbContext _context;

        public YouTubeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SaveYouTubeMetricsAsync(YouTubeMetrics metrics)
        {
            _context.YouTubeMetrics.Add(metrics);
            await _context.SaveChangesAsync();
        }
        public async Task<List<YouTubeMetrics>> GetYouTubeMetricsAsync()
        {
            return await _context.YouTubeMetrics.ToListAsync();
        }
    }
}
