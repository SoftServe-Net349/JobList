using JobList.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobList.DataAccess.Data
{
    public class JobListDbContext : DbContext
    {
        public JobListDbContext(DbContextOptions<JobListDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<Sample> Samples { get; set; }
    }
}
