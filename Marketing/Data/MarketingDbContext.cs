using Microsoft.EntityFrameworkCore;
using Marketing.Data.Entities;

namespace Marketing.Data
{
    public class MarketingDbContext : DbContext
    {
        public MarketingDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Application> Applications { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Bid> Bids { get; set; }
    }
}
