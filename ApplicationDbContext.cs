using Coravel.Pro.EntityFramework;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CoravelTest
{
    public class ApplicationDbContext : IdentityDbContext, ICoravelProDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Server=(localdb)\\mssqllocaldb;Database=Coravel;Trusted_Connection=True;MultipleActiveResultSets=true"
                );
            }
        }

        public DbSet<CoravelJobHistory> Coravel_JobHistory { get; set; }
        public DbSet<CoravelScheduledJob> Coravel_ScheduledJobs { get; set; }
        public DbSet<CoravelScheduledJobHistory> Coravel_ScheduledJobHistory { get; set; }
    }
}
