using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MovieCampaignMetrics.Shared;

namespace MovieCampaignMetrics.Server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<YouTubeMetrics> YouTubeMetrics { get; set; }
        public DbSet<TwitterMetrics> TwitterMetrics { get; set; }

    }
}
