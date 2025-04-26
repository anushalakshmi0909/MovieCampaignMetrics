using MovieCampaignMetrics.Shared;
using MovieCampaignMetrics.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace MovieCampaignMetrics.Server.Services
{
    public class TwitterService
    {
        private readonly ApplicationDbContext _context;

        public TwitterService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SaveTwitterMetricsAsync(TwitterMetrics metrics)
        {
            _context.TwitterMetrics.Add(metrics);
            await _context.SaveChangesAsync();
        }

        public async Task<List<TwitterMetrics>> GetTwitterMetricsAsync()
        {
            return await _context.TwitterMetrics.ToListAsync();
        }
    }
}
