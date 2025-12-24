using Microsoft.EntityFrameworkCore;
using VotingApp.Models;

namespace VotingApp.Data 
{
    public class VotingDbContext : DbContext
    {
        public VotingDbContext(DbContextOptions<VotingDbContext> options)
        : base(options) { }

        public DbSet<Voter> Voters { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
    }
}
