using Microsoft.EntityFrameworkCore;
using BowlingApi.Models;

namespace BowlingApi.Data
{
    public class BowlingContext : DbContext
    {
        public BowlingContext(DbContextOptions<BowlingContext> options) : base(options) { }

        public DbSet<Bowler> Bowlers { get; set; }
        public DbSet<Team> Teams { get; set; }
    }
}